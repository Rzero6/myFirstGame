using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text uiTime;
    private float time;
    void Start()
    {
        if (PlayerPrefs.HasKey("Time"))
        {
            time = PlayerPrefs.GetFloat("Time");
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            uiTime.text = "Time: " + formattedTime;
        }
    }
}
