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

    // Update is called once per frame
    void Update()
    {
        isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
        isRightPressed = Input.GetKey(KeyCode.RightArrow);
        isUpPressed = Input.GetKey(KeyCode.UpArrow);
        isDownPressed = Input.GetKey(KeyCode.DownArrow);

        isAlpha1Pressed = Input.GetKeyDown(KeyCode.Alpha1);
        isAlpha2Pressed = Input.GetKeyDown(KeyCode.Alpha2);
        isAlpha3Pressed = Input.GetKeyDown(KeyCode.Alpha3);
        isAlpha4Pressed = Input.GetKeyDown(KeyCode.Alpha4);
        isAlpha5Pressed = Input.GetKeyDown(KeyCode.Alpha5);
    }
}
