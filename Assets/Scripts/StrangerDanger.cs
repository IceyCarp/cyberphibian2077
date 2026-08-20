using UnityEngine;

public class StrangerDanger : MonoBehaviour
{
    public bool moveLeft;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("SuperMegaDeath"))
        {
            Destroy(this);
        }
    }
}
