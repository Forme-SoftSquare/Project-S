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
        Direction direction = playerController.playerMovement.direction;

        // Apllying visual effects
        playerController.spriteRenderer.color = Color.red;
        playerController.trailRenderer.emitting = true;

        Vector2 dashDirection = (direction == Direction.Left) ? Vector2.left : Vector2.right;
        playerController.rb.velocity = dashDirection * dashForce;

        // Wait for the dash to end
        yield return new WaitForSeconds(dashDuration);

        // Resetting visual effects
        playerController.spriteRenderer.color = Color.blue;
        playerController.trailRenderer.emitting = false;
        
        isMovementSkillActive = false;

        if (playerController.playerMovement.isJumping)
        {
            hasDashedInAir = true;
        }
    }
}