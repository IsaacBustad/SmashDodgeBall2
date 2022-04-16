using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBaseReset : BallDamageElement
{
    public override float DamageNumber()
    {
        return 0;
    }
    public override float KnockbackNumber()
    {
        return 0;
    }
}
