using UnityEngine;
using System.Collections;


public class ColorChange : MonoBehaviour {

     void OnMouseOver()
     {
         if(Input.GetMouseButtonDown(0))
             GetComponent<Renderer>().material.color = Color.red;
		 

     }
	 
	   /*void OnMouseOver(){
		   if (Input.OnMouseOver(0))
			   GetComponent<Renderer>().material.color = Color.red;
		   
	   }*/
 
}
