using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin
{

    public void SpinBall(float speed, GameObject _gameObject)
    {
        Debug.Log("Spin");
        _gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
