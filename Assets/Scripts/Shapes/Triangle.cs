using UnityEngine;
using UnityEngine.AddressableAssets;

public class Triangle : Shape
{

    private float dashForce = 100f;

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Triangle.png").WaitForCompletion();
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {
        Dash(playerController);
    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Triangle>());
    }

    private void Dash(PlayerController playerController)
    {
        Direction direction = playerController.playerMovement.direction;
        Vector2 dashDirection = (direction == Direction.Left) ? Vector2.left : Vector2.right;

        playerController.rb.velocity = dashDirection * dashForce;
    }
}