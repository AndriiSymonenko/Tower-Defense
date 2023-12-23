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

    public GameObject TurretOnePrefab;

    void Start()
    {
        toBuilding = TurretOnePrefab;
    }

    private GameObject toBuilding;

    public GameObject GetTurret ()
    {
        return toBuilding; 
    }
}
