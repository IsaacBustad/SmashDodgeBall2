using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOut : MonoBehaviour
{
    //singalton reff
    [SerializeField] private GameObject topObjContatiner;
    [SerializeField] private GameObject effect;
    // clip

    public void RingOut()
    {
        GameObject anEfect = Instantiate(effect, this.gameObject.transform.position, transform.rotation);
        Destroy(anEfect, 5);
        // play clip
        // remove from in play list
        topObjContatiner.SetActive(false);
    }
}
