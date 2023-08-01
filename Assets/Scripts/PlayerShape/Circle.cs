using UnityEngine;

public class Circle : PlayerShape
{

    private Sprite sprite;

    public override void Start()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Circle");
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