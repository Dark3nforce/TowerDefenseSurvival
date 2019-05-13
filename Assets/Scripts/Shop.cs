
using UnityEngine;

public class Shop : MonoBehaviour
{
    Build_Manager buildManager;
    public TurretBp standardTurret;
    public TurretBp stanTurOffSet;
    public TurretBp missileLauncher;
    public TurretBp mLTurOffSet;
    public TurretBp laserBeamer;
    public TurretBp lBTurOffSet;
    Node node;


    void Start()
    {
        buildManager = Build_Manager.instance;
    }

    public void SelectStandardTurret() 
    {
        // Debug.Log("standard turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
        // node.setPositionOffset(stanTurOffSet);
    }
    public void SelectMissileLauncher()
    {
        // Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
        // node.setPositionOffset(mLTurOffSet);
    }
    public void SelectLaser()
    {
        // Debug.Log("Laser Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
        // node.setPositionOffset(lBTurOffSet);
    }
}
