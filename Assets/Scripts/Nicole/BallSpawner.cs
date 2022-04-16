// Written by Soojung
// 3/28/2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // for NavMesh

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;
    public Transform playerTransform;

    public Transform[] spawnPoints; 

    public float maxDistance = 10; //maxdis from player

    public float timeSpawnMax = 10f;
    public float timeSpawnMin = 3f;

    public float spawnTime; //interval
    public float lastSpawnTime;

    List<GameObject> ballList = new List<GameObject>();

    //Singleton Singleton;

    void Start()
    {
        spawnTime = Random.Range(timeSpawnMin, timeSpawnMax);
        lastSpawnTime = 0;
    }

    
    void Update()
    {
        if(Time.time >= lastSpawnTime + spawnTime){ //if time to spawn
             
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(timeSpawnMin, timeSpawnMax);
            RandomSelectSpawnPoint();
        }
       
    }

    void RandomSelectSpawnPoint()
    {
        int number = Random.Range(0, spawnPoints.Length);
        Spawn(number);
    }

    private void Spawn(int number)
    {
       // Vector3 spawnPosition = GetRandomPointOnNavMesh(playerTransform.position, maxDistance);
       // spawnPosition += Vector3.up * 0.7f;  // if spawn point is too low
        
        GameObject selectedBall = balls[Random.Range(0, balls.Length)]; //choose random ball
        //GameObject ball = Instantiate(selectedBall, spawnPosition, Quaternion.identity); //create and spawn
        selectedBall.transform.position = spawnPoints[number].transform.position; //Spawn

        AddBallList(selectedBall);
        
    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        //Get random point inside the sphere
        Vector3 randomPos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;

        //in maxdisstance, get randompos from the nearest navmesh
        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);

        return hit.position;
        
    }

    public void AddBallList(GameObject ball)
    {
        ballList.Add(ball);
        //BallSingleton.BallUpdated(ballList);
    }
    
    public void RemoveBallList(GameObject ball)
    {
        ballList.Remove(ball);
        //BallSingleton.BallUpdated(ballList);
    }


}