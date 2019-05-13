using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) 
        {
            Toggle();
        }
    }
    public void Toggle() 
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        if(pauseUI.activeSelf) 
        {
            Time.timeScale = 0f;
        } else 
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry() 
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume() 
    {
        Toggle();
    }
    public void mainMenu() 
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }
}
