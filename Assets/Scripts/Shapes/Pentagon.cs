using UnityEngine;

public class Pentagon : Shape
{

    public override void LoadSprite()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Pentagon");
        if (sprite == null)
        {
            Debug.LogError("Failed to load Pentagon Sprite!");
        }
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}