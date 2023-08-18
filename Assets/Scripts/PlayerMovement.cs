using UnityEngine;

public enum Direction { Left, Right }

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb;

    internal Direction direction;
    internal float moveSpeed;
    internal float jumpForce;
    internal bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = playerController.rb;

        direction = Direction.Right;
        moveSpeed = 15f;
        jumpForce = 50f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
        HandleDoubleJump();
        HandleMovementSkill();
    }

    private void HandleHorizontalMovement()
    {
        if (playerController.playerShape.shape.isMovementSkillActive) return;

        if (playerController.playerInput.isLeftHeld)
        {
            MovePlayerLeft();
        }
        else if (playerController.playerInput.isRightHeld)
        {
            MovePlayerRight();
        }
    }

    private void HandleVerticalMovement()
    {
        if (playerController.playerInput.isUpPressed && !isJumping)
        {
            Jump();
        }
        else if (playerController.playerInput.isUpReleased && rb.velocity.y > 0f)
        {
            ApplyJumpReleaseVelocity();
        }
        else if (playerController.playerInput.isDownHeld && isJumping)
        {
            Descend();
        }
    }

    private void MovePlayerRight()
    {
        playerController.rb.velocity = new Vector2(moveSpeed, playerController.rb.velocity.y);
        direction = Direction.Right;
    }

    private void MovePlayerLeft()
    {
        playerController.rb.velocity = new Vector2(-1f * moveSpeed, playerController.rb.velocity.y);
        direction = Direction.Left;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void ApplyJumpReleaseVelocity()
    {
        float jumpDeceleration = 0.5f;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpDeceleration);
    }

    private void Descend()
    {
        rb.velocity = new Vector2(rb.velocity.x, -1f * jumpForce);
    }

    private void HandleDoubleJump()
    {
        if (playerController.playerInput.isUpPressed && playerController.playerPassiveSkills.CanDoubleJump())
        {
            playerController.playerPassiveSkills.hasDoubleJumped = true;
            Jump();
        }
    }

    private void HandleMovementSkill()
    {
        if (playerController.playerInput.isMovementSkillPressed && !playerController.playerShape.shape.isMovementSkillActive)
        {
            playerController.playerShape.shape.isMovementSkillActive = true;
            playerController.playerShape.shape.ActivateMovementSkill();
        }
    }
}
