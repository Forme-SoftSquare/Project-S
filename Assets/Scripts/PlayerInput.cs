using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;

    // Update is called once per frame
    void Update()
    {
        isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
        isRightPressed = Input.GetKey(KeyCode.RightArrow);
        isUpPressed = Input.GetKey(KeyCode.UpArrow);
        isDownPressed = Input.GetKey(KeyCode.DownArrow);
    }
}
