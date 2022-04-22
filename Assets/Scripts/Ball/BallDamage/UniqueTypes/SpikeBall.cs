using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : Ball, IEffects
{
    public int rotationSpeed = 50;

    public AudioClip audio;
    private bool hasPlayed = false;

    private BallSpin ballSpin;

    // Start is called before the first frame update
    void Start()
    {
        damageElement = new SpikeBaseDamage();
        ballSpin = new BallSpin();
    }

    void Update()
    {
        //ballEffect();
    }

    // Strategy pattern
    public void ballEffect()
    {
        // Spin ball
        ballSpin.SpinBall(rotationSpeed, gameObject);

        if (hasPlayed == false)
        {
            if (hasPlayed == false)
            {
                // Spin noise effect
                AudioSource.PlayClipAtPoint(audio, gameObject.transform.position, 3);

                hasPlayed = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
