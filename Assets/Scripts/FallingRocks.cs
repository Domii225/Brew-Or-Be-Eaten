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
    [SerializeField] int spawnNumeber;

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
        for (int i = 0; i < spawnNumeber; i++)
        {
            spawnNumbers.Add(Random.Range(minTime, maxTime));
        }
        spawnNumbers.Sort();
        Debug.Log(spawnNumbers);
        Debug.Log((float) spawnNumbers[1] - (float) spawnNumbers[0]);
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        for (int i = 1; i < spawnNumeber; i++)
        {
            yield return new WaitForSeconds((float) spawnNumbers[i] - (float) spawnNumbers[i - 1]);
            StartCoroutine(SpawnRock());
        }
    }

    IEnumerator SpawnRock()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(spawnXmin, spawnXmax), spawnY, Random.Range(spawnZmin, spawnZmax));
        GameObject rock = Instantiate(rockPrefab, randomSpawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(rock);
    }

}
