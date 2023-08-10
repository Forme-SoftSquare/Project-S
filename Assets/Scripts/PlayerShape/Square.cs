using UnityEngine;

public class Square : PlayerShape
{

    private Sprite squareSprite;

    protected override void LoadSprite()
    {
        squareSprite = Resources.Load<Sprite>("Sprites/PlayerShape/Square");
        if (squareSprite == null)
        {
            Debug.LogError("Failed to load Square Sprite!");
        }
        else
        {
            // Set new sprite to the sprite renderer
            base.spriteRenderer.sprite = squareSprite;
        }
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}