using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ball is super fast! Fire particle
public class WheelBall : BallDamageDecorator, IEffects
{
    public int rotationSpeed = 500;

    public ArmedContext ballState;
    public Thrower thrower;

    public AudioClip audio;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        ballState = new ArmedContext();
        thrower = FindObjectOfType<Thrower>();
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
            // Spin 
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

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
    public WheelBall(BallDamageElement be) : base(be)
    {
    }

    public override float DamageNumber()
    {
        return base.element.DamageNumber() + 5f;
    }
    public override float KnockbackNumber()
    {
        return base.element.KnockbackNumber() + 3f;
    }
}
