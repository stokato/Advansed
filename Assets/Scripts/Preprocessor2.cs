#define TESTING
using UnityEngine;
using System.Collections;
using System;

public class Preprocessor2 : MonoBehaviour {
    #region OFCHAOS
    // Use this for initialization
    void Start () {
        int playerHealth = 100;
#if TESTING
#warning DEBUG is on;
        playerHealth = 100000;
#endif
        if(playerHealth < 0)
        {
            Debug.Log("player has died");
        }
    }
    #endregion
    // Update is called once per frame
    void Update () {
	
	}
}
