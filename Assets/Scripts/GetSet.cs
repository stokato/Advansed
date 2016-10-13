using UnityEngine;
using System.Collections;

public class GetSet : MonoBehaviour {

    class GetAndSet
    {
        public delegate void MyIntHandler(int i);
        public event MyIntHandler MyIntEvent;

        private int myInt;

        public int MyInt {
            get { return myInt; }
            set
            {
                myInt = value;

                if(MyIntEvent != null)
                {
                   MyIntEvent(myInt);
                }

                //MyIntEvent?.Invoke(myInt);
            }
        }

        public int doubleInt
        {
            get { return myInt * 2; }
        }
    }

	// Use this for initialization
	void Start () {
        GetAndSet gs = new GetAndSet();
        gs.MyIntEvent += IntChanged; ;

        gs.MyInt = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void IntChanged(int i)
    {
        Debug.Log("change! " + i);
    }
}
