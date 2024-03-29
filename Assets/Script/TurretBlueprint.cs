using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int GetSellPrice()
    {
        return cost / 2;
    }
}
