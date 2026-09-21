using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int jumpLength;

    [Header("Components")]
    [SerializeField] PlayerInput input;
    [SerializeField] private Transform playerTransform;
    [SerializeField] Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void OnForward(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + jumpLength);
            animator.SetTrigger("Jump");
        }
    }

    public void OnBackwards(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - jumpLength);
            animator.SetTrigger("Jump");
        }
    }

    public void OnRight(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x + jumpLength, playerTransform.position.y, playerTransform.position.z);
            animator.SetTrigger("Jump");
        }
    }

    public void OnLeft(InputAction.CallbackContext cxt)
    {
        if (cxt.started)
        {
            playerTransform.position = new Vector3(playerTransform.position.x - jumpLength, playerTransform.position.y, playerTransform.position.z);
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Log") && this.transform.position.z > 2)
        {
            Debug.Log("LOG");
        }
        else if (!collision.gameObject.CompareTag("Log") && this.transform.position.z > 2)
        {
            Debug.Log("DEAD");
        }
    }

    public void Update()
    {
        transform.Rotate(0, 3, 0);
    }

    public void FixedUpate()
    {
        transform.Rotate(0, 3, 0);
    }
}
