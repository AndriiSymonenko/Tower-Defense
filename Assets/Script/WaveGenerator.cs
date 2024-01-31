using UnityEngine;
using System.Collections;
using TMPro;

public class WaveGenerator : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    [SerializeField]
    private float timeBetweenWave = 5f;

    [SerializeField]
    private float countdown = 2f;

   [SerializeField]
   private int waveIndex = 0;

    [SerializeField]
    public Wave[] waves;

    [SerializeField]
    private GameObject pointOfSpawn;

    [SerializeField]
    private TMP_Text waveCountText;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
          StartCoroutine(SpawnWave());
          countdown = timeBetweenWave; // reset timer
          return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()

    {
       
       PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

       for (int i = 0; i < wave.count; i++)
        {

                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level Won!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, pointOfSpawn.transform.position, pointOfSpawn.transform.rotation);
        EnemiesAlive++;
    }


}
