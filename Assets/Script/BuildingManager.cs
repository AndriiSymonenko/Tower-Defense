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

    public GameObject turretOnePrefab;
    public GameObject turretTwoPrefab;



    private TurretBluepint toBuilding;

    public bool CanBuild { get { return toBuilding != null; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < toBuilding.cost)
        {
            Debug.Log("No Money - no honey");
            return;
        }

        PlayerStats.Money -= toBuilding.cost;

       GameObject turret = (GameObject)Instantiate(toBuilding.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left " + PlayerStats.Money);

    }

    public void SelectTurretToBild(TurretBluepint turret)
    {
        toBuilding = turret;
    }
}
