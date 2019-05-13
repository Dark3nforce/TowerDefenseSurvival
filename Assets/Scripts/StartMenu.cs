using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string loadLvl = "MapLvl1";
    private string lvlSelect = "LvlSelect";
    public void Play() 
    {
        Debug.Log("Play");
        SceneManager.LoadScene(loadLvl);
        Time.timeScale = 1f;
    }
    public void Exit() 
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void selectLvl() 
    {
        Debug.Log("Select Level");
        SceneManager.LoadScene(lvlSelect);
        Time.timeScale = 1f;
    }
}
