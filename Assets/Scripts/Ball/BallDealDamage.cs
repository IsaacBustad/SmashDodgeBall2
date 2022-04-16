using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDealDamage : MonoBehaviour
{
    private bool isArmed = true;
    private Rigidbody rb;
    private Transform tf;
    private Ball myBall;
    private float mySpeedMult = 1f;

    public float MySpeedMult
    {
        set { mySpeedMult = value; }
    }

    public bool IsArmed
    {   
        set { isArmed = true; }
    }
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
        myBall = gameObject.GetComponent<Ball>();
        
    }

    private void FixedUpdate()
    {
        MoveTheBall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isArmed == true)
        {
            DoDammage(collision);
        }
        
       
    }

    public void MoveTheBall()
    {
        if (isArmed == true)
        {
            Vector3 mvPT = tf.position + new Vector3(0,0,1) * Time.deltaTime * mySpeedMult;
            rb.MovePosition( mvPT * mySpeedMult);
            Debug.Log(mvPT);
        }
        
    }



    private void DoDammage(Collision collision)
    {
        Debug.Log("found");
        CharHealth charHealth = collision.transform.gameObject.GetComponent<CharHealth>();
        Debug.Log(collision.transform.gameObject.name);

        if (charHealth != null)
        {
            Debug.Log("health");
            charHealth.TakeDammage(myBall.damageElement.DamageNumber(), myBall.damageElement.KnockbackNumber(), this.gameObject.transform);
            Destroy(this.gameObject, 1f);
        }
        else
        {
            isArmed = false;
        }
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
