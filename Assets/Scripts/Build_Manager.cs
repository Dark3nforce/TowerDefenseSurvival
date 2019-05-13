
using UnityEngine;

public class Build_Manager : MonoBehaviour
{
    public static Build_Manager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


    public GameObject buildEffect;

    private TurretBp turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null && PlayerStats.Money >= turretToBuild.cost;  } }

    //giving null oject reference 
    //public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    // public void buildTurretOn (Node node) 
    // {
        
    // }

    public void SelectNode(Node node) 
    {
        if(selectedNode == node) 
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode() 
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBp turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBp getTurretToBuild()
    {
        return turretToBuild;
    }
}
