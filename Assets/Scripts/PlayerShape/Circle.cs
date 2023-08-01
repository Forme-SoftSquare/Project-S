using UnityEngine;

public class Circle : PlayerShape
{

    private Sprite circleSprite;

    protected override void LoadSprite()
    {
        circleSprite = Resources.Load<Sprite>("Sprites/PlayerShape/Circle");
        if (circleSprite == null)
        {
            Debug.LogError("Failed to load Circle Sprite!");
        }
        else
        {
            // Set new sprite to the sprite renderer
            GetComponent<SpriteRenderer>().sprite = circleSprite;
        }
    }

    protected override void DestroyShape()
    {
        Destroy(GetComponent<Circle>());
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}