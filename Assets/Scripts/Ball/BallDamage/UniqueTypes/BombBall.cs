using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : Ball, IEffects
{
    public int rotationSpeed = 50;

    public AudioClip audio;
    private bool hasPlayed = false;

    private BallSpin ballSpin;


    void Start()
    {
        damageElement = new BombBaseDamage();
        ballSpin = new BallSpin();
    }

    // Strategy pattern
    public void ballEffect()
    {
        if (hasPlayed == false)
        {
            // Spin noise effect
            AudioSource.PlayClipAtPoint(audio, gameObject.transform.position, 3);

            // Spin ball
            ballSpin.SpinBall(rotationSpeed);
            hasPlayed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
