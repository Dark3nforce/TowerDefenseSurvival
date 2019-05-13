using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    // private static Vector3 positionOffSet;

    private Color startColor;
    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBp turBp;
    [HideInInspector]
    public bool isUpgraded = false;

    Build_Manager buildManager;
    


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = Build_Manager.instance;
    }
    // public Vector3 setPositionOffset(Vector3 posOffset) 
    // {
    //     return positionOffSet = posOffset;
    // }

    public Vector3 GetBuildPosition() 
    {
        // return transform.position + positionOffSet;
        return transform.position;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        

        if(turret != null) 
        {
            buildManager.SelectNode(this);
            // Debug.Log("Node Selected");
            return;
        }
        if (!buildManager.CanBuild)
            return;

        buildTurret(buildManager.getTurretToBuild());

    }

    void buildTurret(TurretBp Bp) 
    {
        if(PlayerStats.Money < Bp.cost)
        {
            Debug.Log("Not enough money to build turret");
            return;
        }

        PlayerStats.Money -= Bp.cost;
        //Build a turret
        GameObject tur =  (GameObject)Instantiate(Bp.prefab, GetBuildPosition() + Bp.positionOffset , Quaternion.identity);
        // GameObject turret =  (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition() , Quaternion.identity);
        turret = tur;
        turBp = Bp;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void upgradeTurret() 
    {
        if(PlayerStats.Money < turBp.upgradeCost)
        {
            Debug.Log("Not enough money to build turret");
            return;
        }

        PlayerStats.Money -= turBp.upgradeCost;
        //Destroying old turret
        Destroy(turret);
        //Building upgraded turret
        GameObject tur =  (GameObject)Instantiate(turBp.upgradedPrefab, GetBuildPosition() + turBp.positionOffset , Quaternion.identity);
        // GameObject turret =  (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition() , Quaternion.identity);
        turret = tur;
        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        isUpgraded = true;

        Debug.Log("turret upgraded");
    }
    public void sellTurret() 
    {
        PlayerStats.Money += turBp.getSellAmount(isUpgraded);
        
        //Spawn Destroy Effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turret);
        isUpgraded = false;
        Destroy(effect, 5f);
        turBp = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.CanBuild) 
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        //if (buildManager.HasMoney) {
        //    rend.material.color = hoverColor;
        //}
        //else 
        //{
        //    rend.material.color = notEnoughMoneyColor;
        //}


        //GetComponent<Renderer>().material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
