using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public Text timerText;
    public Canvas raceCanvas;
    public Rigidbody player;
    public Collider startBox;
    public Collider finishBox;
    bool playing;
    float theTime;

    void Update()
    {
            theTime += Time.deltaTime;
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;
    }
}


