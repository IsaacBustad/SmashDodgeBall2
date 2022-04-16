using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHealth : MonoBehaviour
{
    // test key
    private KeyCode tk = KeyCode.L;


    private CharacterState myCS;
    public float healthDamMult = 0.000000000000000000005f;
    private Vector3 vz = new Vector3(0f,0f,0f);
    private float healthRecMult = 0.01f;
    // orientation obj is for getting rot dir info only
    [SerializeField] private Transform orientation;
    [SerializeField] private Thrower myThrower;
    private Transform playerTf;
    private Rigidbody rb;
    //public Transform aTf;

    [Header("Do not edit")]
    [SerializeField] private float health = 0f;

    //read only
    public float Health
    {
        get { return this.health; }
    }

    // constructor
    public void Awake()
    {
        playerTf = gameObject.GetComponent<Transform>();
        myCS = gameObject.GetComponent<CharacterState>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // test meth
    /*private void Update()
    {
        if (Input.GetKeyDown(tk))
        {
            Vector3 tv3 = new Vector3(0f, 0f,0f);
            TakeDammage(5f,10f, tv3);
        }
    }*/

    // methods
    public void TakeDammage(float dam, float knock, Transform collPt)
    {        
        myCS.IsHit();
        rb.velocity = vz;
        health += dam;
        myThrower.hasBall = false;
        KnockBack(knock, collPt);
        //KnockBack(knock, aTf);        
    }

    private void KnockBack(float knock, Transform colTf)
    {
        rb.velocity = vz;
        
        //orientation.LookAt(collDir);
        //playerTf.rotation = Quaternion.Euler(0, orientation.rotation.y, 0); 
        //rb.AddForce(collDir * knock * (health * healthDamMult), ForceMode.Impulse);
        Vector3 direction = (colTf.position - playerTf.position) * (-1f);
        rb.AddForce(new Vector3(direction.x , 1, direction.z).normalized  * (health * knock), ForceMode.Impulse);
        StopAllCoroutines();
        StartCoroutine(WaitToRecover());
        gameObject.GetComponent<PlayerBlind>().BlindMe();
    }

    // coroutines
    // wait to recover
    private IEnumerator WaitToRecover()
    {
        myCS.IsHit();
        yield return new WaitForSeconds(health * healthRecMult);
        myCS.IsIdle();
    }

}
