using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBroadcast : MonoBehaviour, IObserver
{
    private NPCharacter myNPC;
    public void updateObserver(List<GameObject> aListOfBalls, List<GameObject> aListOfPlayers)
    {
        myNPC.AllBalls = aListOfBalls;
        myNPC.AllPlayers = aListOfPlayers;
    }

    private void Awake()
    {
        myNPC = this.gameObject.GetComponent<NPCharacter>();
        myNPC.daSingleton.RegisterObserver(this);

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
