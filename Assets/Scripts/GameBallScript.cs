using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallScript : MonoBehaviour
{
    
    public float speed;
    public static int collidesAtTheTime = 1;
    public int ShowCollides;
    public GameObject canvas;
    //GameObject gameManager;
    Rigidbody rb;
    bool WasPressedH = false;
    bool WasPressedV = false;
    bool Fallen = false;

    IEnumerator Fall()
    {
        Fallen = true;

        rb.constraints = RigidbodyConstraints.None;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.useGravity = true;
        
        collidesAtTheTime = -1;

        canvas.GetComponent<ScoreScript>().NewBestScore(GameManager.crystalsCollected);

        GameManager.gameStarted = false;
        yield return new WaitForSeconds(5);
    }
    // Start is called before the first frame update
    void Start()
    {
        collidesAtTheTime = 1;
        canvas = GameObject.FindWithTag("GUI");


        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        speed = 10f * (float)(1+(Math.Floor((float)GameManager.crystalsCollected/ 10f))*0.5);
        ShowCollides = collidesAtTheTime;
        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");

       if (WasPressedH == false && hVal != 0 && Fallen == false)
        {
            WasPressedH = true;
            if (hVal>0)
            {
                rb.velocity = new Vector3((float)Math.Ceiling(hVal)*speed,0f,0f);
                rb.angularVelocity = new Vector3(0f, 0f, -(float)Math.Ceiling(hVal) * speed / 4);
            }
            else
            {
                rb.velocity = new Vector3((float)Math.Floor(hVal)*speed, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, -(float)Math.Floor(hVal) * speed / 4);
            }
            
        }
       if (WasPressedH == true && hVal == 0)
        {
            WasPressedH = false;
        }
       if (WasPressedV == false && vVal > 0 && Fallen == false)
        {
            WasPressedV = true;
            rb.velocity = new Vector3(0f, 0f, (float)Math.Ceiling(vVal)*speed);
            rb.angularVelocity = new Vector3((float)Math.Ceiling(vVal) * speed / 4, 0f, 0f);
        }
       if (WasPressedV == true && vVal ==  0)
        {
            WasPressedV = false;
        }
       if (collidesAtTheTime == 0)
        {
            StartCoroutine(Fall());
        }

        

    }
}
