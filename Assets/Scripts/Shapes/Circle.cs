using UnityEngine;
using UnityEngine.AddressableAssets;

public class Circle : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Circle.png").WaitForCompletion();
        if (sprite == null)
        {
            Debug.LogError("Failed to load Circle Sprite!");
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
        Destroy(gameObject.GetComponent<Circle>());
    }
}