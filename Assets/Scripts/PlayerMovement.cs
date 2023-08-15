using UnityEngine;

public enum Direction { Left, Right }

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;

    internal Direction direction;

    internal float moveSpeed;
    internal float jumpForce;
    internal bool isJumping;
    internal bool isMovementSkillActive;
    internal bool hasDoubleJumped;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        direction = Direction.Right;

        moveSpeed = 10f;
        jumpForce = 50f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movements
        if (playerController.playerInput.isLeftHeld)
        {
            MovePlayerLeft();
        }
        else if (playerController.playerInput.isRightHeld)
        {
            MovePlayerRight();
        }

        // Vertical movements
        if (playerController.playerInput.isUpPressed && !isJumping)
        {
            Jump();
        }
        if (playerController.playerInput.isUpReleased && playerController.rb.velocity.y > 0f)
        {
            ApplyJumpReleaseVelocity();
        }
        if (playerController.playerInput.isDownHeld && isJumping)
        {
            Descend();
        }

        // Double jump
        if (playerController.playerInput.isUpPressed && playerController.playerPassiveSkills.CanDoubleJump())
        {
            playerController.playerPassiveSkills.hasDoubleJumped = true;
            Jump();
        }

        // Player skills
        if (playerController.playerInput.isMovementSkillPressed && !isMovementSkillActive)
        {
            ActivateMovementSkill();
        }
    }

    private void MovePlayerRight()
    {
        if (isMovementSkillActive) return;
        playerController.rb.velocity = new Vector2(moveSpeed, playerController.rb.velocity.y);
        direction = Direction.Right;
    }

    private void MovePlayerLeft()
    {
        if (isMovementSkillActive) return;
        playerController.rb.velocity = new Vector2(-1f * moveSpeed, playerController.rb.velocity.y);
        direction = Direction.Left;
    }

    private void Jump()
    {
        playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, jumpForce);
    }

    private void ApplyJumpReleaseVelocity()
    {
        float jumpDeceleration = 0.5f;
        playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, playerController.rb.velocity.y * jumpDeceleration);
    }

    private void Descend()
    {
        playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, -1f * jumpForce);
    }

    private void ActivateMovementSkill()
    {
        isMovementSkillActive = true;
        playerController.playerShape.shape.ActivateMovementSkill(playerController);
    }
}