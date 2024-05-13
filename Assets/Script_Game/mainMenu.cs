using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public GameObject confirmDialog;
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (PlayerPrefs.HasKey("Time"))
            PlayerPrefs.DeleteKey("Time");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowDialog()
    {
        confirmDialog.SetActive(true);
    }
    public void CloseDialog()
    {
        confirmDialog.SetActive(false);
    }
}
