using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject enemy;
    public GameObject coin;
    public float maxX = 7, minX = -7, maxY = 3, minY = -3;
    public float spawnEnemyRate;
    public float spawnCoinRate;
    float timeLastCoin;
    float timeLastEnemy;
    float timeNow;
   

    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time;

        timeLastEnemy = SpawnHere(enemy, spawnEnemyRate, timeLastEnemy);
        timeLastCoin = SpawnRandom(coin, spawnCoinRate, timeLastCoin);
    }
    float SpawnHere(GameObject obj, float spawnRate, float timeLastObject) 
        //Spawns obj, at that rate, needs the time where the last object was created.
        //returns the last time the object was created.
    {

        // TODO insert max number of objects to create
       if (timeNow - timeLastObject > spawnRate)
        {
            Instantiate(obj, transform.position, transform.rotation);
            timeLastObject = Time.time;
            
        }
        return timeLastObject;
    }
    float SpawnRandom(GameObject obj, float spawnRate, float timeLastObject)
    {
        if (timeNow - timeLastObject > spawnRate)
        {
            Instantiate(obj, RandomPosition(maxX,minX,maxY,minY), Quaternion.identity);
            timeLastObject = Time.time;
        }
        return timeLastObject;
    }
    public Vector2 RandomPosition(float max_X, float min_X, float max_Y, float min_Y)
    {
        float randomX;
        float randomY;
        randomX = Random.Range(min_X, max_X);
        randomY = Random.Range(min_Y, max_Y);
        Vector2 position;
        position = new Vector2(randomX, randomY);


        return position;

    }
}
