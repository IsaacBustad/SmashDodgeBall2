// Written by Nicole
// 3-28-2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public float maxDistance = 10; //maxdis from player

    public float timeSpawnMax = 10f;
    public float timeSpawnMin = 3f;

    public float spawnTime; //interval
    public float lastSpawnTime;

    //Singleton
    List<GameObject> ballList = new List<GameObject>(); //that's in the game
    //BallSingleton BallSingleton;

    //Class Array
    public BallFactory[] ballTypeList; //array
    //public List<BallFactory> ballTypeList; //list
    BombBallFactory bombBallFact;
    EyeBallFactory eyeBallFact;
    RedDodgeBallFactory redBallFact;
    SpikeBallFactory spikeBallFact;
    WheelBallFactory wheelBallFact;
        

    void Start()
    {
        spawnTime = Random.Range(timeSpawnMin, timeSpawnMax);
        lastSpawnTime = 0;

        ballTypeList[0] = bombBallFact;
        ballTypeList[1] = eyeBallFact;
        ballTypeList[2] = redBallFact;
        ballTypeList[3] = spikeBallFact;
        ballTypeList[4] = wheelBallFact;

    }


    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        { //if time to spawn

            lastSpawnTime = Time.time;
            spawnTime = Random.Range(timeSpawnMin, timeSpawnMax);
            int listNum = Random.Range(0, ballTypeList.Length);
            ballTypeList[listNum].SpawnBall();
        }

    }

    //Singleton
    public void AddBallList(GameObject ball)
    {
        ballList.Add(ball);
        // BallSingleton.BallUpdated(ballList);
    }

    public void RemoveBallList(GameObject ball)
    {
        ballList.Remove(ball);
        // BallSingleton.BallUpdated(ballList);
    }


}