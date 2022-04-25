using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    [SerializeField] private bool xAxis;
    [SerializeField] private bool yAxis;
    [SerializeField] private bool zAxis;

    public float spinSpeed; 

    private BallDealDamage ballDealDamage;


    void Awake()
    {
        ballDealDamage = gameObject.GetComponent<BallDealDamage>();
    }

    void Update()
    {
        if (ballDealDamage.IsArmed)
        {
            SpinBall(spinSpeed, gameObject);
        }
    }

    public void SpinBall(float speed, GameObject _gameObject)
    {
        if (xAxis)
        {
            _gameObject.transform.Rotate(speed * Time.deltaTime, 0, 0);
        }
        if (yAxis)
        {
            _gameObject.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        if (zAxis)
        {
            _gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
