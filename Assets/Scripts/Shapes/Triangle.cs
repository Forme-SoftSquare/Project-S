using System.Collections;
using UnityEngine;

public class Triangle : Shape
{

    private readonly float dashForce = 80f;
    private readonly float dashDuration = 0.15f;

    private bool hasDashedInAir = false;

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Triangle");
    }

    public override void HandlePassiveSkill()
    {
        // TODO: Implement passive skill
    }

    public override void HandleMovementSkill()
    {
        if (playerController.playerInput.isMovementSkillPressed && !isMovementSkillActive && !hasDashedInAir)
        {
            isMovementSkillActive = true;
            StartCoroutine(Dash());
        }
    }

    public override void HandleActionSkill()
    {
        // TODO: Implement action skill
    }

    public override void ResetOnGround()
    {
        ClearSkills();
        hasDashedInAir = false;
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Triangle>());
    }

    private IEnumerator Dash()
    {
        // Determine the current horizontal direction the player is facing (either Left or Right)
        Direction horizontalDirection = playerController.playerMovement.direction;

        // Check if the 'up' input is currently pressed
        bool isUpHeld = playerController.playerInput.isUpHeld;

        // Applying visual effects for dashing
        playerController.spriteRenderer.color = Color.red;           // Change player color to red for the dash duration
        playerController.trailRenderer.emitting = true;              // Turn on the trail renderer to show a "dash trail"

        Vector2 dashDirection;

        // Determine the dash direction based on the player's current horizontal direction and if 'up' is being pressed
        if (horizontalDirection == Direction.Left)
        {
            // If the player is facing left and pressing 'up', they will dash diagonally upwards to the left
            // Otherwise, they'll dash straight to the left
            dashDirection = isUpHeld ? new Vector2(-1, 1).normalized : Vector2.left;
        }
        else // If horizontalDirection is Right
        {
            // If the player is facing right and pressing 'up', they will dash diagonally upwards to the right
            // Otherwise, they'll dash straight to the right
            dashDirection = isUpHeld ? new Vector2(1, 1).normalized : Vector2.right;
        }

        // Apply the dash velocity to the player's Rigidbody
        playerController.rb.velocity = dashDirection * dashForce;

        // Wait for a set duration (dashDuration) before ending the dash
        yield return new WaitForSeconds(dashDuration);

        // Reset the visual effects after dashing
        playerController.spriteRenderer.color = Color.blue;          // Reset player color back to blue after dashing
        playerController.trailRenderer.emitting = false;             // Turn off the trail renderer

        // Set the movement skill flag to false, indicating that the dash has ended
        isMovementSkillActive = false;

        // Check if the player was jumping while dashing, and set a flag if true
        if (playerController.playerMovement.isJumping)
        {
            hasDashedInAir = true;
        }
    }
}