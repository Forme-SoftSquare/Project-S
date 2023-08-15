using UnityEngine;

public class PlayerController : MonoBehaviour
{

    internal PlayerShape playerShape;
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerCollision playerCollision;
    internal PlayerPassiveSkills playerPassiveSkills;

    internal Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        playerShape = GetComponent<PlayerShape>();
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollision = GetComponent<PlayerCollision>();
        playerPassiveSkills = GetComponent<PlayerPassiveSkills>();
    }
}
