using GatorDragonGames.JigglePhysics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    [SerializeField] GameObject instantiationPlayer;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Camera camera;


    bool moving = false;
    Vector3 goHere;
    [SerializeField] float smoothSpeed;
    RaycastHit hit;
    Rigidbody rb;
    float deathTimer = 0;
    bool dead = false;
    

    void Start()
    {
        camera = FindAnyObjectByType<Camera>();
        camera.GetComponent<CameraScript>().target = gameObject.transform;
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        rb = GetComponent<Rigidbody>();
    }

    public void OnForward(InputAction.CallbackContext cxt)
    {
        if (dead == false)
        {
            if (cxt.started)
            {
                if (moving == false)
                {
                    goHere = transform.position + transform.forward * jumpLength;
                    moving = true;
                    animator.SetTrigger("Jump");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Dead();
        }

    }

    public void Update()
    {
        if (moving == false)
        {
            movementIndicator.transform.position = new Vector3(transform.position.x, movementIndicator.transform.position.y, transform.position.z) + transform.forward * jumpLength;

            Physics.Raycast(transform.position, Vector3.down, out hit);
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Log")
            {
                transform.SetParent(hit.transform);
            }

            if (hit.collider.tag == "Water")
            {
                Dead();
            }

            if (dead == true)
            {
                deathTimer += Time.deltaTime;
            }

            if (deathTimer > 2)
            {
                Respawn();
            }


        }

        if (moving == true)
        {
            transform.position = Vector3.Lerp(transform.position, goHere, smoothSpeed);
            if (Vector3.Distance(transform.position, goHere) < 0.2)
            {
                moving = false;
            }

            transform.SetParent(null);
        }
    }
    public void FixedUpdate()
    {
        if (moving == false && dead == false)
        {
            transform.Rotate(0, 2, 0);
        }
    }


    public void Dead()
    {

        JiggleRigData data = gameObject.GetComponentInChildren<JiggleRig>().GetJiggleRigData();

        JiggleTreeInputParameters per = data.jiggleTreeInputParameters;

        per.stiffness.value = 0f;
        per.soften = 1f;

        gameObject.GetComponentInChildren<JiggleRig>().SetInputParameters(per);

        dead = true;
        rb.isKinematic = false;
        movementIndicator.SetActive(false);
    }
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Instantiate(instantiationPlayer, spawnPoint);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
    }
}
