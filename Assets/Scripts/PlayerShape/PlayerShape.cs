using UnityEngine;

public enum PlayerShapeType
{
    Circle,
    Triangle,
    Square,
    Pentagon,
    Hexagon,
}

public abstract class PlayerShape : MonoBehaviour
{

    public abstract Sprite Sprite { get; }

    public abstract void Start();

    public abstract void MovementSkill();

    public abstract void ActionSkill();
}