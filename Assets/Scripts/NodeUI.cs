using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    public Text uiUpCost;
    public Button upgradeBtn;
    public Text uiSellCost;
    public Button sellBtn;
    private Node target;
    // public Vector3 positionOffSet;
    // private TurretBp turBp;

    // void setUpCostText() 
    // {
    //     // uiUpCost.text = "$ " + turBp.upgradeCost.ToString();
    //     // uiSellCost.text = "$ " + turBp.sellCost.ToString();
    // }s
    public void SetTarget(Node tar) 
    {
        target = tar;
        // transform.position = target.GetBuildPosition() + positionOffSet;
        // transform.position = target.GetBuildPosition();
        if(!target.isUpgraded) 
        {
            uiUpCost.text = "$ " + target.turBp.upgradeCost.ToString();
            upgradeBtn.interactable = true;
        }
        else 
        {
            uiUpCost.text = "Fully Upgraded";
            upgradeBtn.interactable = false;
        }

        uiSellCost.text = "$ " + target.turBp.getSellAmount(target.isUpgraded);
        
        
        UI.SetActive(true);
        // Debug.Log("UI Active");
    }    
    public void Hide() 
    {
        UI.SetActive(false);
        // Debug.Log("UI Inactive");
    }
    public void Upgrade() 
    {
        Debug.Log("turret upgraded");
        target.upgradeTurret();
        Build_Manager.instance.DeselectNode();
    }
    public void Sell() 
    {
        Debug.Log("turret sold");
        target.sellTurret();
        Build_Manager.instance.DeselectNode();
    }
}
