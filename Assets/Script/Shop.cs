using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildingManager buildingManager;

    void Start()
    {
        buildingManager = BuildingManager.instance;
    }
    public void Purchared_1_Turret()
    {
        Debug.Log("Turret 1");
        buildingManager.SetTurretToBild(buildingManager.turretOnePrefab);
    }
 public void Purchared_2_Turret()
    {
        Debug.Log("Turret 2");
        buildingManager.SetTurretToBild(buildingManager.turretTwoPrefab);
    }
}
