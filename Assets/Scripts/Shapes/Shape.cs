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

    internal ShapeType type;
    internal Sprite sprite;

    public abstract void LoadSprite();

    public abstract void ActivateMovementSkill(PlayerController playerController);

    public abstract void ActivateActionSkill();

    public abstract void DestroyShape();
}