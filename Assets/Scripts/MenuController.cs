using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayNewGame()
    {
        LevelSave.ClearInventory();
        LevelSave.loadLevel();
        SceneManager.LoadScene("Gameplay Scene");
    }

    public void ContinueGame()
    {
        LevelSave.loadLevel();
        SceneManager.LoadScene("Gameplay Scene");
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
