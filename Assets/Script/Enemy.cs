using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5f;

    private Transform target;
    private int pathPointIndex = 0;

    private void Start()
    {
        target = PathPoints.points[0]; //set first target points frome enemy
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position; //definition direction for enemy
        transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World); // set move for enemy

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextPathPoints();
        }

        void GetNextPathPoints()
        {
            if (pathPointIndex >= PathPoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            pathPointIndex++;
            target = PathPoints.points[pathPointIndex]; // set new pathPoints
        }
    }
}
