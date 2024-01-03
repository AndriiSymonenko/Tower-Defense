using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5f;

    public int health = 100;
    public int revenueForEnemy = 50;

    public GameObject deathEffect;

    private Transform target;
    private int pathPointIndex = 0;

    private void Start()
    {
        target = PathPoints.points[0]; //set first target points frome enemy
    }

    public void TakeDamage (int ammount)
    {
        health -= ammount;

        if (health <= 0)
        {
            Die();
        }

        void Die ()
        {
            PlayerStats.Money += revenueForEnemy;

            GameObject effect =  (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            
            Destroy(gameObject);
        }
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
                EndPath();
                return;
            }
            pathPointIndex++;
            target = PathPoints.points[pathPointIndex]; // set new pathPoints
        }
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
