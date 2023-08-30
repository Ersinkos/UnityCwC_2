using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnRangeZMax = 16.0f;
    private float spawnRangeZMin = 4.0f;
    private float spawnPosZFromTop = 20.0f;
    private float spawnPosXFromSide = 27.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalFromTop", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalFromSide", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomAnimalFromTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZFromTop);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Debug.Log(animalIndex);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnRandomAnimalFromSide()
    {
        if(Random.Range(-1,2) < 0)
        {
            spawnPosXFromSide = -27.0f;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            spawnPosXFromSide = 27.0f;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        Vector3 spawnPos = new Vector3(spawnPosXFromSide, 0, Random.Range(spawnRangeZMin, spawnRangeZMax));
        int animalIndex = Random.Range(0, animalPrefabs.Length);    
        Instantiate(animalPrefabs[animalIndex], spawnPos, transform.rotation);
    }
}
