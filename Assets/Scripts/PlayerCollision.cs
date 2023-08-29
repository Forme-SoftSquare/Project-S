using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private PlayerController playerController;

    // var to know if player touch a wall and he is not on the ground
    internal bool isTouchingWall;
    internal bool isGrounded;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool isTagPlatform = CompareTag(collision, "Platform");
        bool isTagWall = CompareTag(collision, "Wall");

        if (isTagPlatform)
        {
            playerController.playerMovement.isGrounded = true;
        }
        if (isTagWall)
        {
            playerController.playerMovement.isTouchingWall = true;
        }

        if (isTagPlatform || isTagWall)
        {
            playerController.playerMovement.isJumping = false;
            playerController.playerShape.shape.ResetOnCollision();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        bool isTagPlatform = CompareTag(collision, "Platform");
        bool isTagWall = CompareTag(collision, "Wall");

        if (isTagPlatform)
        {
            playerController.playerMovement.isGrounded = false;
        }
        if (isTagWall)
        {
            playerController.playerMovement.isTouchingWall = false;
        }
    

        if (isTagPlatform || isTagWall)
        {
            playerController.playerMovement.isJumping = true;
        }
    }

    private CompareTag(Collider2D collision, string tag)
    {
        return collision.gameObject.CompareTag(tag);
    }

    public bool IsPlayerOnLeftSideOfWall(Collider2D collision)
    {
        return transform.position.x < collision.transform.position.x;
    }

    public bool IsPlayerOnRightSideOfWall(Collider2D collision)
    {
        return transform.position.x > collision.transform.position.x;
    }

    public bool ShouldWallJump()
    {
        return isTouchingWall && !isGrounded;
    }
}
