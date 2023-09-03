using UnityEngine;

public class Square : Shape
{

    private readonly float groundPoundForce = 40f;

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Square");
        stats = new ShapeStats(60, 100, 40);
    }

    public override void HandlePassiveSkill()
    {
        bool isInAir = playerController.playerMovement.isInAir;
        bool isDownHeld = playerController.playerInput.isDownHeld;
        if (isInAir && isDownHeld)
        {
            isPassiveSkillActive = true;
            GroundPound();
        }
    }

    public override void HandleMovementSkill()
    {
        // TODO: Implement movement skill
    }

    public override void HandleActionSkill()
    {
        // TODO: Implement action skill
    }

    public override void ResetOnCollision()
    {
        ClearSkills();
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Square>());
    }

    private void GroundPound()
    {
        Rigidbody2D rb = playerController.rb;
        rb.velocity = new Vector2(rb.velocity.x, -1f * groundPoundForce);
    }
}