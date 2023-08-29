using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private PlayerController playerController;

    internal bool isTouchingLeftWall;
    internal bool isTouchingRightWall;
    internal bool isGrounded;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        isTouchingLeftWall = false;
        isTouchingRightWall = false;
        isGrounded = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool isTagPlatform = CompareTag(collision, "Platform");
        bool isTagWall = CompareTag(collision, "Wall");

        if (isTagPlatform) isGrounded = true;

        if (isTagWall)
        {
            if (IsPlayerOnLeftSideOfWall(collision)) isTouchingLeftWall = true;
            else if (IsPlayerOnRightSideOfWall(collision)) isTouchingRightWall = true;
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

        if (isTagPlatform) isGrounded = false;

        if (isTagWall)
        {
            if (IsPlayerOnLeftSideOfWall(collision)) isTouchingLeftWall = false;
            else if (IsPlayerOnRightSideOfWall(collision)) isTouchingRightWall = false;
        }

        if ((isTagPlatform && !IsTouchingWall()) || (isTagWall && !isGrounded))
        {
            playerController.playerMovement.isJumping = true;
        }
    }

    private bool CompareTag(Collider2D collision, string tag)
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

    private bool IsTouchingWall()
    {
        return isTouchingLeftWall || isTouchingRightWall;
    }

    public bool ShouldWallJump()
    {
        return IsTouchingWall()  && !isGrounded;
    }
}
