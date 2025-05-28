using UnityEngine;

public class Pellet : MonoBehaviour

{
    public Rigidbody body;

    public float TravelDistance;
    public float TravelSpeed;  
    Vector3 SpawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPos = transform.position;
        body.linearVelocity = transform.up * TravelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //if the bullet has moved the maximum distance run the following
        if (Vector3.Distance(SpawnPos, transform.position) > TravelDistance)
        {
            Destroy(gameObject);
        }
    }
}
