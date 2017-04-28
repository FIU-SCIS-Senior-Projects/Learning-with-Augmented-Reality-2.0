using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    public GameObject boundingObj;

    // Use this for initialization
    void Start () {

        Mesh volume = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = volume.vertices;
        Bounds bounds = volume.bounds;

        Debug.Log("Volume is:" + volume.bounds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
