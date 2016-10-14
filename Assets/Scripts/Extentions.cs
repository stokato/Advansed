using UnityEngine;
using System.Collections;
using Tricks;

public class Extentions : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.NewTrick();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

namespace Tricks
{
    using UnityEngine;
    using System.Collections;

    public static class GameObjectExtensions
    {
        public static void NewTrick(this GameObject go)
        {
            Debug.Log(go.name);
        }
    }
}