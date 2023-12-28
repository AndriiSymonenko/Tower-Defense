using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour

{
    [SerializeField]
    private Color hoverColor;

    [Header("Optional")]
    public GameObject turret;

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

        if (!buildingManager.CanBuild)
        //rendererNode.material.color = Color.red;
        return;

       if (turret != null)
        {
            rendererNode.material.color = Color.red;
            return;
        }

        buildingManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //stop set turret if button located on game field
            return;

        if (!buildingManager.CanBuild)
            return;
            rendererNode.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rendererNode.material.color = startColor;
    }

}
