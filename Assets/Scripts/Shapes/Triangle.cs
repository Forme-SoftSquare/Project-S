using System.Collections;
using UnityEngine;

public class Triangle : Shape
{

    private float dashForce = 60f;
    private float dashDuration = 0.15f;

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Triangle");
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {
        StartCoroutine(Dash(playerController));
    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Triangle>());
    }

    private IEnumerator Dash(PlayerController playerController)
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

        playerController.playerMovement.isMovementSkillActive = false;
    }
}