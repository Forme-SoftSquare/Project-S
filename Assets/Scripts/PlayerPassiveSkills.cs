using UnityEngine;

public class PlayerPassiveSkills : MonoBehaviour
{

    private PlayerController playerController;

    private bool hasDoubleJump;
    internal bool hasDoubleJumped;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        hasDoubleJump = true;
        hasDoubleJumped = false;
    }

    public bool CanDoubleJump()
    {
        bool isCircle = playerController.playerShape.IsShape(ShapeType.Circle);
        bool isJumping = playerController.playerMovement.isJumping;
        return hasDoubleJump && isCircle && isJumping && !hasDoubleJumped;
    }

    public void ResetAerialPassiveSkills()
    {
        hasDoubleJumped = false;
    }
}
