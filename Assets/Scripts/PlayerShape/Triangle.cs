using UnityEngine;

public class Triangle : PlayerShape
{

    private Sprite triangleSprite;

    protected override void LoadSprite()
    {
        triangleSprite = Resources.Load<Sprite>("Sprites/PlayerShape/Triangle");
        if (triangleSprite == null)
        {
            Debug.LogError("Failed to load Triangle Sprite!");
        }
        else
        {
            // Set new sprite to the sprite renderer
            GetComponent<SpriteRenderer>().sprite = triangleSprite;
        }
    }

    protected override void DestroyShape()
    {
        Destroy(GetComponent<Triangle>());
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}