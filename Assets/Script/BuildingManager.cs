using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildMeneger in scene");
            return;
        }

        instance = this;
    }



    public GameObject buildEffect;



    private TurretBlueprint toBuilding;
    private Node selectNode;

    public NodeUI nodeUI;
    public bool CanBuild { get { return toBuilding != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= toBuilding.cost; } } //verify money in player wallet





    public void SelectNode(Node node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }

        selectNode = node;
        toBuilding = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.HideUI();
    }

    public void SelectTurretToBild(TurretBlueprint turret)
    {
        toBuilding = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTorretToBuild()
    {
        return toBuilding;
    }
}
