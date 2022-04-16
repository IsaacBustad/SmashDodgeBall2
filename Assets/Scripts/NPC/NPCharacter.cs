// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  This is the context for the state machine

public class NPCharacter : MonoBehaviour
{

    private INPCState state;
    private CharacterBroadcast myCharacterBroadcast;

    private List<GameObject> allBalls = new List<GameObject>();
    private List<GameObject> allPlayers = new List<GameObject>();
    private List<GameObject> eligibleBalls = new List<GameObject>();
    private List<GameObject> eligiblePlayers = new List<GameObject>();
    private GameObject closestBall;
    private GameObject closestEnemy;

    public Singleton daSingleton = Singleton.Instance;

    private GameObject divider;
    private Rigidbody rb;
    private CharacterState myCharState;
    private float lowestDistance;

    private float dividerThickness;



    [SerializeField] private Animator myAnimator;
    [SerializeField] private HasBallS hasBallState;
    [SerializeField] private NoBallS noBallState;
    [SerializeField] private OutS outState;
    [SerializeField] public Thrower myThrower;


    void Awake()
    {
        myCharacterBroadcast = this.gameObject.GetComponent<CharacterBroadcast>();
        Rb = this.gameObject.GetComponent<Rigidbody>();
        myCharState = gameObject.GetComponent<CharacterState>();
        Divider = GameObject.FindGameObjectWithTag("Divider");

        HasBallState = gameObject.GetComponent<HasBallS>();
        NoBallState = gameObject.GetComponent<NoBallS>();
        OutState = gameObject.GetComponent<OutS>();

        this.state = NoBallState;



        //***************************************************************************
        if ((GameObject.FindObjectOfType<Ball>().gameObject.layer == 7 && this.gameObject.layer == 9) || (GameObject.FindObjectOfType<Ball>().gameObject.layer == 8 && this.gameObject.layer == 10))
        {
            AllBalls.Add(GameObject.FindObjectOfType<Ball>().gameObject);
        }
        

        //***************************************************************************

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        if (AllBalls.Count > 0)
        {
            Debug.Log("State: " + this.State);
            GoGetBall();
        }

        ThrowBall();


    }

    public void GoGetBall()
    {
        state.GoGetBall();
    }
    public void GetHit(Collision aCollision)
    {
        state.GetHit(aCollision);
    }
    public void ThrowBall()
    {
        state.ThrowBall();
    }
    public void YoureIn()
    {
        state.YoureIn();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Ball collisionObject = collision.gameObject.GetComponent<Ball>();
        if (collisionObject != null)
        {
            GetHit(collision);
        }
        
    }


    //************************************************************************************************************************************
    // State-Independent methods
    //
    //

    public void updateObserver(List<GameObject> aListOfBalls)
    {
        AllBalls = aListOfBalls;
    }
    public GameObject FindClosestBall()
    {
        GameObject closestBall = null;
        //Loop through list of AllBalls and update Eligible Balls

            foreach (var p in AllBalls)
            {
                if ((p.layer == 7 && this.gameObject.layer == 9) || (p.layer == 8 && this.gameObject.layer == 10))
                {
                    if (!EligibleBalls.Contains(p))
                    { EligibleBalls.Add(p); }
                }
                else
                {
                    if (EligibleBalls.Contains(p))
                    { EligibleBalls.Remove(p); }
                }
            }
            // Find ball with lowest distance
            foreach (var p in EligibleBalls)
            {
                float distance = (p.transform.position - this.transform.position).magnitude;

                if (closestBall == null)
                {
                    lowestDistance = distance;
                    closestBall = p;
                }
                else if (distance < lowestDistance)
                {
                    lowestDistance = distance;
                    closestBall = p;
                }
            }
            return closestBall;
        
    }

    public GameObject FindClosestEnemy()
    {
        closestEnemy = null;
        //Loop through list of AllPlayers and update EligiblePlayers
        foreach (var p in this.allPlayers)
        {
            if ((p.layer == 7 && this.gameObject.layer == 9) || (p.layer == 8 && this.gameObject.layer == 10))
            {
                if (!eligiblePlayers.Contains(p))
                { eligiblePlayers.Add(p); }
            }
            else
            {
                if (eligiblePlayers.Contains(p))
                { eligiblePlayers.Remove(p); }
            }
        }

        // Find enemy with lowest distance
        foreach (var p in eligiblePlayers)
        {
            float distance = (p.transform.position - this.transform.position).magnitude;

            if (closestEnemy == null)
            {
                lowestDistance = distance;
                closestEnemy = p;

            }
            else if (distance < lowestDistance)
            {
                lowestDistance = distance;
                closestEnemy = p;
            }

        }
        return closestEnemy;
    }

    public List<GameObject> AllBalls
    {
        get { return this.allBalls; }
        set { this.allBalls = value; }
    }
    public List<GameObject> EligibleBalls
    {
        get { return this.eligibleBalls; }
        set { this.eligibleBalls = value; }
    }

    public List<GameObject> AllPlayers
    {
        get { return this.allPlayers; }
        set { this.allPlayers = value; }
    }
    public List<GameObject> EligiblePlayers
    {
        get { return this.eligiblePlayers; }
        set { this.eligiblePlayers = value; }
    }
    public GameObject ClosestBall
    {
        get { return this.closestBall; }
        set { this.closestBall = value; }
    }
    public GameObject ClosestEnemy
    {
        get { return this.closestEnemy; }
        set { this.closestEnemy = value; }
    }
    public GameObject Divider
    {
        get { return this.divider; }
        set { this.divider = value; }
    }
    public float DividerThickness
    {
        get { return this.dividerThickness; }
        set { this.dividerThickness = value; }
    }
    public Rigidbody Rb
    {
        get { return this.rb; }
        set { this.rb = value; }
    }

    public CharacterState MyCharState
    {
        get { return this.myCharState; }
        set { this.myCharState = value; }
    }
    public INPCState State
    {
        get { return this.state; }
        set { this.state = value; }
    }
    public HasBallS HasBallState
    {
        get { return this.hasBallState; }
        set { this.hasBallState = value; }
    }
    public NoBallS NoBallState
    {
        get { return this.noBallState; }
        set { this.noBallState = value; }
    }
    public OutS OutState
    {
        get { return this.outState; }
        set { this.outState = value; }
    }


}
