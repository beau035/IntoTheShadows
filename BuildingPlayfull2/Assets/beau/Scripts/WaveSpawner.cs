using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour {

    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    public GameObject FadeOut;
    public Animator NextWave;

    private bool finishSpawning;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        //nextWaveText.text = "Wave " + (index + 1);
        //anim.SetTrigger("newWave");
        yield return new WaitForSeconds(timeBetweenWaves);
        //nextWaveText.text = "";
        //anim.enabled = false;
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for(int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            if(i == currentWave.count - 1)
            {
                finishSpawning = true;
            }
            else
            {
                finishSpawning = false;
            }

            GameObject randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    private void Update()
    {
        if(finishSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishSpawning = false;
            if(currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
                NextWave.SetTrigger("NextWave");
            }
            else
            {
                Debug.Log("Game has finished");
                FadeOut.SetActive(true);
            }
        }
    }

 
}
