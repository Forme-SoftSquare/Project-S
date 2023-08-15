using UnityEngine;

public class Pentagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Pentagon");
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {

    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Pentagon>());
    }
}