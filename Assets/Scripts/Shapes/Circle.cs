using UnityEngine;
using UnityEngine.AddressableAssets;

public class Circle : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Circle.png").WaitForCompletion();
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {
        
    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Circle>());
    }
}