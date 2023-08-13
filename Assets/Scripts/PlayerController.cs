using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] internal PlayerShape playerShape;
    [SerializeField] internal PlayerInput playerInput;
    [SerializeField] internal PlayerMovement playerMovement;
    [SerializeField] internal PlayerCollision playerCollision;

    internal Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
