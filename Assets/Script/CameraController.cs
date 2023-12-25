using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool movement = true;

    public float camSpeed = 5f;
    public float borderThikness = 5f;

    public float scrollSpeed = 3f;
    public float minY = 5f;
    public float maxY = 35f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            movement = !movement;
        if (!movement)
            return;
            

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderThikness)
        {
            transform.Translate(Vector3.forward * camSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderThikness)
        {
            transform.Translate(Vector3.back * camSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderThikness)
        {
            transform.Translate(Vector3.right * camSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= borderThikness)
        {
            transform.Translate(Vector3.left * camSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 posScroll = transform.position;

        posScroll.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        posScroll.y = Mathf.Clamp(posScroll.y, minY, maxY);

        transform.position = posScroll;

    }
}
