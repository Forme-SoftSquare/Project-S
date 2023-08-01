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
    public abstract void MovementSkill();

    public abstract void ActionSkill();
}