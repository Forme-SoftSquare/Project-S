using UnityEngine;

public class Hexagon : Shape
{

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Hexagon");
        stats = new ShapeStats(40, 80, 80);
    }

    public override void HandlePassiveSkill()
    {
        // TODO: Implement passive skill
    }

    public override void HandleMovementSkill()
    {
        // TODO: Implement movement skill
    }

    public override void HandleActionSkill()
    {
        // TODO: Implement action skill
    }

    public override void ResetOnCollision()
    {
        // TODO: Implement reset on collision
    }

    public override bool IsBlockingSkillActive()
    {
        // TODO: Implement blocking skill
        return false;
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Hexagon>());
    }
}