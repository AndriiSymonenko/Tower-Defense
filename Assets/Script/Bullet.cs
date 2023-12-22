using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float bulletSpeed = 30f;

    public GameObject explosionEffect;

    public void Search(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distancePerFrame) //dir.magnitude - distance to the target
        {
            TargetHit();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);


    }

    void TargetHit()
    {
        GameObject effectIns = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
