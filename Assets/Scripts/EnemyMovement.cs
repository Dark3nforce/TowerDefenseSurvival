using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public Transform myPath;
    Transform targetWP;
    int wayPointIndex = 1;

    private Enemy enemy;
    

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Enemy>();
        transform.position = myPath.GetChild(0).position;
    }
    void Update()
    {
        targetWP = myPath.GetChild(wayPointIndex);
        Vector3 dir = targetWP.position - transform.position;
        //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.position += dir.normalized * enemy.speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetWP.position) <= 0.2f)
        {
            if (nextWayPoint() == false)
            {
                AtGate();
                return;
            }
        }
        enemy.speed = enemy.baseSpeed;
    }

    bool nextWayPoint()
    {
        wayPointIndex += 1;
        if (wayPointIndex < myPath.childCount)
            return true;
        else
            return false;
    }
    void AtGate() 
    { 
        Destroy(gameObject);
        PlayerStats.Lives -= 1;
        WaveSpawner.enemyAlive--;
    }
}
