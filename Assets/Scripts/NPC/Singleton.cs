using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Singleton : ISubject
{
    private static Singleton instance = null;
    private List<GameObject> allBalls;
    private List<GameObject> allPlayers;
    private List<CharacterBroadcast> observers;

    public Queue<GameObject> OutPlayers = new Queue<GameObject>();

    private Singleton()
    {

    }
    public static Singleton Instance
    {
        get
        {
            if(Singleton.instance == null)
            {
                Singleton.instance = new Singleton();
                Singleton.instance.observers = new List<CharacterBroadcast>();
                return Singleton.instance;
            }
            else
            {
                return Singleton.instance;
            }
        }
    }


    public void RegisterObserver(CharacterBroadcast g)
    {
        this.observers.Add(g);
        this.AllPlayers.Add(g.gameObject);
        Notify();
    }
    public void RemoveObserver(CharacterBroadcast o)
    {
        this.observers.Remove(o);
    }
    public void BallUpdated(List<GameObject> newBalls)
    {
        this.AllBalls = newBalls;
        Notify();
    }
    public void Notify()
    {
        foreach(var o in observers)
        {
            o.updateObserver(AllBalls, AllPlayers);
        }
    }


    public List<GameObject> AllBalls
    {
        get { return this.allBalls; }
        set { this.allBalls = value; }
    }
    public List<GameObject> AllPlayers
    {
        get { return this.allPlayers; }
        set { this.allPlayers = value; }
    }
}
