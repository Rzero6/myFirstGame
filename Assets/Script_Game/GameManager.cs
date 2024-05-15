using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public TMP_Text uiTime;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject guideUI;
    public GameObject gameOverUI;
    void Start()
    {
        StartCoroutine(ClearGuideUIAfterDelay(5f));
    }
    IEnumerator ClearGuideUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        guideUI.SetActive(false);
    }

    public void CompleteLevel(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        uiTime.text = formattedTime;
        PlayerPrefs.SetFloat("Time", time);
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        gameHasEnded = true;
        gameOverUI.SetActive(true);
        Invoke("Restart", restartDelay);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
