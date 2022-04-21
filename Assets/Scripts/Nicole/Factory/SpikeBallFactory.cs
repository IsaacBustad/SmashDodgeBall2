using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallFactory : BallFactory
{
    SpikeBall spikeBall;
    BallSpawner spawner;

    public override Ball SpawnBall()
    {
        //Spawn
        Instantiate(spikeBall.gameObject, spikeBall.location, Quaternion.identity); //create and spawn

        spawner.AddBallList(spikeBall.gameObject);

        return new SpikeBall();
    }
}
