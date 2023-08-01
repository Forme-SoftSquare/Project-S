using UnityEngine;

public class Hexagon : PlayerShape
{

    private Sprite hexagonSprite;

    protected override void LoadSprite()
    {
        hexagonSprite = Resources.Load<Sprite>("Sprites/PlayerShape/Hexagon");
        if (hexagonSprite == null)
        {
            Debug.LogError("Failed to load Hexagon Sprite!");
        }
        else
        {
            // Set new sprite to the sprite renderer
            base.spriteRenderer.sprite = hexagonSprite;
        }
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}