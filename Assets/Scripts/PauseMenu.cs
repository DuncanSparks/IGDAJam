using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
        {
            pauseMenu.SetActive(pauseMenu);
        }
    }
}
