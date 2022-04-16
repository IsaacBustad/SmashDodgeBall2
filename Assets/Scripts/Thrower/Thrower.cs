//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    //private KeyCode throwKey = KeyCode.Mouse0;
    private Transform tf;
    public GameObject ballOBJ;

    public bool hasBall = false;
    public bool startThrow = false;

    [Header("Throw Variables")]
    [SerializeField] private float basePow = 15f;
    [SerializeField] private float powMultBase = 1f;
    [SerializeField] private float powMultMax = 1f;
    //[SerializeField] private float drawDistance = 300f;
    [SerializeField] private Transform sightLine;
    [SerializeField] public LayerMask ballLayer;
    [SerializeField] private Transform throwToward;
    private Transform ballHolder;

    private float powMult = 1f;
    private float timeToThrow = 1.333f;
    private WaitForSeconds waitToThrow;
    
    


    private void Awake()
    {
        ballHolder = gameObject.GetComponent<Transform>();
        waitToThrow = new WaitForSeconds(timeToThrow);

}

private void Update()
    {
        HoldBall();
    }

    

    private void HoldBall()
    {
        if (hasBall == true)
        {
            ballOBJ.transform.position = ballHolder.transform.position;
            ballOBJ.transform.rotation = ballHolder.transform.rotation;
        }        
    }

    public void WindUp()
    {
        powMult += Time.deltaTime;
        Mathf.Clamp(powMult,0f,powMultMax);
    }

    public void CallThrow(CharacterState aCS)
    {
        //aCS.myAnim.SetBool("IsThrow", true);
        ThrowBall(aCS);
        powMult = powMultBase;
        startThrow = false;
        hasBall = false;
    }

    public void ThrowBall(CharacterState aCS)
    {
        
        
        aCS.IsThrow();
        ballOBJ.GetComponent<Ball>().damageElement = MultWrapper(ballOBJ.GetComponent<Ball>().damageElement);
        //ballOBJ.GetComponent<BallState>().IsArmed();
        //ballOBJ.GetComponent<Ball>().ballLayer = ballLayer;

        hasBall = false;
        startThrow = false;
        ballOBJ.transform.LookAt(throwToward);
        ballOBJ.GetComponent<Rigidbody>().useGravity = false;
        ballOBJ.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        ballOBJ.GetComponent<BallDealDamage>().IsArmed = true;
        powMult = Mathf.Clamp(powMult,0f,powMultMax);
        //ballOBJ.GetComponent<Rigidbody>().AddForce(ballOBJ.transform.forward * basePow , ForceMode.Impulse);
        
        //Debug.Log(ballOBJ.GetComponent<Rigidbody>().useGravity = false);
        ballOBJ = null;
        //Debug.Log("pow mult" + powMult);
            
        //StartCoroutine(WaitThrowDur(aCS));
        
    }

    public void ThrowBall(CharacterState aCS, Transform targ )
    {
        
        
        aCS.IsThrow();
        ballOBJ.GetComponent<Ball>().damageElement = MultWrapper(ballOBJ.GetComponent<Ball>().damageElement);
        //ballOBJ.GetComponent<BallState>().IsArmed();
        ballOBJ.GetComponent<Ball>().ballLayer = ballLayer;

        hasBall = false;
        startThrow = false;
        ballOBJ.transform.LookAt(targ);

        ballOBJ.GetComponent<BallDealDamage>().IsArmed = true;
        ballOBJ.GetComponent<Rigidbody>().AddForce(ballOBJ.transform.forward * basePow * powMult, ForceMode.Impulse);
            
        //StartCoroutine(WaitThrowDur(aCS));
        
    }

    public void ThrowBall(Transform targ)
    {


        //aCS.IsThrow();
        ballOBJ.GetComponent<Ball>().damageElement = MultWrapper(ballOBJ.GetComponent<Ball>().damageElement);
        //ballOBJ.GetComponent<BallState>().IsArmed();
        //ballOBJ.GetComponent<Ball>().ballLayer = ballLayer;

        hasBall = false;
        startThrow = false;
        ballOBJ.transform.LookAt(targ);

        ballOBJ.GetComponent<Rigidbody>().AddForce(ballOBJ.transform.forward * basePow * powMult, ForceMode.Impulse);

        //StartCoroutine(WaitThrowDur(aCS));

    }

    private BallDamageDecorator MultWrapper(BallDamageElement bde)
    {
        return new PlayerBallDecorator(bde, powMult);
    }

    // coroutines
    private IEnumerator WaitThrowDur(CharacterState aCS)
    {
        yield return waitToThrow;
        aCS.IsIdle();
        //aCS.myAnim.SetBool("IsThrow", false);
    }
}
