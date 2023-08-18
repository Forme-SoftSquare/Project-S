using UnityEngine;

public class Hexagon : Shape
{

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Hexagon");
    }

    public override void ActivateMovementSkill()
    {

    }

    public override void ActivateActionSkill()
    {

    }

    public override void ResetOnGround()
    {
        ClearSkills();
    }

    public override void DestroyShape()
    {
        Destroy(gameObject.GetComponent<Hexagon>());
    }
}