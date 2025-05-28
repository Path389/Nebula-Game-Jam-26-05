using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public GameObject Projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse button 0 is Left click
        if (Input.GetMouseButtonDown(0)) 
        {
   
            Vector3 positionInFront = transform.position + transform.up /10;

            //Projectile.GetComponentInParent<Rigidbody>().position = positionInFront;
            Instantiate(Projectile, positionInFront, transform.rotation );
            
        }
    }
}
