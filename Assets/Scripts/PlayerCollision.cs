using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
                playerController.playerMovement.isJumping = false;
                playerController.playerShape.shape.ResetOnGround();
                break;

            case "Wall":
                // Handle wall collision logic
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
                playerController.playerMovement.isJumping = true;
                break;

            case "Wall":
                // Handle wall collision logic
                break;
        }
    }
}
