using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    internal bool isLeftHeld;
    internal bool isRightHeld;
    internal bool isUpHeld;
    internal bool isUpPressed;
    internal bool isDownHeld;

    internal bool isAlpha1Pressed;
    internal bool isAlpha2Pressed;
    internal bool isAlpha3Pressed;
    internal bool isAlpha4Pressed;
    internal bool isAlpha5Pressed;

    internal bool isMovementSkillPressed;

    // Update is called once per frame
    void Update()
    {
        isLeftHeld = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isRightHeld = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        isUpHeld = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
        isUpPressed = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space);
        isDownHeld = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        isAlpha1Pressed = Input.GetKeyDown(KeyCode.Alpha1);
        isAlpha2Pressed = Input.GetKeyDown(KeyCode.Alpha2);
        isAlpha3Pressed = Input.GetKeyDown(KeyCode.Alpha3);
        isAlpha4Pressed = Input.GetKeyDown(KeyCode.Alpha4);
        isAlpha5Pressed = Input.GetKeyDown(KeyCode.Alpha5);

        isMovementSkillPressed = Input.GetKeyDown(KeyCode.Q);
    }
}
