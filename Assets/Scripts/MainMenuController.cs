using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void StartGame()
    {        
        int currentLevel = PlayerPrefs.GetInt("level");
        if(currentLevel == 0)
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(currentLevel);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
