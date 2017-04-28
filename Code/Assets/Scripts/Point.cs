using UnityEngine;
using System.Collections;
using System;

public class Point : MonoBehaviour {

    //GLOBAL VARIABLES
    Vector3 loc = new Vector3(0, 0, 0);
    Vector3 changeRate = new Vector3();

    Vector3 acc = new Vector3(0, 0, 0);
    Vector3 den = new Vector3(0, 2, 0);

    //CONSTRUCTOR
    public Point(Vector3 location)
    {
        loc = location;
    }


    //FUNCTIONS
    public void run()
    {
        
        radiation();
        //density();
        //convection();
        //conduction();
    }

    void density()
    {

    }

    void radiation()
    {

    }

	// Use this for initialization
	void Start () {

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }
	
	// Update is called once per frame
	void Update () {

        

    }

    public static explicit operator Point(int v)
    {
        throw new NotImplementedException();
    }
}
