
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    
    public static int enemyAlive = 0;
    public Wave[] waves;
    private int spawnEnemies = 0;
    public Transform spawnPoint;
    public Transform[] paths;
    public float timeBetweenWaves = 2f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public Text waveCountdownText;
    public Text roundStart;
    public Text enemyCounter;
    public GameManager GM;
    
    // void Start() {
    //     // enemyAlive = startEnemies;
    //     // enemyCounter.text = enemyAlive.ToString();
    // }

    void Update()
    {
        if(enemyAlive > 0) {
            return;
        }
        if(waveIndex == waves.Length) 
        {
            Debug.Log("Level Won!");
            this.enabled =false;
            GM.LvlWin();
        }
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            Debug.Log(waveIndex + " Wave Incoming");
            return;
        }
        
        countdown -= Time.deltaTime;
        roundStart.text = "Next Round Start:";
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        // enemyCounter.text = enemyAlive.ToString();
    }

    IEnumerator SpawnWave() {
        
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        enemyAlive = spawnEnemies = wave.count;
        for(int i = 0; i < spawnEnemies; i++) 
        {
            SpawnEnemy(wave.enemy);
            
            yield return new WaitForSeconds(1f/ wave.rate);
        }
        waveIndex++;
        

    }
    void SpawnEnemy(Transform monster) {
            for(int i = 0; i < paths.Length; i++) 
            {
                Transform g1 = Instantiate(monster, spawnPoint.position, spawnPoint.rotation);
                g1.GetComponent<EnemyMovement>().myPath = paths[i];
            }    
            
    }
}
