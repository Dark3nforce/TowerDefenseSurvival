using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LvlSelectMenu : MonoBehaviour
{
    public Button[] nxtLvlBtn;
    // private Renderer rend;
    // private Color startColor;

    public void Start() {
        int highestLvl = PlayerPrefs.GetInt("highestLvl", 1);
        for (int i = 0; i < nxtLvlBtn.Length; i++)
        {
            if(i + 1  > highestLvl)
                nxtLvlBtn[i].interactable = false;

        }
    }

    public void mainMenu() 
    {
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Start Menu Selected");
        Time.timeScale = 1f;
    }
    public void Select(string lvlName) {
        SceneManager.LoadScene(lvlName);
        Debug.Log(lvlName + " Selected");
        Time.timeScale = 1f;
    }
    // public GameObject Map1;
    // public GameObject Map2;
    // public GameObject Map3;
    // public GameObject Map4;
    // public GameObject Map5;
    // public GameObject Map6;
    // public GameObject Map7;
    // void Start()
    // {
    //     rend = GetComponent<Renderer>();
    //     startColor = rend.material.color;
    // }

    // public void goToMap1() 
    // {
    //     SceneManager.LoadScene("MapLvl1");
    //     Debug.Log("Level 1 Selected");
    //     Time.timeScale = 1f;
    //     //hover(Map1);
    // }
    // public void goToMap2() 
    // {
    //     SceneManager.LoadScene("MapLvl2");
    //     Debug.Log("Level 2 Selected");
    //     Time.timeScale = 1f;
    //     // hover(Map2);
    // }
    // public void goToMap3() 
    // {
    //     SceneManager.LoadScene("MapLvl3");
    //     Debug.Log("Level 3 Selected");
    //     Time.timeScale = 1f;
    //     // hover(Map3);
    // }
    // public void goToMap4() 
    // {
    //     SceneManager.LoadScene("MapLvl4");
    //     Debug.Log("Level 4 Selected");
    //     Time.timeScale = 1f;
    //     // hover(Map4);
    // }
    // public void goToMap5() 
    // {
    //     SceneManager.LoadScene("MapLvl5");
    //     Debug.Log("Level 5 Selected");
    //     Time.timeScale = 1f;
    //     // hover(Map5);
    // }
    // public void goToMap6() 
    // {
    //     SceneManager.LoadScene("MapLvl6");
    //     Debug.Log("Level 6 Selected");
    //     // hover(Map6);
    // }
    // public void goToMap7() 
    // {
    //     SceneManager.LoadScene("MapLvl7");
    //     Debug.Log("Level 7 Selected");
    //     Time.timeScale = 1f;
    //     // hover(Map7);
    // }   
    // void OnMouseEnter()
    // {
    //     if (EventSystem.current.IsPointerOverGameObject())
    //         return;
    //     startColor = rend.material.color;
    //     rend.material.color = Color.blue;
    // }
    // void OnMouseExit()
    // {
    //     rend.material.color = startColor;
    // }
}
