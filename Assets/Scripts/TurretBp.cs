using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBp
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int upgradeCost;
    public Vector3 positionOffset;

    public int getSellAmount(bool isUpgraded) 
    {
        if(!isUpgraded)
            return cost/2;
        else
            return (cost+upgradeCost)/2;    
    }



}
