using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

	public float speed;

	void Update ()
	{
//		transform.localPosition += transform.forward * speed * Time.deltaTime;
		float factor = 1f;
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			factor = 5f;
		}
		transform.localPosition += transform.forward * speed * Time.deltaTime * Input.GetAxis ("Vertical") * factor;
		transform.localPosition += transform.right * speed * Time.deltaTime * Input.GetAxis ("Horizontal") * factor;
	}
}
