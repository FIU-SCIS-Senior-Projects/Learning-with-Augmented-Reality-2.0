using UnityEngine;
using System.Collections;

public class GetPath : MonoBehaviour {

    public GameObject[] allPaths;

	// Use this for initialization
	void Start () {

        //for random path
        //int num = Random.Range(0, allPaths.Length);
        int num = 0;

        transform.position = allPaths[num].transform.position;

        MoveOnPath myPath = GetComponent<MoveOnPath>();
        myPath.pathName = allPaths[num].name;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
