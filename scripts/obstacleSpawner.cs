using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
    public Transform[] spawnPoints;

    //increasing spawn rate system
    public float spawnRate; //time between spawns
    public float decreaseRate = .2f; //how much time will decrease between spawns
    public float waitUntilDecrease = 20f; //how long to wait until the next decrease
    public float decreaseTime;
    public float waitDecrease = 1f;
    //reset after game reaches top speed
    float resetRate;
    public float resetRateConstant = 30f;
    float spawnRateReset;

    //constants for resetting the loop
    float waitUntilConstant;
    float decreaseConstant;
    float spawnRateConstant;

    // Start is called before the first frame update
    void Start()
    {
        resetRate = resetRateConstant;
        decreaseTime = waitUntilDecrease;
        StartCoroutine(ObstacleSpawner());

        //setting constants for resetting
        waitUntilConstant = waitUntilDecrease;
        decreaseConstant = decreaseTime;
        spawnRateConstant = spawnRate;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRockSpawner())
        {
            GetFaster();
        }
        
    }
    //check if the spawning point is empty.
    bool isEmpty(Vector3 targetPos)
    {
        GameObject[] obstacleTag = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obs in obstacleTag)
        {
            if (obs.transform.position == targetPos){return false;}
        }
        return true;
    }

    bool isRockSpawner()
    {
        if (this.gameObject.tag.Equals("RockSpawner"))
            return true;
        else
            return false;

    }
    public IEnumerator ObstacleSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
            Transform spawnPos = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Vector3 positionVector = new Vector3(spawnPos.position.x,spawnPos.position.y,spawnPos.position.z);
          
          //  print("Should spawn!..");
            //make sure nothing spawns on top of each other

            if (isEmpty(positionVector)){
            Instantiate(randomObstacle, spawnPos.position, randomObstacle.transform.rotation);}
            
            //print("Spawned object "+ randomObstacle.name);


            //StartCoroutine(ObstacleSpawner());
        }
    }

    void GetFaster()
    {

        /*
        * How it works:
        * when decreaseTime hits 0, 
        * spawnRate goes down by decreaseRate
        * then waitUntilDecrease goes down by
        * waitDecrease and then decreaseTime resets itself to
        * waitUntilDecrease
        */
        
        decreaseTime -= Time.deltaTime;

        if (decreaseTime <= 0 && spawnRate >= 1f)
        {
        
            spawnRate -= decreaseRate;
            waitUntilDecrease -= waitDecrease;
            decreaseTime = waitUntilDecrease;
        }

        /*
        * if the system is at top speed, the game will keep going at that rate for x seconds
        * and then go back to a slower spawn rate, and start decreasing again in a loop.
        */
        if (spawnRate <= 1f)
        {
            resetRate -= Time.deltaTime;
            if (resetRate <= 0f)
            {
                spawnRate = spawnRateReset;
                resetRate = resetRateConstant;
                waitUntilDecrease = waitUntilConstant;
                decreaseTime = decreaseConstant;
                spawnRate = spawnRateConstant;
            }
        }
    }
}
