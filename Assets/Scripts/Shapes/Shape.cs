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

    public abstract void MovementSkill();

    public abstract void ActionSkill();
}