using UnityEngine;
using UnityEngine.AddressableAssets;

public class Hexagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Hexagon.png").WaitForCompletion();
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {

    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Hexagon>());
    }
}