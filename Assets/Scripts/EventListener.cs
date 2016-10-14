using UnityEngine;
using System.Collections;
using System;

public class EventListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventDispatcher dispatcher = GameObject.Find("Main Camera").GetComponent<EventDispatcher>();
        dispatcher.OnEvent += CallMeMaybe;
        dispatcher.ProperEvent += CallMePlease;
	}

    void CallMeMaybe()
    {
        Debug.Log("here's my number");
    }

    void CallMePlease(object sender, EventArgs e)
    {
        Debug.Log(sender);

        MyEventArgs args = (MyEventArgs) e;
        Debug.Log(args.MyNumber);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
