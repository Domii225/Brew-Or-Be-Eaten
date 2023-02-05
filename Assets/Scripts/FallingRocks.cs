using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using Random = UnityEngine.Random;

public class FallingRocks : MonoBehaviour
{
    float spawnXmin = -3;
    float spawnXmax = 3;
    float spawnY = 5;
    float spawnZmin = -5; 
    float spawnZmax = 10;

    public float maxTime = 4;
    public float minTime = 1;

    //current time
    private float time;
    private float totalTime = 4;

    //The time to spawn the object
    private float spawnTime;

    public GameObject rockPrefab;

    private ArrayList spawnNumbers = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
       
        //time = minTime;
    }
    void Update()
    {
        time = Time.deltaTime;
    }

    // Update is called once per frame
    public void SpawnFallingRocks()
    {
        for (int i = 0; i < 5; i++)
        {
            spawnNumbers.Add(Random.Range(minTime, maxTime));
        }
        if(time >= spawnTime)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(spawnXmin, spawnXmax), spawnY, Random.Range(spawnZmin, spawnZmax));
            Instantiate(rockPrefab, randomSpawnPosition, Quaternion.identity);
        }   

    }

}
