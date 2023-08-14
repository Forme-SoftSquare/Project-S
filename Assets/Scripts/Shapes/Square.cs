using UnityEngine;
using UnityEngine.AddressableAssets;

public class Square : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Square.png").WaitForCompletion();
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {

    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Square>());
    }
}