using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    // Start is called before the first frame update
    public void EndGame()
    {
        gameHasEnded = true;
        Invoke("Restart", restartDelay);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
