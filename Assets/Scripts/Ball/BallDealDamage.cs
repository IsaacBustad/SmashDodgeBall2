using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDealDamage : MonoBehaviour
{
    private bool isArmed = false;
    private Rigidbody rb;
    private Transform tf;
    private Ball myBall;
    private float mySpeedMult = 1f;
    private float maxVel = 1;
    private LayerMask myBallLayer;

    
    public LayerMask MyBallLayer
    {
        set { if (value == 7 || value == 8) { myBallLayer = value; } }
    }

    public float MaxVel
    {
        set { maxVel = value; }
    }
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

    // updates for physics Sys
    private void FixedUpdate()
    {
        MoveTheBall();
    }

    // sence collison
    private void OnCollisionEnter(Collision collision)
    {
        if (isArmed == true)
        {
            DoDammage(collision);
        }
        
       
    }

    // moave ball when armed
    private void MoveTheBall()
    {
        if (isArmed == true)
        {
            /*Vector3 mvPT = tf.position + new Vector3(0,0,1) * Time.deltaTime * mySpeedMult;
            rb.MovePosition( mvPT * mySpeedMult);
            Debug.Log(mvPT);*/

            rb.AddForce(gameObject.transform.forward * 50, ForceMode.Force);
            LimitBallVell();
        }
        
    }

    // limit velocity
    private void LimitBallVell()
    {
        if (rb.velocity.magnitude > maxVel)
        {
            Vector3 limitedVel = rb.velocity.normalized * maxVel;
            rb.velocity = limitedVel;
        }
    }

    private void DoDammage(Collision collision)
    {
        Debug.Log("found");
        CharHealth charHealth = collision.transform.gameObject.GetComponent<CharHealth>();
        Debug.Log(collision.transform.gameObject.name);

        if (charHealth != null)
        {
            if (EnemyTeam(collision))
            {
                Debug.Log("health");
                charHealth.TakeDammage(myBall.damageElement.DamageNumber(), myBall.damageElement.KnockbackNumber(), this.gameObject.transform);
                Destroy(this.gameObject, 1f);
            }
        }
        isArmed = false;
        myBall.ResetBaseDamage();
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    private bool EnemyTeam(Collision collision)
    {
        if (myBall.gameObject.layer == 7 && collision.gameObject.layer == 10) { return true; } 
        else if (myBall.gameObject.layer == 8 && collision.gameObject.layer == 9) { return true; } 
        else { return false; }
    }
}
