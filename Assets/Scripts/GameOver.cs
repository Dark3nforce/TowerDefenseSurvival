using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    public Text roundsLbl;

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

    public void tryAgain() 
    {
        // SceneManager.LoadScene("MapLvl1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void goToMainMenu() 
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

}
