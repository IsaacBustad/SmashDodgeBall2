// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasBallS : MonoBehaviour, INPCState
{

    private NPCharacter NPC;
    private Vector3 borderLinePoint;
    private GameObject closestEnemy;
    private GameObject divider;

    private int redBallLayer = 7;
    private int blueBallLayer = 8;
    private int redPlayerLayer = 9;
    private int bluePlayerLayer = 10;







    void Awake()
    {
        NPC = gameObject.GetComponent<NPCharacter>();

    }
    public void GoGetBall()
    {
        // Already have a ball
    }
    public void GetHit(Collision aCollision)
    {
        // Drop ball
        // Ball Layers:
        //      7 = isBallRed
        //      8 = isBallBlue
        //      9 = isPlayRed
        //      10 = isPlayBlue

        if (aCollision.gameObject.layer == redBallLayer && NPC.gameObject.layer == bluePlayerLayer)
        {
            NPC.myThrower.ballOBJ = null;
            NPC.myThrower.hasBall = false;
            NPC.State = NPC.NoBallState;
        }
        else if (aCollision.gameObject.layer == blueBallLayer && NPC.gameObject.layer == redPlayerLayer)
        {
            NPC.myThrower.ballOBJ = null;
            NPC.myThrower.hasBall = false;
            NPC.State = NPC.NoBallState;
        }
    }
    public void ThrowBall()
    {

        if (MoveToLine())
        {
            closestEnemy = NPC.FindClosestEnemy();
            Debug.Log("Closest Enemy: " + closestEnemy.name);

            // throw ball at them
            NPC.myThrower.startThrow = true;
            NPC.myThrower.ThrowBall(closestEnemy.transform);
            NPC.State = NPC.NoBallState;
        }

    }
    public void YoureIn()
    {
        // Meaningless when already in
    }
    public void MoveTo(Vector3 aPoint)
    {

        if (gameObject.layer == redPlayerLayer && aPoint.z >= 0)
        {
            aPoint.z = 0;
        }
        else if (gameObject.layer == bluePlayerLayer && aPoint.z <= 0)
        {
            aPoint.z = 0;
        }

        float distanceToPoint = (aPoint - this.transform.position).magnitude;
        if (distanceToPoint >= 5.0f)
        {
            Vector3 directionToPoint = (aPoint - this.NPC.transform.position).normalized;
            this.NPC.Rb.AddForce(directionToPoint * 20, ForceMode.Force);
        }

        if (distanceToPoint < 5.0f)
        {
            this.NPC.Rb.velocity = new Vector3(0, 0, 0);
        }

    }
    public bool MoveToLine()
    {
        Debug.Log("We're in MoveToLine");
        // Assume divider line is centered on y-axis
        borderLinePoint.x = NPC.transform.position.x;
        borderLinePoint.y = NPC.transform.position.y;
        borderLinePoint.z = 0;
        MoveTo(borderLinePoint);

        float distanceToPoint = (borderLinePoint - this.transform.position).magnitude;
        if (distanceToPoint < 5.0f)
        {
            return true;
        }
        else return false;

    }

    public override string ToString()
    {
        return "Has Ball State";
    }


}
