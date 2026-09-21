using GatorDragonGames.JigglePhysics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int jumpLength;

    [Header("Components")]
    [SerializeField] PlayerInput input;
    [SerializeField] private Transform playerTransform;
    [SerializeField] Animator animator;
    [SerializeField] GameObject movementIndicator;
    bool moving = false;
    Vector3 goHere;
    [SerializeField] float smoothSpeed;

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
            //playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + jumpLength);
            //playerTransform.position = transform.position + transform.forward * jumpLength;
            goHere = transform.position + transform.forward * jumpLength;
            moving = true;
            animator.SetTrigger("Jump");
        }
    }

    /*public void OnBackwards(InputAction.CallbackContext cxt)
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
    }*/

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
        if (moving == false)
        {
            movementIndicator.transform.position = new Vector3(transform.position.x, movementIndicator.transform.position.y,transform.position.z) + transform.forward * jumpLength;
        }

        if (moving == true)
        {
            transform.position = Vector3.Lerp(transform.position, goHere, smoothSpeed);
            if (Vector3.Distance(transform.position, goHere) < 1)
            {
                moving = false;
            }
        }
    }
    public void FixedUpdate()
    {
        if (moving == false)
        {
            transform.Rotate(0, 2, 0);
        }
    }
}
