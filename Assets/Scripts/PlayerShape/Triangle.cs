using UnityEngine;

public class Triangle : PlayerShape
{

    private Sprite sprite;

    public override void Start()
    {
        sprite = Resources.Load<Sprite>("Sprites/PlayerShape/Triangle");
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