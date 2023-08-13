using UnityEngine;

public class Triangle : Shape
{
    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Triangle");
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
}