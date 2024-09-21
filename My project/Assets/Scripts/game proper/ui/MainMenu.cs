using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game proper");
    }

    public void HTPLoad()
    {
        SceneManager.LoadScene("HTP");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
