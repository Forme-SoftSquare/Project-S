using UnityEngine;

public enum ShapeType
{
    Circle,
    Triangle,
    Square,
    Pentagon,
    Hexagon,
}

public abstract class Shape : MonoBehaviour
{
    protected PlayerController playerController;

    internal ShapeType type;
    internal Sprite sprite;

    internal bool isMovementSkillActive = false;
    internal bool isActionSkillActive = false;

    public abstract void Initialize(PlayerController playerController);

    public abstract void HandlePassiveSkill();

    public abstract void HandleMovementSkill();

    public abstract void HandleActionSkill();

    public abstract void ResetOnGround();

    public abstract void DestroyShape();

    protected void ClearSkills()
    {
        isMovementSkillActive = false;
        isActionSkillActive = false;
    }
}