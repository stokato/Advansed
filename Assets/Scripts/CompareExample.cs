using UnityEngine;
using System.Collections;

public class CompareExample : MonoBehaviour {

    public GameObject[] SortedByDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ArrayList ObjectList = new ArrayList();
        GameObject[] Objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];

        foreach (GameObject go in Objects)
        {
            ObjectList.Add(go);
        }

        DistanceComparer dComparer = new DistanceComparer();

        dComparer.Target = this.gameObject;
        ObjectList.Sort(dComparer);

        SortedByDistance = new GameObject[ObjectList.Count];
        ObjectList.CopyTo(SortedByDistance);
	}
}
