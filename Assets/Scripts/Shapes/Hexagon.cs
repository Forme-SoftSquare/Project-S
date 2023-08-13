using UnityEngine;
using UnityEngine.AddressableAssets;

public class Hexagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Hexagon.png").WaitForCompletion();
        if (sprite == null)
        {
            Debug.LogError("Failed to load Hexagon Sprite!");
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
        Destroy(gameObject.GetComponent<Hexagon>());
    }
}