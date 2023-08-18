using UnityEngine;

public class PlayerShape : MonoBehaviour
{

    private PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    internal Shape shape;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeShape(ShapeType.Circle);
    }

    void Update()
    {
        if (playerController.playerInput.isAlpha1Pressed)
        {
            ChangeShape(ShapeType.Circle);
        }
        else if (playerController.playerInput.isAlpha2Pressed)
        {
            ChangeShape(ShapeType.Triangle);
        }
        else if (playerController.playerInput.isAlpha3Pressed)
        {
            ChangeShape(ShapeType.Square);
        }
        else if (playerController.playerInput.isAlpha4Pressed)
        {
            ChangeShape(ShapeType.Pentagon);
        }
        else if (playerController.playerInput.isAlpha5Pressed)
        {
            ChangeShape(ShapeType.Hexagon);
        }
    }

    private void ChangeShape(ShapeType newShapeType)
    {
        // If the new shape is the same as the current shape, do nothing
        if (IsShape(newShapeType)) return;

        // Destroy the current player shape (if it already exists)
        shape?.DestroyShape();

        // Add the new shape based on the given ShapeType
        switch (newShapeType)
        {
            case ShapeType.Circle:
                shape = gameObject.AddComponent<Circle>();
                shape.type = ShapeType.Circle;
                break;
            case ShapeType.Triangle:
                shape = gameObject.AddComponent<Triangle>();
                shape.type = ShapeType.Triangle;
                break;
            case ShapeType.Square:
                shape = gameObject.AddComponent<Square>();
                shape.type = ShapeType.Square;
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

    public bool IsShape(ShapeType shapeType)
    {
        return shapeType == shape?.type;
    }
}
