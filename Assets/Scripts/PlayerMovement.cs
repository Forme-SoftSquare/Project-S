using UnityEngine;

public enum Direction { Left, Right }

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    internal Direction direction;

    internal float moveSpeed;
    internal float jumpForce;
    internal bool isJumping;
    internal bool isMovementSkillActive;
    internal bool hasDoubleJumped;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Right;

        moveSpeed = 10f;
        jumpForce = 50f;
        isJumping = false;
        hasDoubleJumped = false;
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
            // Jump less high if player releases jump button
            float jumpDeceleration = 0.5f;
            playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, playerController.rb.velocity.y * jumpDeceleration);
        }
        if (playerController.playerInput.isDownHeld && isJumping)
        {
            Descend();
        }

        // Double jump
        bool isCircle = playerController.playerShape.shape.type == ShapeType.Circle;
        bool canDoubleJump = isCircle && isJumping && !hasDoubleJumped;
        if (playerController.playerInput.isUpPressed && canDoubleJump)
        {
            hasDoubleJumped = true;
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