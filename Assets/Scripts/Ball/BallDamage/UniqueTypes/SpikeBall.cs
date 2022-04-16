using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : BallDamageDecorator, IEffects
{
    public int mass = 5;

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
        Debug.Log(ballState.getState());
        if (ballState.getState())
        {

            if (hasPlayed == false)
            {
                // Metal sound effect
                AudioSource.PlayClipAtPoint(audio, gameObject.transform.position, 3);
                hasPlayed = true;
            }
        }
        else
        {
            ballState.setState(new StateArmed());

        }
    }
        
    public SpikeBall(BallDamageElement be) : base(be)
    {

    }

    public override float DamageNumber()
    {
        return base.element.DamageNumber() + 6f;
    }
    public override float KnockbackNumber()
    {
        return base.element.KnockbackNumber() + 0.25f;
    }
}
