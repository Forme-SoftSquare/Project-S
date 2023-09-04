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
    internal ShapeStats stats;

    // Initialize the shape (mandatory to call just after shape creation)
    public abstract void Initialize(PlayerController playerController);

    // Check if the player can use his passive skill and then use it
    public abstract void HandlePassiveSkill();

    // Check if the player can use his movement skill and then use it
    public abstract void HandleMovementSkill();

    // Check if the player can use his action skill and then use it
    public abstract void HandleActionSkill();

    // Reset skills variables on collision with ground or wall
    public abstract void ResetOnCollision();

    // Destroy the current shape component
    public abstract void DestroyShape();

    // Check if the player is using a blocking skill (impossible to change shape, move and use other skills)
    public abstract bool IsBlockingSkillActive();
}