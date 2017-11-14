using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color falseColor;

    public Vector3 positionOffSet;

    [Header("Optional")]
    public GameObject turret;

    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

	void Start () {

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);

            //rend.material.color = falseColor; // This line can change the color of the node to red if there is already another turret.

            return;
        }

        if (!buildManager.HasMoney)
            rend.material.color = falseColor; // This line changing the color of the node to red if player doesn't have enough money to buy it.

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
