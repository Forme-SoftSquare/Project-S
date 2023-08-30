using UnityEngine;
using System.Collections;

public enum Direction { Left, Right }

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb;

    internal Direction direction;
    internal float jumpForce;
    internal bool isInAir;

    private bool isJumpActive;
    private float jumpDuration;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = playerController.rb;

        direction = Direction.Right;
        jumpForce = 50f;
        isInAir = false;

        isJumpActive = false;
        jumpDuration = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanNotMove()) return;

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
        if (playerController.playerInput.isUpPressed && !isInAir)
        {
            HandleJump();
        }
        else if (playerController.playerInput.isUpReleased && rb.velocity.y > 0f)
        {
            ApplyJumpReleaseVelocity();
        }
    }

    private void MovePlayerRight()
    {
        int speed = playerController.playerShape.shape.stats.moveSpeed;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        direction = Direction.Right;
    }

    private void MovePlayerLeft()
    {
        int speed = playerController.playerShape.shape.stats.moveSpeed;
        rb.velocity = new Vector2(-1f * speed, rb.velocity.y);
        direction = Direction.Left;
    }

    private void HandleJump()
    {
        if (!playerController.playerInput.isUpPressed || isInAir) return;

        if (playerController.playerCollision.ShouldWallJump())
        {
            StartCoroutine(WallJumpCoroutine());
        }
        else
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    private void Jump()
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

    public IEnumerator JumpCoroutine()
    {
        isJumpActive = true;
        Jump();

        // add a small delay before allowing the player to jump again
        yield return new WaitForSeconds(jumpDuration);
        isJumpActive = false;
    }

    private IEnumerator WallJumpCoroutine()
    {
        Vector2 wallDirection = playerController.playerCollision.GetWallDirectionVector();

        isJumpActive = true;
        WallJump(wallDirection);
        
        // add a small delay before allowing the player to jump again
        yield return new WaitForSeconds(jumpDuration);
        isJumpActive = false;
    }

    private void ApplyJumpReleaseVelocity()
    {
        float jumpDeceleration = 0.5f;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpDeceleration);
    }

    private bool CanNotMove()
    {
        bool isSkillActive = playerController.playerShape.shape.IsSkillActive();
        return isSkillActive || isJumpActive;
    }
}
