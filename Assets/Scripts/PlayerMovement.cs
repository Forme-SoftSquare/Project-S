using UnityEngine;

public enum Direction { None, Left, Right }

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    internal float moveSpeed;
    internal float jumpForce;
    internal bool isJumping;
    internal bool isMovementSkillActive;
    internal Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        jumpForce = 40f;
        isJumping = false;
        direction = Direction.None;
    }

    // FixedUpdate is called once per physics frame
    void Update()
    {
        // Horizontal movements
        if (playerController.playerInput.isLeftPressed)
        {
            MovePlayerLeft();
        }
        else if (playerController.playerInput.isRightPressed)
        {
            MovePlayerRight();
        }

        // Vertical movements
        if (playerController.playerInput.isUpPressed && !isJumping)
        {
            Jump();
        }
        if (playerController.playerInput.isDownPressed && isJumping)
        {
            Descend();
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