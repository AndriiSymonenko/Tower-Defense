
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int pathPointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

        target = PathPoints.points[0]; //set first target points from enemy
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position; //definition direction for enemy
        transform.Translate(direction.normalized * enemy.enemySpeed * Time.deltaTime, Space.World); // set move for enemy

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextPathPoints();
        }

        enemy.enemySpeed = enemy.startSpeed;
        
    }

    void GetNextPathPoints()
    {
        if (pathPointIndex >= PathPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        pathPointIndex++;
        target = PathPoints.points[pathPointIndex]; // set new pathPoints
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        WaveGenerator.EnemiesAlive--;
        Destroy(gameObject);
    }
}
