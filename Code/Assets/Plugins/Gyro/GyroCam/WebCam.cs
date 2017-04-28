using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class WebCam : MonoBehaviour
{
    WebCamTexture webCam;

	//public int flipValue;
	//public Canvas canvas;
	//public float scaleFactor;
	//public CanvasScale myCanvasScale;

    IEnumerator Start()
    {
		//Screen.Orientation = ScreenOrientation.AutoRotation;

		//canvas = GetType (Canvas);
		//scaleFactor = canvas.scaleFactor;
 
        //creates new webcamTexture called webCam
		webCam = new WebCamTexture(Screen.width, Screen.height);
		//webCam = new WebCamTexture((int)myCanvasScale.width, (int)myCanvasScale.height);

        webCam.Play();

        //neccesary for the corountine
        while (!webCam.didUpdateThisFrame) yield return null;

        //adds the webcam texture to the game object this script is attached to, which is the quad mesh
        GetComponent<Renderer>().material.mainTexture = webCam;

        //Gets the angle of view from the webcam and updates the quad mesh to the rotation around the negative z axis
		transform.localRotation = Quaternion.AngleAxis(webCam.videoRotationAngle, -Vector3.forward);

        Debug.Log("WebCamTexture: " + webCam.width + ", " + webCam.height);

        
    }

	public void Update()
	{
		//var sy = 3.0f * myCanvasScale.width / myCanvasScale.height;
		//var sx = sy * webCam.width / webCam.height;

		//makes sure the quad mesh is always scaled appropriately to the camera distance from the object
		var sy = 1.55f * Screen.width / Screen.height; //2.0 changed to 3.0
		var sx = sy * webCam.width / webCam.height; // Add a - to build on Android

		transform.localScale = new Vector3(-sx, sy, 1);
	}

} 

