using UnityEngine;
using System.Collections;
using System;

public class Exceptions : MonoBehaviour {

    public string input;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int i;

        try
        {
            i = int.Parse(input);

            throw new Exception("null");
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);

            i = 0;
        }
        Debug.Log("i = " + i);
	}
}
