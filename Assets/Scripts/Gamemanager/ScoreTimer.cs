using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour {

    public Text timerText;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (Mathf.Round(t % 60)).ToString();

        timerText.text = minutes + ":" + seconds;
    }
}
