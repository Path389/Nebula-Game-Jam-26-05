using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public GameObject Player;
    public SpriteRenderer Sprite;
    public CircleCollider2D CircleCollider;
    public float ResourcesHeld;

    private bool isPlayerInCloud = false;
    private float MaxResources;
    private float InventoryPercentage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets the maximum amount of resources to the amount the cloud starts with
        MaxResources = ResourcesHeld;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInCloud == true)
        {
            ResourceTaken();
        }
       
    }


    void ResourceTaken()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResourcesHeld -= 10;
            InventoryPercentage = ResourcesHeld / MaxResources;
            Debug.Log(InventoryPercentage);
            transform.localScale = new Vector2(InventoryPercentage, InventoryPercentage);
            if (InventoryPercentage < 0.1)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        isPlayerInCloud = true;
       

        Debug.Log("Trigger entered by: " + other.name);
        // You can access the object with: other.gameObject
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        isPlayerInCloud = false;
        
        Debug.Log("Trigger exited by: " + other.name);
    }
}
