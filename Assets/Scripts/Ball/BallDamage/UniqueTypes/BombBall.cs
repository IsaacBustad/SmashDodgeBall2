using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : BallDamageDecorator, IEffects
{
    public ArmedContext ballState;

    public AudioClip audio;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        ballState = new ArmedContext();
    }

    // Update is called once per frame
    void Update()
    {
        ballEffect();
    }

    // Strategy pattern
    public void ballEffect()
    {
        if (ballState.getState())
        {

            if (hasPlayed == false)
            {
                // Spin noise effect
                AudioSource.PlayClipAtPoint(audio, gameObject.transform.position, 200);
                hasPlayed = true;
            }
        }
        else
        {
            ballState.setState(new StateArmed());

        }

    }

    // Decorator pattern
    public BombBall(BallDamageElement be) : base(be)
    {
    }

    public override float DamageNumber()
    {
        return base.element.DamageNumber() + 20f;
    }
    public override float KnockbackNumber()
    {
        return base.element.KnockbackNumber() + 5f;
    }
}
