using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBallBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 1f;
    }

    public override float KnockbackNumber()
    {
        return 1f;
    }
}