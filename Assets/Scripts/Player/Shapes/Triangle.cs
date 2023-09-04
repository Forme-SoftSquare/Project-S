using System.Collections;
using UnityEngine;

public class Triangle : Shape
{

    private readonly float dashForce = 80f;
    private readonly float dashDuration = 0.15f;

    private bool hasDashedInAir = false;
    private bool isDashActive = false;

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Triangle");
        stats = new ShapeStats(80, 20, 100);
    }

    public override void HandlePassiveSkill()
    {
        // TODO: Implement passive skill
    }

    public override void HandleMovementSkill()
    {
        bool canMove = playerController.playerMovement.CanMove();
        bool isMovementSkillPressed = playerController.playerInput.isMovementSkillPressed;

        if (canMove && isMovementSkillPressed && !hasDashedInAir)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    public override void HandleActionSkill()
    {
        // TODO: Implement action skill
    }

    public override void ResetOnCollision()
    {
        hasDashedInAir = false;
        isDashActive = false;
    }

    public override bool IsBlockingSkillActive()
    {
        return isDashActive;
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Triangle>());
    }

    private void Dash()
    {
        isDashActive = true;

        // Determine the current horizontal direction the player is facing (either Left or Right)
        Direction horizontalDirection = playerController.playerMovement.direction;

        // Check if the 'up' input is currently pressed
        bool isUpHeld = playerController.playerInput.isUpHeld;

        // Applying visual effects for dashing
        playerController.spriteRenderer.color = Color.red;           // Change player color to red for the dash duration
        playerController.trailRenderer.emitting = true;              // Turn on the trail renderer to show a "dash trail"

        // Determine the horizontal multiplier based on the player's direction
        int horizontalMultiplier = (horizontalDirection == Direction.Left) ? -1 : 1;

        // Determine the dash direction
        Vector2 dashDirection = Vector2.right * horizontalMultiplier;

        // If 'up' is held, adjust the dash direction diagonally
        if (isUpHeld)
        {
            dashDirection += Vector2.up;
            dashDirection.Normalize();
        }

        // Apply the dash velocity to the player's Rigidbody
        playerController.rb.velocity = dashDirection * dashForce;
    }

    private void ClearDash()
    {
        // Reset the visual effects after dashing
        playerController.spriteRenderer.color = Color.blue;  // Reset player color back to blue after dashing
        playerController.trailRenderer.emitting = false;     // Turn off the trail renderer

        // Set the movement skill flag to false, indicating that the dash has ended
        isDashActive = false;

        // Check if the player was jumping while dashing, and set a flag if true
        if (playerController.playerMovement.isInAir)
        {
            hasDashedInAir = true;
        }
    }

    private IEnumerator DashCoroutine()
    {
        Dash();

        // Wait for a set duration (dashDuration) before ending the dash
        yield return new WaitForSeconds(dashDuration);

        ClearDash();
    }
}