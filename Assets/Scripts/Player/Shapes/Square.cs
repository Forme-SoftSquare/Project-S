using UnityEngine;

public class Square : Shape
{

    private readonly float groundPoundForce = 50f;

    private bool isGroundPoundActive = false;
    private bool isShieldActive = false;

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Square");
        stats = new ShapeStats(60, 100, 40);
    }

    public override void HandlePassiveSkill()
    {
        bool canNotMove = !playerController.playerMovement.CanMove();
        // if the player can't move but not because of the ground pound, return
        if (canNotMove && !isGroundPoundActive) return;

        bool isInAir = playerController.playerMovement.isInAir;
        bool isDownHeld = playerController.playerInput.isDownHeld;

        bool shouldActiveGroundPound = isInAir && isDownHeld && !isGroundPoundActive;
        bool shouldContinueToDescend = isInAir && isGroundPoundActive;

        if (shouldActiveGroundPound)
        {
            GroundPound();
        }
        else if (shouldContinueToDescend)
        {
            Descend();
        }
    }

    public override void HandleMovementSkill()
    {
        // TODO: Implement movement skill
    }

    public override void HandleActionSkill()
    {
        bool canNotMove = !playerController.playerMovement.CanMove();
        // if the player can't move but not because of the shield, return
        if (canNotMove && !isShieldActive) return;

        if (playerController.playerInput.isActionSkillHeld && !isShieldActive)
        {
            isShieldActive = true;
            // add shield skill (stats update, invincibility...)
        }

        if (playerController.playerInput.isActionSkillReleased && isShieldActive)
        {
            isShieldActive = false;
            // remove shield skill
        }
    }

    public override void ResetOnCollision()
    {
        isGroundPoundActive = false;
        isShieldActive = false;
    }

    public override bool IsBlockingSkillActive()
    {
        return isShieldActive || isGroundPoundActive;
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Square>());
    }

    private void GroundPound()
    {
        isGroundPoundActive = true;
        Descend();
    }

    private void Descend()
    {
        Rigidbody2D rb = playerController.rb;
        rb.velocity = new Vector2(rb.velocity.x, -1f * groundPoundForce);
    }
}