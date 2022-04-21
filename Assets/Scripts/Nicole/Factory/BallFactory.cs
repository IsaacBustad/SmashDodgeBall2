// Written by Nicole
// 4-7-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallFactory : MonoBehaviour
{
    public abstract Ball SpawnBall();
    Vector3[] locations;

    //Singleton
    List<GameObject> ballList = new List<GameObject>(); //that's in the game
    //BallSingleton BallSingleton;


    public void MakeBall()
    {
        //choose location
        Ball aBall = SpawnBall();
        int locationNum = Random.Range(0, locations.Length);
        aBall.location = locations[locationNum];

        //ball layer
        if (locationNum == 0 || locationNum == 1)
        {
            aBall.ballLayer = 7;
        }
        else if (locationNum == 2 || locationNum == 3)
        {
            aBall.ballLayer = 8;
        }
    }

  

}
