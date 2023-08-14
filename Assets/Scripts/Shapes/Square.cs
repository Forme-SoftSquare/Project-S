using UnityEngine;

public class Square : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Square");
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