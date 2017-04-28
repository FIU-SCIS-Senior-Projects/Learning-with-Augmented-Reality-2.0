using UnityEngine;
using System.Collections;

public class Air : MonoBehaviour {

    Vector3 loc;
    public int x;
    public int y;

    public int type = 0;

    public int futType = 0;

    //Constructor
    public Air(Vector3 _loc, int _x, int _y)
    {
        loc = _loc;
        x = _x;
        y = _y;

        /*
        //Try to rewrite this so that outside is red or (alive1) and inside is blue (dead0) 
        //Instead of random calculate the amount of z instances to wall for the range of type = 1
        float rnd = Random.Range(0,100);
        if (rnd <50)
        {
            type = 1;
        }
        */
    }

    //Functions
    void create()
    {
        GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    void updateType()
    {
        type = futType;
    }

    void run()
    {
        create();
    }
	
}
