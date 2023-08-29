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
        if (playerController.playerShape.shape.isMovementSkillActive) return;

        HandleHorizontalMovement();
        HandleVerticalMovement();
        playerController.playerShape.shape.HandlePassiveSkill();
        playerController.playerShape.shape.HandleMovementSkill();
    }

    private void HandleHorizontalMovement()
    {
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
            HandleJump();
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
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        direction = Direction.Right;
    }

    private void MovePlayerLeft()
    {
        rb.velocity = new Vector2(-1f * moveSpeed, rb.velocity.y);
        direction = Direction.Left;
    }

    private void HandleJump()
    {
        if (!playerController.playerCollision.ShouldWallJump())
        {
            Jump();
        }
        else if (playerController.playerCollision.isTouchingRightWall)
        {
            WallJump(Vector2.right);
        }
        else if (playerController.playerCollision.isTouchingLeftWall)
        {
            WallJump(Vector2.left);
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void WallJump(Vector2 wallDirection)
    {
        Vector2 upVector = Vector2.up;

        // Combine the wall normal vector with the up vector to get a diagonal upward jump direction
        Vector2 jumpDirection = (wallDirection + upVector).normalized;

        // Apply a jump force in the diagonal jump direction
        rb.velocity = jumpDirection * jumpForce;
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
}
