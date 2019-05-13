using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public string nextMap = "MapLvl2";
    // public int unlockLvl = 2;
    public Text roundsLbl;
    public Button contBtn;

    void Start() {
        if(nextMap.Equals("MapLvl8"))
            contBtn.interactable = false;
    }
    void OnEnable () 
    {
        StartCoroutine(TxtAnimate());
    }
    IEnumerator TxtAnimate() 
    {
        roundsLbl.text = "0";
        int round  = 0;
        yield return new WaitForSeconds(0.9f);
        while(round < PlayerStats.Rounds) {
            round++;
            roundsLbl.text = round.ToString();
            yield return new WaitForSeconds(.5f);
        }

    }

    public void goToNextLevel() 
    {
        // SceneManager.LoadScene("MapLvl1");
        // SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(SceneManager.GetSceneAt() +1));
        // PlayerPrefs.SetInt("highestLvl", unlockLvl);
        // if(nextMap.Equals("MapLvl8"))
        //     contBtn.interactable = false;
        SceneManager.LoadScene(nextMap);
        Time.timeScale = 1f;
    }

    public void goToMainMenu() 
    {
        // PlayerPrefs.SetInt("highestLvl", unlockLvl);
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }
}
