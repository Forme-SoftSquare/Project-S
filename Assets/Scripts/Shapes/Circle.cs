using UnityEngine;

public class Circle : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Circle");
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