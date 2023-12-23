using UnityEngine;

public class Node : MonoBehaviour

{
    [SerializeField]
    private Color hoverColor;


    private GameObject turret;

    

    private Renderer rendererNone;
    private Color startColor;


    private void Start()
    {
        rendererNone = GetComponent<Renderer>();
        startColor = rendererNone.material.color;
        
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            rendererNone.material.color = Color.red;
            return;
        }

        GameObject buildingTurret = BuildingManager.instance.GetTurret();
        turret = (GameObject)Instantiate(buildingTurret, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        rendererNone.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rendererNone.material.color = startColor;
    }

}
