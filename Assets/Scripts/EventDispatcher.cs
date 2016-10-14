using UnityEngine;
using System.Collections;
using System;

class MyEventArgs : EventArgs
{
    public string MyNumber;

    public MyEventArgs()
    {
        MyNumber = "I just met you";
    }
}

public delegate void EventHandler();
public delegate void ProperEventHandler(object sender, EventArgs e);

public class EventDispatcher : MonoBehaviour {

    public event EventHandler OnEvent;
    public event ProperEventHandler ProperEvent;

    public bool SendEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(SendEvent)
        {
            OnEvent();
            ProperEvent(this, new MyEventArgs());

            SendEvent = false;
        }
	}
}
