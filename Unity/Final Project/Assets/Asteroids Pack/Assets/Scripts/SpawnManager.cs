using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] asteroidPrefab;
    

    private float spawnRangeX = 25;
    private float spawnPosZ = 25;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    

    public GameObject[] powerupPrefab;
    public float spawnIntervalP = 12f;

    private float startDelayPup = 5;

    public GameObject[] weaknessPrefab;
    public float spawnIntervalW = 10f;

    private Player Player;




    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("Spawnasteroid", startDelay, spawnInterval);
        InvokeRepeating("spawnGenerator", startDelayPup, spawnIntervalP );
        InvokeRepeating("spawnWeakness", startDelayPup, spawnIntervalW);


    }

    // Update is called once per frame
    void Update()
    {
        

    } //asteroid spawn
    void Spawnasteroid()
    {
        if (Player.isGameActive)
        {
            int asteriodIndex = Random.Range(0, asteroidPrefab.Length);

            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(asteroidPrefab[asteriodIndex], spawnPos, asteroidPrefab[asteriodIndex].transform.rotation);
        }
   
        

    } //Powerup spawn
    void spawnGenerator()
    {
        if (Player.isGameActive)
        {
            int powerupIndex = Random.Range(0, powerupPrefab.Length);

            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(powerupPrefab[powerupIndex], spawnPos, powerupPrefab[powerupIndex].transform.rotation);
        }
 

        


    } //ring spawn
    void spawnWeakness()
    {
        if (Player.isGameActive)
        {
       int weaknessIndex = Random.Range(0, weaknessPrefab.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(weaknessPrefab[weaknessIndex], spawnPos, weaknessPrefab[weaknessIndex].transform.rotation);
        }
 
    }
    

}
