using UnityEngine;

public class PlayerController : MonoBehaviour
{

    internal PlayerShape playerShape;
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerCollision playerCollision;
    internal PlayerStats playerStats;

    internal SpriteRenderer spriteRenderer;
    internal Rigidbody2D rb;
    internal TrailRenderer trailRenderer;

    // Awake is called before Start functions
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();

        playerShape = GetComponent<PlayerShape>();
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollision = GetComponent<PlayerCollision>();
        playerStats = GetComponent<PlayerStats>();
    }
}
