using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDodgeBallFactory : BallFactory
{
    RedDodgeBall redBall;
    BallSpawner spawner;

    public override Ball SpawnBall()
    {
        //Spawn
        Instantiate(redBall.gameObject, redBall.location, Quaternion.identity); //create and spawn

        spawner.AddBallList(redBall.gameObject);

        return new RedDodgeBall();
    }
}
