using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public IArmedState ballState;
    public IEffects effects;
    public BallDamageElement damageElement;
    public LayerMask ballLayer;
    public BallDamageDecorator damageDecorator = null;

    // Start is called before the first frame update
    void Start()
    {
        ballState = gameObject.GetComponent<IArmedState>();
        effects = gameObject.GetComponent<IEffects>();
        damageElement = gameObject.GetComponent<BallDamageElement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Damage should be here (On Collsion Trigger) 



    public void WrapBall()
    {
        //BallWrapper(damageElement);
    }
}
