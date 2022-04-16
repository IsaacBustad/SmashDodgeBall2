// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBallS : MonoBehaviour, INPCState
{
    private NPCharacter NPC;
    private Vector3 directionToBall;
    private float distanceToBall;
    private float lowestDistance;
    private GameObject closestBall;
    
    void Awake()
    {
        NPC = gameObject.GetComponent<NPCharacter>();
        
    }

    public void GoGetBall()
    {   //Find the closest ball. Move to it, and pick it up.
        Debug.Log("5");
        closestBall = NPC.FindClosestBall();
        MoveTo(closestBall.transform.position);
        PickUpBall(closestBall);
        Debug.Log("NoBallS, GoGetBall");
    }
    public void GetHit(Collision aCollision)
    {
        // NPC got hit while not holding a ball - you're out!
        // MMM - Take NPC out of the game
        // When an NPC is out, it gets taken out of play and put on a stack
        NPC.daSingleton.OutPlayers.Enqueue(this.NPC.gameObject);
        NPC.State = NPC.OutState;

    }
    public void ThrowBall()
    {
        // No ball, so can't throw
    }
    public void YoureIn()
    {
        // Meaningless
    }
    


    public void MoveTo(Vector3 aPoint)
    {
        Vector3 directionToPoint = (aPoint - this.NPC.transform.position).normalized;
        NPC.Rb.AddForce(directionToPoint * 20, ForceMode.Force);
        Debug.Log("NoBallS, MoveTo");
    }


    public void PickUpBall(GameObject aBall)
    {
        
        distanceToBall = (closestBall.transform.position - this.transform.position).magnitude;
        if (!NPC.myThrower.hasBall && distanceToBall < 5.0f)
        {
            Debug.Log("NoBallS, PickUpBall");
            NPC.myThrower.ballOBJ = aBall;
            NPC.myThrower.hasBall = true;
            NPC.State = NPC.HasBallState;
        }

    }

    public override string ToString()
    {
        return "No Ball State";
    }
}

