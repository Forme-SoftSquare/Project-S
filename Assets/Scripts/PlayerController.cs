using UnityEngine;

public class PlayerController : MonoBehaviour
{

    internal PlayerShape playerShape;
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerCollision playerCollision;
    internal PlayerPassiveSkills playerPassiveSkills;

    internal SpriteRenderer spriteRenderer;
    internal Rigidbody2D rb;
    internal TrailRenderer trailRenderer;

    // Awake is called before Start functions
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        trailRenderer = gameObject.GetComponent<TrailRenderer>();

        playerShape = GetComponent<PlayerShape>();
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollision = GetComponent<PlayerCollision>();
        playerPassiveSkills = GetComponent<PlayerPassiveSkills>();
    }
}
