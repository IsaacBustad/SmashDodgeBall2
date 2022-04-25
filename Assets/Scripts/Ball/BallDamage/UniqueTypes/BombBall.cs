using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : Ball
{
    public int rotationSpeed = 50;

    public AudioClip bombStartAudio;
    private bool hasPlayed = false;

    private BallSpin ballSpin;


    void Start()
    {
        damageElement = new BombBaseDamage();
        ballSpin = new BallSpin();
    }
    void Update()
    {
        ballEffect();
    }

    // When player grabs ball
    public override void ballEffect()
    {
        // Spin ball
        ballSpin.SpinBall(rotationSpeed, gameObject);

        if (hasPlayed == false)
        {
            // Spin noise effect
            AudioSource.PlayClipAtPoint(bombStartAudio, gameObject.transform.position, 3);
            hasPlayed = true;
        }
    }
}
