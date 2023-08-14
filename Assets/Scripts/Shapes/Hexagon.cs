using UnityEngine;

public class Hexagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Hexagon");
    }

    public override void ActivateMovementSkill(PlayerController playerController)
    {

    }

    public override void ActivateActionSkill()
    {

    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Hexagon>());
    }
}