using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluepint turretOne;
    public TurretBluepint turretTwo;

    BuildingManager buildingManager;

    void Start()
    {
        buildingManager = BuildingManager.instance;
    }
    public void Select_1_Turret()
    {
        Debug.Log("Turret 1");
        buildingManager.SelectTurretToBild(turretOne);
    }
 public void Select_2_Turret()
    {
        Debug.Log("Turret 2");
        buildingManager.SelectTurretToBild(turretTwo);
    }
}
