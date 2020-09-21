using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted = false;
    public static int crystalsCollected;
    public GameObject tile;
    public GameObject crystal;
    public GameObject platform;
    public GameObject ball;
    public GameObject mainCamera;
    public GameObject wayTrigger;
    public GameObject canvas;

    public int currentWidth;    
    public bool forward;    
    public float rotationSpeed;
    

    public Vector3 TEstCD;

    public Vector3 spawnWayPosition;
   


    int fieldWidth = 9;


    

    public IEnumerator StartGame()
    {
        canvas.GetComponent<ScoreScript>().ResetText();
        currentWidth = 5;
        crystalsCollected = 0;
        forward = true;
        foreach (GameObject Tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            Destroy(Tile);
        }
        foreach (GameObject Crystal in GameObject.FindGameObjectsWithTag("Crystal"))
        {
            Destroy(Crystal);
        }
        Destroy(GameObject.FindWithTag("StartPlatform"));
        GameObject platformNew = Instantiate(platform, new Vector3(0,4,0), Quaternion.identity);

        yield return new WaitForSeconds(0.1f);

        spawnWayPosition = GameObject.FindWithTag("SpawnWay").transform.position;
        Vector3 spawnBallPosition = GameObject.FindWithTag("Spawn").transform.position;

        TEstCD = spawnWayPosition;

        Instantiate(ball, spawnBallPosition + new Vector3(0,2.25f,0), Quaternion.identity);

        mainCamera.GetComponent<CameraScript>().GetBall();
        wayTrigger.GetComponent<WayTriggerScript>().GetBall();
        //wayTrigger.GetComponent<WayTriggerScript>().TestCall();



        gameStarted = true;
        WayGeneration();
        WayGeneration();
        WayGeneration();

        

    }


    public void WayGeneration()
    {
        if (forward == true)
        {
            int wayLength = Random.Range(2, 5);
            for (int length = 1; length <= wayLength; length++)
            {
                GameObject tileNew = Instantiate(tile, spawnWayPosition + new Vector3(0, 0, 4), Quaternion.identity);
                spawnWayPosition = tileNew.transform.position;
                if (Random.value > 0.5f == true)
                {
                    GameObject crystalNew = Instantiate(crystal, tileNew.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                }
            }
            forward = false;            
        }
        else
        {
            if (currentWidth == 1)
            {
                int wayLength = Random.Range(2, fieldWidth+1);
                currentWidth += wayLength-1 ;

                GameObject tileNewFirst = Instantiate(tile, spawnWayPosition + new Vector3(0, 0, 4), Quaternion.identity);
                spawnWayPosition = tileNewFirst.transform.position;

                for (int length = 1; length <= wayLength-1; length++)
                {
                    GameObject tileNew = Instantiate(tile, spawnWayPosition + new Vector3(4, 0, 0), Quaternion.identity);
                    spawnWayPosition = tileNew.transform.position;
                    if (Random.value > 0.5f == true)
                    {
                        GameObject crystalNew = Instantiate(crystal, tileNew.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                }

            }
            else if (currentWidth == fieldWidth)
            {
                int wayLength = Random.Range(2, fieldWidth+1);
                currentWidth -= wayLength-1;

                GameObject tileNewFirst = Instantiate(tile, spawnWayPosition + new Vector3(0, 0, 4), Quaternion.identity);
                spawnWayPosition = tileNewFirst.transform.position;

                for (int length = 1; length <= wayLength-1; length++)
                {
                    GameObject tileNew = Instantiate(tile, spawnWayPosition + new Vector3(-4, 0, 0), Quaternion.identity);
                    spawnWayPosition = tileNew.transform.position;
                    if (Random.value > 0.5f == true)
                    {
                        GameObject crystalNew = Instantiate(crystal, tileNew.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                }
            }
            else
            {
                bool DecreaseX = Random.value > 0.5f;
                if (DecreaseX == true)
                {
                    int wayLength = Random.Range(2, currentWidth+1);
                    currentWidth -= wayLength-1;

                    GameObject tileNewFirst = Instantiate(tile, spawnWayPosition + new Vector3(0, 0, 4), Quaternion.identity);
                    spawnWayPosition = tileNewFirst.transform.position;

                    for (int length = 1; length <= wayLength-1; length++)
                    {
                        GameObject tileNew = Instantiate(tile, spawnWayPosition + new Vector3(-4, 0, 0), Quaternion.identity);
                        spawnWayPosition = tileNew.transform.position;
                        if (Random.value > 0.5f == true)
                        {
                            GameObject crystalNew = Instantiate(crystal, tileNew.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        }
                    }
                }
                else
                {
                    int wayLength = Random.Range(2, fieldWidth - currentWidth +2);
                    currentWidth += wayLength-1;

                    GameObject tileNewFirst = Instantiate(tile, spawnWayPosition + new Vector3(0, 0, 4), Quaternion.identity);
                    spawnWayPosition = tileNewFirst.transform.position;

                    for (int length = 1; length <= wayLength-1; length++)
                    {
                        GameObject tileNew = Instantiate(tile, spawnWayPosition + new Vector3(4, 0, 0), Quaternion.identity);
                        spawnWayPosition = tileNew.transform.position;
                        if (Random.value > 0.5f == true)
                        {
                            GameObject crystalNew = Instantiate(crystal, tileNew.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        }
                    }
                }
            }
            forward = true;
        }
       
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (gameStarted == false)
            {
                gameStarted = true;
                Destroy(GameObject.FindWithTag("Ball"));
                StartCoroutine(StartGame());
                
            }
        }
        if (Input.GetAxis("Cancel") > 0)
        {
            Application.Quit();
        }
    }
}
