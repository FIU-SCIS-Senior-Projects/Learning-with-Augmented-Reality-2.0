using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
[RequireComponent (typeof(MeshRenderer))]
public class Colorizer : MonoBehaviour
{
    public Color diffuseColor;
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 5f)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.clear);
        }
        else
        {
            gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", diffuseColor);
        }
        //renderer.shareMaterial.SetColor("_Color", diffuseColor); //for every object that uses the material
        //renderer.material.SetColor("_Color", diffuseColor); //for this object's material
    }
}
