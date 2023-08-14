using UnityEngine;

public enum Direction { None, Left, Right }

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
        direction = Direction.None;

        moveSpeed = 10f;
        jumpForce = 40f;
        isJumping = false;
        hasDoubleJumped = false;
    }

    // FixedUpdate is called once per physics frame
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
        if (playerController.playerInput.isUpHeld && !isJumping)
        {
            Jump();
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
            if (isJumping)
            {
                isMovementSkillActive = true;
            }

            ActivateMovementSkill();
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
        playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, jumpForce);
    }

    private void Descend()
    {
        playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, -1f * jumpForce);
    }

    private void ActivateMovementSkill()
    {
        playerController.playerShape.shape.ActivateMovementSkill(playerController);
    }
}