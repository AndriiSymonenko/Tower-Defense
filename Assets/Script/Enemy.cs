using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float enemySpeed;
    public float startSpeed;

    public float startHealth = 100;
    private float health;
    public int revenueForEnemy = 50;
    public Image healthBar;



    public GameObject deathEffect;

    void Start()
    {
        enemySpeed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;


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

        WaveGenerator.EnemiesAlive--;
            
            Destroy(gameObject);
        }
}
  

