using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public int kills;
    public float secondsSurvived;
    float timer = 0.0f;
    float seconds = 0;
    public Text scoreLabel;

    // Update is called once per frame
    void Update()
    {
        secondsSurvived += Time.deltaTime;
        scoreLabel.text = "Score: " + Math.Round(FinalScore());
    }

    void CountTime()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
    }

    public float FinalScore() {
        return secondsSurvived * (kills+1);
    }
}
