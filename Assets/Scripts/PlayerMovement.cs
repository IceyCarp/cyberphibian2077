using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int jumpLength;

    [Header("Components")]
    [SerializeField] PlayerInput input;
    [SerializeField] private Transform playerTransform;

    public void OnForward(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + jumpLength);
        }
    }

    public void OnBackwards(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - jumpLength);
        }
    }

    public void OnRight(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x + jumpLength, playerTransform.position.y, playerTransform.position.z);
        }
    }

    public void OnLeft(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x - jumpLength, playerTransform.position.y, playerTransform.position.z);
        }
    }
}
