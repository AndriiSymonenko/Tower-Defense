using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenWave = 5f;

    [SerializeField]
    private float countdown = 2f;

    [SerializeField]
    private float numberOfWaves = 5f;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject pointOfSpawn;

    private void Update()
    {
        if (countdown <= 0)
        {
            SpawnWave();
            countdown = timeBetweenWave;
        }
        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        if (numberOfWaves >= 0)
        {
            Instantiate(enemyPrefab, pointOfSpawn.transform.position, pointOfSpawn.transform.rotation);
            numberOfWaves--;
        }

    }


}
