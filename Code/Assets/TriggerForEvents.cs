using UnityEngine;
using System.Collections;

public class TriggerForEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("TriggerHit");

        //switch (col.tag)
        //{
        //    case "MechanicalRoom":
        //        //DisableComponents(mechanicalRoomDoors);
        //        Debug.Log("TriggerHit");
        //        break;
        //}
    }
}
