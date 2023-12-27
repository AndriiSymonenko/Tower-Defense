using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;

    [Header("Setting")]
    [SerializeField]
    private float speedRotation = 5f;
    [SerializeField]
    private float range;
    public float fireRange = 1f;
    public float fireCountdown = 0f;


    [Header("Setup Fields")]
    [SerializeField]
    private string tagEnemy = "Enemy";
    [SerializeField]
    private Transform towerRotate;
    public GameObject bulletPrefab;
    public Transform pointFire;

    void Start()
    {
        InvokeRepeating("targetUpdate", 0f, 0.2f);
    }

    void targetUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tagEnemy);
        float shortDistance = Mathf.Infinity; //when there is no enemy in turret range
        GameObject nearEnemy = null;

        foreach ( GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy; //set distance to enemy
                nearEnemy = enemy; //set nearest enemy
            }
        }

        if (nearEnemy != null && shortDistance <= range)
        {
            target = nearEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        return;

        Vector3 towerDir = target.position - transform.position;
        Quaternion lookToEnemy = Quaternion.LookRotation(towerDir);
        Vector3 rotation = Quaternion.Lerp(towerRotate.rotation, lookToEnemy, Time.deltaTime * speedRotation).eulerAngles;
        towerRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRange;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO =  (GameObject)Instantiate(bulletPrefab, pointFire.transform.position, pointFire.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Search(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
