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
            GetComponent<SpriteRenderer>().sprite = squareSprite;
        }
    }

    protected override void DestroyShape()
    {
        Destroy(GetComponent<Square>());
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}