using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text text;
    public Text score;
    public Text gratz;
    int bestScore;

    public void ResetText()
    {
        gratz.text = ("");
    }

    public void NewBestScore(int getScore)

    {
        if (getScore > bestScore)
        {
            bestScore = getScore;
            score.text = ("Best Score: " + (bestScore));
            gratz.text = ("Congratulations!"+ "\nNew Best Score!");
        }        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      text.text = ("Crystals Collected: " + GameManager.crystalsCollected.ToString());
    }
}
