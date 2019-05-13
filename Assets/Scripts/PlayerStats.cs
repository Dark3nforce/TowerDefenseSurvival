
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int startMoney = 400;
    public int startLives = 10;
    public int startRound = -1;
    public static int Money;
    public static int Lives;
    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = startRound;
    }
}
