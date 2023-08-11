using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;
        jumpForce = 60f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Left = -1, Right = 1, None = 0
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // Move the player if horizontal input is clicked
        if (moveHorizontal != 0)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0), ForceMode2D.Impulse);
        }

        // Jump the player if vertical input is clicked and player is not already jumping
        if (moveVertical > 0 && !isJumping)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collides with a platform, set isJumping to false
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If player exits a platform, set isJumping to true
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = true;
        }
    }
}
