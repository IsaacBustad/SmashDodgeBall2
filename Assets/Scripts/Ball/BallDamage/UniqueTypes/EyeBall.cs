using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : BallDamageDecorator, IEffects
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
        Debug.Log(ballState.getState());
        if (ballState.getState())
        {

            if (hasPlayed == false)
            {
                // Spin noise effect
                AudioSource.PlayClipAtPoint(audio, gameObject.transform.position, 3);
                hasPlayed = true;
            }
        }
        else
        {
            ballState.setState(new StateArmed());

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NPC")
        {
            // Blind player for 5 seconds or makes NPC unable to throw for 5 seconds
           
        }
    }

    public EyeBall(BallDamageElement be) : base(be)
    {
    }

    public override float DamageNumber()
    {
        return base.element.DamageNumber() + 1f;
    }
    public override float KnockbackNumber()
    {
        return base.element.KnockbackNumber() + 1f;
    }
}
