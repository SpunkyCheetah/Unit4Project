using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerup;
    public int numberOfEnemies;
    public int wave;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = FindObjectsOfType<EnemyController>().Length;
        if (numberOfEnemies == 0)
        {
            wave++;
            NewWave(wave);
        }
    }

    public void NewWave(int waveSize)
    {
        for (int i = 0; i < waveSize; i++)
        {
            Instantiate(enemy, new Vector2(Random.Range(-7, 7), 5), enemy.transform.rotation);
        }
        Instantiate(powerup, new Vector2(Random.Range(-2, 4), Random.Range(-4, 0)), powerup.transform.rotation);
    }
}
