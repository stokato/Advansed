using UnityEngine;
using System.Collections;

public class Generic : MonoBehaviour {

    public void log<T> (T thing)
    {
        string s = thing.ToString();
        Debug.Log(s);
    }

    public void swap<T>(ref T a, ref T b)
    {
        T temp = b;
        b = a;
        b = temp;
    }

    public class zombie
    {
        private string Name;

        public zombie(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

	// Use this for initialization
	void Start () {
        zombie first = new zombie("stubbs");
        zombie second = new zombie("jackson");

        Debug.Log(first);
        Debug.Log(second);

        swap(ref first, ref second);

        Debug.Log(first);
        Debug.Log(second);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
