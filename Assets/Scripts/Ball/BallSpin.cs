using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{

    public void SpinBall(float speed)
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
