using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] float spawnSpeed;
    [SerializeField] bool moveLeft;
    [SerializeField] float obstacleSpeed;
    float spawnFeet;
    GameObject instantiatedObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instantiatedObject = Instantiate(obstacle);
        instantiatedObject.GetComponent<StrangerDanger>().moveLeft = moveLeft;
        instantiatedObject.GetComponent<StrangerDanger>().speed = obstacleSpeed;
        spawnFeet = spawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnFeet <= 0)
        {
            Instantiate(instantiatedObject, this.transform.position, this.transform.rotation);
            spawnFeet = spawnSpeed;
        }
        else
        {
            spawnFeet = spawnFeet - 1 * Time.deltaTime;
        }

        
    }
}
