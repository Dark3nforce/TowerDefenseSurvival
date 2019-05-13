using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    // public string nxtLvl = "MapLvl2";
    public int unlockLvl = 2;
    
    void Start() 
    {
        gameEnded = false;
    }

    void Update()
    {
        if(gameEnded)
            return;

        //Remove Later, For Testing only
        if(Input.GetKeyDown("e"))
            EndGame();    

        if(PlayerStats.Lives <= 0) 
        {
            EndGame();
        }
    }
    void EndGame() 
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
    public void LvlWin() {
        PlayerPrefs.SetInt("highestLvl", unlockLvl);
        gameEnded = true;
        gameWinUI.SetActive(true);
    }
}
