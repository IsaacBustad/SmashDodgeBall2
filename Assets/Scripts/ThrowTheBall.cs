using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTheBall : MonoBehaviour
{

    CharacterState myACS;
    [SerializeField] private Thrower myThrower;
    [SerializeField] private Transform tstTrans;
    bool ons1 = true;
    // Start is called before the first frame update
    void Start()
    {
        myACS = this.gameObject.GetComponent<CharacterState>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (ons1)
        {
            Debug.Log("XXXXXXXXXXX: " + tstTrans.position  );
            Debug.Log("XXXX: " + myACS.MyMoveState);
            myThrower.ThrowBall(myACS, tstTrans);
            ons1 = false;
        }
    }
}
