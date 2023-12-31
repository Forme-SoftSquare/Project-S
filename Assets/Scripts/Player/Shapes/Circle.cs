using UnityEngine;

public class Circle : Shape
{

    private bool doubleJumpUnlocked = true;
    private bool hasDoubleJumped = false;

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Circle");
        stats = new ShapeStats(50, 50, 50);
    }

    public override void HandlePassiveSkill()
    {
        if (ShouldDoubleJump())
        {
            hasDoubleJumped = true;
            StartCoroutine(playerController.playerMovement.JumpCoroutine());
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
        hasDoubleJumped = false;
    }

    public override bool IsBlockingSkillActive()
    {
        // TODO: Implement blocking skill
        return false;
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Circle>());
    }

    private bool ShouldDoubleJump()
    {
        bool canMove = playerController.playerMovement.CanMove();
        bool isUpPressed = playerController.playerInput.isUpPressed;
        bool isInAir = playerController.playerMovement.isInAir;
        return canMove && isUpPressed && isInAir && doubleJumpUnlocked && !hasDoubleJumped;
    }
}