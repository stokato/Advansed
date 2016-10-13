using UnityEngine;
using System.Collections;

public class InterfaceExample : MonoBehaviour {

    public interface IThing
    {
        string ThingName { get; set; }
    }

    public class Toaster : IThing
    {
        private string ToasterName;

        public string ThingName
        {
            get
            {
                return ToasterName;
            } 
            set
            {
                ToasterName = value;
            }
        }
    }

	// Use this for initialization
	void Start () {
        Toaster T = new Toaster();
        T.ThingName = "Talkie";
        print(T.ThingName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
