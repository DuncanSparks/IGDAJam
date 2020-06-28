using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void toMainMenu()
    {
         SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void enableScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

    public void disableScreen(GameObject screen)
    {
        screen.SetActive(false);
    }
}
