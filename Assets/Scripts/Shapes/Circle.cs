using UnityEngine;

public class Circle : Shape
{

    public override void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        sprite = Resources.Load<Sprite>("Sprites/Shapes/Circle");
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
        Destroy(gameObject.GetComponent<Circle>());
    }
}