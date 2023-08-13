using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    internal float moveSpeed;
    internal float jumpForce;
    internal bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        jumpForce = 40f;
        isJumping = false;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Horizontal movements
        if (playerController.playerInput.isLeftPressed)
        {
            MovePlayerRight();
        }
        else if (playerController.playerInput.isRightPressed)
        {
            MovePlayerLeft();
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
    }

    private void MovePlayerRight()
    {
        playerController.rb.AddForce(new Vector2(-1f * moveSpeed, 0f), ForceMode2D.Impulse);
    }

    private void MovePlayerLeft()
    {
        playerController.rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);
    }

    private void Jump()
    {
        playerController.rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void Descend()
    {
        playerController.rb.AddForce(new Vector2(0f, -1f * jumpForce), ForceMode2D.Impulse);
    }
}
