using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDodgeBall : Ball
{

    // Start is called before the first frame update
    void Start()
    {
        damageElement = new BallBaseDamage();
    }
}
