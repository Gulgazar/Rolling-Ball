using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject Ball;

    public void GetBall()
    {
        Ball = GameObject.FindWithTag("Ball");
    }

    void Start()
    {
        //GetBall();
    }


    void Update()
    {
        if (Ball)
        transform.position =  new Vector3(0f, 30f, -20f+ Ball.transform.position.z);
    }
}
