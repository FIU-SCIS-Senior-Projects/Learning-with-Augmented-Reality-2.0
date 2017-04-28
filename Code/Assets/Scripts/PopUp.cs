using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

		public GameObject panel;
		public GameObject panel1;
	
	 public void OnMouseButtonDown()
     {
         if(Input.GetMouseButtonDown(0))
             panel.SetActive(true);

     }
	 
	  public void OnMouseButtonDown1()
     {
         if(Input.GetMouseButtonDown(0))
             panel1.SetActive(true);

     }
}
