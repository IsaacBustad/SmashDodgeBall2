using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : Ball, IEffects
{
    public int rotationSpeed = 50;

    public AudioClip bombStartAudio;
    private bool hasPlayed = false;

    public AudioClip bombExplosion;
    public bool hasExploded = false;

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

    // Strategy pattern
    public void ballEffect()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NPC")
        {
            // Explosion sound effect
            if (hasExploded == false)
            {
                // Spin noise effect
                AudioSource.PlayClipAtPoint(bombExplosion, gameObject.transform.position, 3);
                hasExploded = true;
            }

        }
    }
}
