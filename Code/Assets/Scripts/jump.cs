using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour
{
	public float moveSpeed = 10f;
	  
		
		void Update ()
		{
			
			bool down = Input.GetKeyDown(KeyCode.Space);
			bool held = Input.GetKey(KeyCode.Space);
			bool up = Input.GetKeyUp(KeyCode.Space);

			if (down)
				{
					transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
				}
			if (held)
				{
					transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
				}
			if (up)
				{
					transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
				}
		}
}