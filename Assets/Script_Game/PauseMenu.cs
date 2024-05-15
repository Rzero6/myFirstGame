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
    public GameObject camera3rd;
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
        camera3rd.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        player.GetComponent<pMove>().enabled = false;
        camera3rd.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        camera3rd.SetActive(true);
        player.GetComponent<pMove>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
    }

    public void LoadMenu()
    {
        player.GetComponent<pMove>().enabled = true;
        camera3rd.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
    }

}
