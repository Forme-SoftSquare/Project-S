using UnityEngine;

public class Pentagon : Shape
{

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Pentagon");
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
        Destroy(gameObject.GetComponent<Pentagon>());
    }
}