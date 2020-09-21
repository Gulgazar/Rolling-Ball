using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class TileColliderScript : MonoBehaviour
{
    Rigidbody rb;
    //private Collider Ball;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {

            GameBallScript.collidesAtTheTime += 1;

            yield return new WaitForSeconds(2);
            GameBallScript.collidesAtTheTime -= 1;
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            rb.angularVelocity = new Vector3(Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
            Destroy(transform.gameObject);

        }



    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameBallScript.collidesAtTheTime -= 1;
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            rb.angularVelocity = new Vector3(Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
            Destroy(transform.gameObject);

            
        }
    }
}

