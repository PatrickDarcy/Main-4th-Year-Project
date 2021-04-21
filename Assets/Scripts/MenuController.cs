using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayNewGame()
    {
        SceneManager.LoadScene("Gameplay Scene");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Gameplay Scene");
        LevelSave.loadLevel();
    }

    public void MapMaker()
    {
        SceneManager.LoadScene("LevelEditor");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
