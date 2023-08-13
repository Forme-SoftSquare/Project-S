using UnityEngine;

public class PlayerShape : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    internal Shape shape;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeShape(ShapeType.Circle);
    }

    private void ChangeShape(ShapeType newShapeType)
    {
        // If the new shape is the same as the current shape, do nothing
        if (newShapeType == shape?.type) return;

        // Destroy the current player shape (if it already exists)
        DestroyShape();

        // Add the new shape based on the given ShapeType
        switch (newShapeType)
        {
            case ShapeType.Circle:
                shape = gameObject.AddComponent<Circle>();
                shape.type = ShapeType.Circle;
                break;
            case ShapeType.Square:
                shape = gameObject.AddComponent<Square>();
                shape.type = ShapeType.Square;
                break;
            case ShapeType.Triangle:
                shape = gameObject.AddComponent<Triangle>();
                shape.type = ShapeType.Triangle;
                break;
            case ShapeType.Pentagon:
                shape = gameObject.AddComponent<Pentagon>();
                shape.type = ShapeType.Pentagon;
                break;
            case ShapeType.Hexagon:
                shape = gameObject.AddComponent<Hexagon>();
                shape.type = ShapeType.Hexagon;
                break;
            default:
                throw new System.Exception("Invalid shape type");
        }


        // Load the sprite for the new shape
        shape.LoadSprite();

        // Set the sprite renderer's sprite to the new shape's sprite
        spriteRenderer.sprite = shape.sprite;
    }

    private void DestroyShape()
    {
        Destroy(gameObject);
    }
}
