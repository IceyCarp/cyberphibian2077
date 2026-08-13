using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int jumpLength;

    [Header("Components")]
    [SerializeField] PlayerInput input;
}
