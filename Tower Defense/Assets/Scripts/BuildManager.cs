using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject buildEffect;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {

        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");

            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab , node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect =  Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.money);
    }

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
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

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

}
