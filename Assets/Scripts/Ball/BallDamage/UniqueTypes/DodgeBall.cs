using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBall : BallDamageDecorator, IEffects
{
    public ArmedContext ballState;

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

        }
        else
        {
            ballState.setState(new StateArmed());

        }

    }

    // Decorator pattern
    public DodgeBall(BallDamageElement be) : base(be)
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
