using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{

    //public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameManager.crystalsCollected += 1;

            //yield return new WaitForSeconds(0.5f);
            Destroy(transform.gameObject);



        }
    }
}
