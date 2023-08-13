using UnityEngine;
using UnityEngine.AddressableAssets;

public class Triangle : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Triangle.png").WaitForCompletion();
        if (sprite == null)
        {
            Debug.LogError("Failed to load Triangle Sprite!");
        }
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Triangle>());
    }
}