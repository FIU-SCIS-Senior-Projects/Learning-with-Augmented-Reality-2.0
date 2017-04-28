using UnityEngine;
using System.Collections;

public class ChangeSkybox : MonoBehaviour {

    public Material startingSky;
    //public Material updateSky;

    void Awake()
    {
        startingSky = RenderSettings.skybox;
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggleSkybox(Material sky)
    {
        if(RenderSettings.skybox == startingSky)
        {
            RenderSettings.skybox = sky;
        }
        else
        {
            RenderSettings.skybox = startingSky;
        }        
    }
}
