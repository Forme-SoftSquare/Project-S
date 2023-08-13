using UnityEngine;

public class Circle : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Circle");
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
}