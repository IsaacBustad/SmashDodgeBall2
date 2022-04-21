using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBallFactory : BallFactory
{
    WheelBall wheelBall;
    BallSpawner spawner;

    public override Ball SpawnBall()
    {
        //Spawn
        Instantiate(wheelBall.gameObject, wheelBall.location, Quaternion.identity); //create and spawn

        spawner.AddBallList(wheelBall.gameObject);

        return new WheelBall();
    }
}
