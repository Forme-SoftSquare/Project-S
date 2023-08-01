using UnityEngine;

public class Pentagon : PlayerShape
{

    private Sprite pentagonSprite;

    protected override void LoadSprite()
    {
        pentagonSprite = Resources.Load<Sprite>("Sprites/PlayerShape/Pentagon");
        if (pentagonSprite == null)
        {
            Debug.LogError("Failed to load Pentagon Sprite!");
        }
        else
        {
            // Set new sprite to the sprite renderer
            GetComponent<SpriteRenderer>().sprite = pentagonSprite;
        }
    }

    protected override void DestroyShape()
    {
        Destroy(GetComponent<Pentagon>());
    }

    public override void MovementSkill()
    {

    }

    public override void ActionSkill()
    {

    }
}