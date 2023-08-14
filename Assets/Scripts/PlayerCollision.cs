using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collides with a platform, set isJumping to false
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.playerMovement.isJumping = false;
            ResetAerialSkills();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If player exits a platform, set isJumping to true
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.playerMovement.isJumping = true;
        }
    }

    private void ResetAerialSkills()
    {
        playerController.playerMovement.isMovementSkillActive = false;
    }
}
