using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public static int kills;
    public static float secondsSurvived;
    float timer = 0.0f;
    float seconds = 0;
    public Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        scoreLabel.text = "Score: " + this.FinalScore();
    }

    void CountTime()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
    }

    public float FinalScore(){
        return secondsSurvived * (kills+1);
    }
}
