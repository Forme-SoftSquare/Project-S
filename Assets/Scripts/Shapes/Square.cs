using UnityEngine;

public class Square : Shape
{
    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Square");
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
}