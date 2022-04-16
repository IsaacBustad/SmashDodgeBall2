using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : Ball, IEffects
{
    public int rotationSpeed = 50;

    public AudioClip audio;
    private bool hasPlayed = false;

    private BallSpin ballSpin;

    // Start is called before the first frame update
    void Start()
    {
        damageElement = new EyeBaseDamage();
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NPC")
        {
            // Blind player for 5 seconds or makes NPC unable to throw for 5 seconds
           
        }
    }
}
