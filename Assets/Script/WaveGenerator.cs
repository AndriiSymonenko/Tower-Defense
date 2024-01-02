using UnityEngine;
using System.Collections;
using TMPro;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenWave = 5f;

    [SerializeField]
    private float countdown = 2f;

   [SerializeField]
   private int waveIndex = 0;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject pointOfSpawn;

    [SerializeField]
    private TMP_Text waveCountText;

    private void Update()
    {
        if (countdown <= 0f)
        {
          StartCoroutine(SpawnWave());
          countdown = timeBetweenWave; // reset timer
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()

    {
       waveIndex++;
       for (int i = 0; i < waveIndex; i++)
        {

                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, pointOfSpawn.transform.position, pointOfSpawn.transform.rotation);
    }


}
