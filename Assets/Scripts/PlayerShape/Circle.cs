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
            base.spriteRenderer.sprite = circleSprite;
        }
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}