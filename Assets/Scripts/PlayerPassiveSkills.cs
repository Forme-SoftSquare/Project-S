using UnityEngine;

public class PlayerPassiveSkills : MonoBehaviour
{

    private PlayerController playerController;

    private bool doubleJumpUnlocked;
    internal bool hasDoubleJumped;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        doubleJumpUnlocked = true;
        hasDoubleJumped = false;
    }

    public bool CanDoubleJump()
    {
        bool isCircle = playerController.playerShape.IsShape(ShapeType.Circle);
        bool isJumping = playerController.playerMovement.isJumping;
        return doubleJumpUnlocked && isCircle && isJumping && !hasDoubleJumped;
    }

    public void ResetAerialPassiveSkills()
    {
        hasDoubleJumped = false;
    }
}
