using UnityEngine;

public class Square : PlayerShape
{

    private Sprite sprite;

    public override void Start()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Square");
    }

    public override Sprite Sprite
    {
        get 
        {
            return sprite;
        }
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}