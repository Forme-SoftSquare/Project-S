using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;

    internal bool isAlpha1Pressed;
    internal bool isAlpha2Pressed;
    internal bool isAlpha3Pressed;
    internal bool isAlpha4Pressed;
    internal bool isAlpha5Pressed;

    internal bool isMovementSkillPressed;

    // Update is called once per frame
    void Update()
    {
        isLeftPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isRightPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        isUpPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
        isDownPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        isAlpha1Pressed = Input.GetKeyDown(KeyCode.Alpha1);
        isAlpha2Pressed = Input.GetKeyDown(KeyCode.Alpha2);
        isAlpha3Pressed = Input.GetKeyDown(KeyCode.Alpha3);
        isAlpha4Pressed = Input.GetKeyDown(KeyCode.Alpha4);
        isAlpha5Pressed = Input.GetKeyDown(KeyCode.Alpha5);

        isMovementSkillPressed = Input.GetKeyDown(KeyCode.Q);
    }
}
