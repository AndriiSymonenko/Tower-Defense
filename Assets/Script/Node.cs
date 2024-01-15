using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour

{
    [SerializeField]
    private Color hoverColor;
    public Color noBuildingColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgrade = false;

    public Vector3 positionOffset;



    private Renderer rendererNode;
    private Color startColor;
    BuildingManager buildingManager;


    private void Start()
    {
        rendererNode = GetComponent<Renderer>();
        startColor = rendererNode.material.color;

        buildingManager = BuildingManager.instance;
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //stop set turret if button located on game field
            return;



        if (turret != null)
        {
            //rendererNode.material.color = noBuildingColor;
            buildingManager.SelectNode(this);
            return;
        }

        if (!buildingManager.CanBuild)
            return;

        BuildTurret(buildingManager.GetTorretToBuild());

        //buildingManager.BuildTurretOn(this);
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("No Money - no honey");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        _turret = turret;

        GameObject effectBuild = (GameObject)Instantiate(buildingManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effectBuild, 5f);


        Debug.Log("Turret build! Money left " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("No Money - no upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgragePrefab, GetBuildPosition(), Quaternion.identity);
        _turret = turret;

        GameObject effectBuild = (GameObject)Instantiate(buildingManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effectBuild, 5f);

        isUpgrade = true;

        Debug.Log("Turret upgeded!");
    }
         
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //stop set turret if button located on game field
            return;

        if (!buildingManager.CanBuild)
            return;
            rendererNode.material.color = hoverColor;

        if (buildingManager.HasMoney)
        {
            rendererNode.material.color = hoverColor;
        }
        else
        {
            rendererNode.material.color = noBuildingColor;
        }
    }

    void OnMouseExit()
    {
        rendererNode.material.color = startColor;
    }

}
