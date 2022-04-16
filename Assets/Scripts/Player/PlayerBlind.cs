using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlind : MonoBehaviour
{
    [SerializeField]  private GameObject blindCan;
    [SerializeField] private float healthMult = 0.1f;

    private CharHealth health;


    private void Awake()
    {
        health = gameObject.GetComponent<CharHealth>();
    }

    public void BlindMe()
    {
        StartCoroutine(WaitBlind());
    }

    private IEnumerator WaitBlind()
    {
        blindCan.SetActive(true);
        yield return new WaitForSeconds(health.Health * healthMult);
        blindCan.SetActive(false);
    }

}
