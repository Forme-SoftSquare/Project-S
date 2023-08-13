using UnityEngine;
using UnityEngine.AddressableAssets;

public class Square : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Square.png").WaitForCompletion();
        if (sprite == null)
        {
            Debug.LogError("Failed to load Square Sprite!");
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
        Destroy(gameObject.GetComponent<Square>());
    }
}