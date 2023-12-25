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


    private GameObject toBuilding;

    public GameObject GetTurret ()
    {
        return toBuilding; 
    }

    public void SetTurretToBild (GameObject turret)
    {
        toBuilding = turret;
    }
}
