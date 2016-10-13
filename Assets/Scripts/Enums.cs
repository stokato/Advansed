using UnityEngine;
using System.Collections;

public class Enums : MonoBehaviour {

    int[] ints = { 3, 7, 11, 13, 17, 23 };

    class ZombieMaster : IEnumerable
    {
        public static string ZombieMasterName;

        private IZombieEnumerator Enumerator;

        public ZombieMaster(string name)
        {
            ZombieMasterName = name;
            Enumerator = new IZombieEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }
    }

    class IZombieEnumerator : IEnumerator
    {
        private string[] minions;
        private int NextMenion;

        public object Current
        {
            get { return minions[NextMenion]; }
        }

        public IZombieEnumerator()
        {
            minions = new string[] { "stubbs", "bernie", "michael" };
        }

        public bool MoveNext()
        {
            NextMenion++;
            if(NextMenion >= minions.Length)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public void Reset()
        {
            NextMenion = -1;
        }
    }
    
	// Use this for initialization
	void Start () {
        ZombieMaster zombieMaster = new ZombieMaster("bob");

        Debug.Log(ZombieMaster.ZombieMasterName);

        foreach (object obj in zombieMaster)
        {
            Debug.Log(obj.ToString());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
