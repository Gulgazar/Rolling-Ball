using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatformScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

  

    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameBallScript.collidesAtTheTime -= 1;
            foreach (Transform child in transform)
            {
                Rigidbody rb = child.gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.useGravity = true;
                rb.angularVelocity = new Vector3(Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
            }
            Destroy(GetComponent<Collider>());


            yield return new WaitForSeconds(2);
            Destroy(transform.gameObject);
        }
    }
}
