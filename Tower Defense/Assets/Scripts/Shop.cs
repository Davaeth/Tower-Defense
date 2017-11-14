using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint leaserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected!");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissleLauncher()
    {
        Debug.Log("Missile launcher selected!");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLeaserBeamer()
    {
        Debug.Log("Leaser beamer selected!");
        buildManager.SelectTurretToBuild(leaserBeamer);
    }

}
