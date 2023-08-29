using UnityEngine;

public class Circle : Shape
{

    private bool doubleJumpUnlocked = true;
    private bool hasDoubleJumped = false;

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Circle");
    }

    public override void HandlePassiveSkill()
    {
        bool isUpPressed = playerController.playerInput.isUpPressed;
        bool isJumping = playerController.playerMovement.isJumping;
        if (isUpPressed && isJumping && doubleJumpUnlocked && !hasDoubleJumped)
        {
            hasDoubleJumped = true;
            playerController.playerMovement.Jump();
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
        hasDoubleJumped = false;
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Circle>());
    }
}