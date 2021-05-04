using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayNewGame()
    {
        SceneManager.LoadScene("MapSelect");
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void DefaultMap()
    {
        LevelSave.SetCurrentLevel("BOB");
        SceneManager.LoadScene("Gameplay Scene");
        LevelSave.loadLevel();
    }
    public void CustomMap()
    {
        LevelSave.SetCurrentLevel("Level1");
        SceneManager.LoadScene("Gameplay Scene");
        LevelSave.loadLevel();
    }
}
