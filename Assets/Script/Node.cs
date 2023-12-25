using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour

{
    [SerializeField]
    private Color hoverColor;


    private GameObject turret;

    

    private Renderer rendererNode;
    private Color startColor;
    BuildingManager buildingManager;


    private void Start()
    {
        rendererNode = GetComponent<Renderer>();
        startColor = rendererNode.material.color;

        buildingManager = BuildingManager.instance;
        
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //stop set turret if button located on game field
            return;

        if (buildingManager.GetTurret() == null)
            return;

        if (turret != null)
        {
            rendererNode.material.color = Color.red;
            return;
        }

        GameObject buildingTurret = BuildingManager.instance.GetTurret();
        turret = (GameObject)Instantiate(buildingTurret, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //stop set turret if button located on game field
            return;

        if (buildingManager.GetTurret() == null)
            return;
        rendererNode.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rendererNode.material.color = startColor;
    }

}
