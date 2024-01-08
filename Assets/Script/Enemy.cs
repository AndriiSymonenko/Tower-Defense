using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float enemySpeed = 5f;
    public float startSpeed;

    public float health = 100;
    public int revenueForEnemy = 50;

    public GameObject deathEffect;

    void Start()
    {
        startSpeed = enemySpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }

    }  

    public void Slow(float amount)
    {
        enemySpeed = startSpeed * (1f - amount);
    }

        void Die ()
        {
            PlayerStats.Money += revenueForEnemy;

            GameObject effect =  (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            
            Destroy(gameObject);
        }
}
  

