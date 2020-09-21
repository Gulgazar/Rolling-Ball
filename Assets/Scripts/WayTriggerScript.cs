using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayTriggerScript : MonoBehaviour
{
    
    public GameObject Ball;
    public GameManager gameManager;
    public int collidesAtTheTime = 0;
    public int tilesShown = 5;

    // Start is called before the first frame update
    

    public void GetBall()
    {
        collidesAtTheTime = 0;
        Ball = GameObject.FindWithTag("Ball");
            
         

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball)
        {
            transform.position = new Vector3(0, 3, Ball.transform.position.z + tilesShown * 4);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            collidesAtTheTime++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            collidesAtTheTime--;

            if (collidesAtTheTime == 0)

            {
                gameManager.WayGeneration();
            }
        }
    }

}
