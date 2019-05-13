
//using UnityEngine;

//public class Enemy : MonoBehaviour
//{
//    public float speed = 10f;
//    private Transform target;
//    private int wavepointIndex = 0;

//    void Start()
//    {
//        target = Waypoints.points[0];


//    }
//    void Update()
//    {
//        Vector3 dir = target.position - transform.position;
//        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

//        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
//            GetNextWayPoint();
//        }
//    }
//    void GetNextWayPoint() {
//        if(wavepointIndex >= Waypoints.points.Length - 1) {
//            Destroy(gameObject);
//            return;
//        }
//        wavepointIndex++;
//        target = Waypoints.points[wavepointIndex];
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 10f;
    [HideInInspector]
    public float speed;
    private float healthStart = 100;
    public float health;
    public int moneyGain = 50;
    public GameObject deathEffect;

    [Header("Health Bar")]
    public Image healthBar;  

    private bool isDead = false;  
    
    void Start() 
    {
        speed = baseSpeed;
        health = healthStart;
    }

    public void TakeDamage(float amount) 
    {
        health -= amount;
        healthBar.fillAmount = health/healthStart;
        if(health <= 0 && !isDead) 
        {
            die();
        }
    }
    public void Slow(float amount) 
    {
        speed = baseSpeed * (1f - amount);
    }
    void die() 
    {
        isDead = true;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += moneyGain;
        WaveSpawner.enemyAlive--;
        Destroy(gameObject);
    }

    // Update is called once per frame
    
}