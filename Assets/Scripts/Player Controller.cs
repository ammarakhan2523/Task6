using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    private float forwardInput;
    public GameObject projectilePrefab;
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    public float launchVelocity = 900f;
   
    public static bool hasPowerUp = false;
    public GameObject powerupIndicator;
    int count = 0;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // moves forward and backward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //takes turn left right
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch projectile form the player
            if (hasPowerUp == true)
            {
                GameObject bomb = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                   (0, launchVelocity, 0));
                count++;
                if (count == 3)
                {
                    hasPowerUp = false;
                    powerupIndicator.gameObject.SetActive(false);
                }
                print(count);
            }
            else if( hasPowerUp == false)
            {
                GameObject bomb = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                   (0, launchVelocity, 0));
               
            }
          
            
           
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("stickybomb"))
        {

           
                powerupIndicator.transform.position = transform.position;
                hasPowerUp = true;
                Destroy(collision.gameObject);
              

                powerupIndicator.gameObject.SetActive(true);

            
            
        }
    }
   
    
   

}
