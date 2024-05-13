using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        player.GetComponent<pMove>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

    }

    void Pause()
    {
        player.GetComponent<pMove>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        player.GetComponent<pMove>().enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
