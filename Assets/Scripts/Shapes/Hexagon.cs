using UnityEngine;

public class Hexagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Hexagon");
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
}