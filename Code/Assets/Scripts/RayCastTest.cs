using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class RayCastTest : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		 string name;
		 float distance;
		
		if(Input.GetMouseButtonDown(0)){
			
			Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rhinfo;
			bool didHit = Physics.Raycast(toMouse, out rhinfo, 5000.0f);
			
			if(didHit){
				name = rhinfo.collider.name;
				distance = rhinfo.distance;
				Debug.Log(rhinfo.collider.name+ "   " + rhinfo.point+ "    "+ rhinfo.distance);
				
			}
			
			else {
				Debug.Log("Please click on a valid object");
			}
							
		}
		

		
}
}