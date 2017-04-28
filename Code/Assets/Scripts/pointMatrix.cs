using UnityEngine;
using System.Collections;

public class pointMatrix : MonoBehaviour {

    //DECLARE
    ArrayList pointCollection;
    int xValue = 10;
    int yValue = 10;
    int zValue = 10;

	// Use this for initialization
	void Start () {

        pointCollection = new ArrayList();

        for (int i = 0; i > xValue; i++)
        {
            Vector3 origin = new Vector3(Random.Range(0,200), Random.Range(0,200), 0);
            Point myPoint = new Point(origin);
            pointCollection.Add(myPoint);

        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //Call Functionality
        for (int i = 0; i < pointCollection.IndexOf(i); i++)
            {
            Point mp = (Point) pointCollection.IndexOf(i);
            mp.run();
        }
	}
}
