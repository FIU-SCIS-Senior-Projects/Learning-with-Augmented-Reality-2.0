using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorPathScript : MonoBehaviour
{

    public Color heatColor = Color.red;
    public List<Transform> pathObjects = new List<Transform>();
    private Transform[] theArray;

	void OnDrawGizmos()
    {
        Gizmos.color = heatColor;
        theArray = GetComponentsInChildren<Transform>();
        pathObjects.Clear();

        foreach(Transform pathObj in theArray)
        {
            if(pathObj != this.transform)
            {
                pathObjects.Add(pathObj);
            }
        }

        for(int i = 0; i < pathObjects.Count; i++)
        {
            Vector3 position = pathObjects[i].position;
            if(i>0)
            {
                Vector3 previous = pathObjects[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }

    }

}
