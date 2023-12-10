using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
  
    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
       
      
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()

    {
  
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bomb") && !PlayerController.hasPowerUp)
        {
            
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("bomb") && PlayerController.hasPowerUp)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            collision.transform.parent = transform;
            StartCoroutine(StickyBombKill());

        }

    }
    IEnumerator StickyBombKill()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
