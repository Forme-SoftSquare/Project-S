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

    protected SpriteRenderer spriteRenderer;
    public PlayerShapeType shapeType;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected abstract void LoadSprite();

    public abstract void MovementSkill();

    public abstract void ActionSkill();


    public void ChangeShape(PlayerShapeType newShapeType)
    {
        // If the new shape is the same as the current shape, do nothing
        if (newShapeType == shapeType) return;

        // Destroy the current player shape (if it already exists)
        DestroyShape();

        // Add the new shape based on the given ShapeType
        switch (newShapeType)
        {
            case PlayerShapeType.Circle:
                gameObject.AddComponent<Circle>();
                shapeType = PlayerShapeType.Circle;
                break;
            case PlayerShapeType.Square:
                gameObject.AddComponent<Square>();
                shapeType = PlayerShapeType.Square;
                break;
            case PlayerShapeType.Triangle:
                gameObject.AddComponent<Triangle>();
                shapeType = PlayerShapeType.Triangle;
                break;
            case PlayerShapeType.Pentagon:
                gameObject.AddComponent<Pentagon>();
                shapeType = PlayerShapeType.Pentagon;
                break;
            case PlayerShapeType.Hexagon:
                gameObject.AddComponent<Hexagon>();
                shapeType = PlayerShapeType.Hexagon;
                break;
            default:
                throw new System.Exception("Invalid shape type");
        }

        // Load the sprite for the new shape
        LoadSprite();
    }

    private void DestroyShape()
    {
        Destroy(gameObject);
    }
}