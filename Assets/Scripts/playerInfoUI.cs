using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class playerInfoUI : MonoBehaviour
{
    public Text moneyText;
    public Text livesText;
    public Text roundText;
    // public Text standardTurretText;
    // public Text missileLauncherText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerStats.Money.ToString();
        livesText.text = PlayerStats.Lives.ToString();
        roundText.text = PlayerStats.Rounds.ToString();
        // standardTurretText = .ToString();
        // missileLauncherText = .ToString();
    }

}
