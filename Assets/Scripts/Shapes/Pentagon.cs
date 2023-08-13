using UnityEngine;
using UnityEngine.AddressableAssets;

public class Pentagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/Shapes/Pentagon.png").WaitForCompletion();
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Pentagon>());
    }
}