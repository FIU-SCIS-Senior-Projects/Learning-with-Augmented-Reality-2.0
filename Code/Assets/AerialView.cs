using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;

public class AerialView : MonoBehaviour
{

    //public GameObject fps;
    //public GameObject fps2;
    //public GameObject heavy;
    //public GameObject sun;
    //public GameObject soil;
    //public GameObject wind;
    //public GameObject path;
    //private Camera cam;
    //private Camera cam2;
    ////private FirstPersonController controller;
    //public Transform aerialPoint;
    //public List<GameObject> hideObjects = new List<GameObject>();
    //public List<Camera> hideCams = new List<Camera>();

    //public GameObject sunPanel;
    //public GameObject windPanel;
    //private List<AppearWithProx> appears = new List<AppearWithProx>();

    //void Start()
    //{
    //    appears.Add(sun.GetComponent<AppearWithProx>());
    //    appears.Add(wind.GetComponent<AppearWithProx>());
    //    appears.Add(soil.GetComponent<AppearWithProx>());

    //    //Starts as sunny sky
    //    RenderSettings.skybox = Organized.Instance.sunnySky;

    //    cam = fps.GetComponentInChildren<Camera>();
    //    cam2 = fps2.GetComponentInChildren<Camera>();

    //    hideCams.Add(cam);
    //    hideCams.Add(cam2);

    //    hideObjects.Add(fps);
    //    hideObjects.Add(fps2);
    //    hideObjects.Add(heavy);
    //    hideObjects.Add(sun);
    //    hideObjects.Add(path);
    //    hideObjects.Add(wind);
    //    hideObjects.Add(soil);
    //    //hideObjects.Add(sunPanel);

    //    //defaultSky = (Material)Resources.Load("Skybox (Gradient)");

    //    //Turns the skycamera off
    //    cam2.enabled = false;
    //    //Turns the skyfps off
    //    fps2.SetActive(false);

    //}

    //void OnEnable()
    //{
    //    EventManager.StartListening("Sun", activateData);
    //    EventManager.StartListening("Wind", activateData);
    //}

    //void OnDisable()
    //{
    //    EventManager.StopListening("Sun", activateData);
    //    EventManager.StopListening("Wind", activateData);
    //}

    //public void activateData()
    //{
    //    //if (ray().Equals("Sun"))
    //    EventManager.TriggerEvent("SunDiagramActive");
    //    {
    //        toggleCam(hideCams);
    //        if (windPanel.activeSelf == true)
    //        {
    //            windPanel.SetActive(false);
    //        }
    //       /*
    //        for(int i = 0; i < appears.Count; i++)
    //        {
    //            appears[i].enabled = false;
    //        }
    //        */
    //        sunPanel.SetActive(true); //this is now being activated by diagramState
    //        Organized.Instance.toggle(hideObjects);
    //        setDefualtSkybox();

    //        //Turns the ground camera off
    //        cam.enabled = false;
    //        //Turns the groundfps off
    //        fps.SetActive(false);

    //        //Turns the skyfps on
    //        fps2.SetActive(true);
    //        //Turns the skycam on
    //        cam2.enabled = true;
    //    }
        
    //    /*if (ray().Equals("Wind"))
    //    {
    //        toggleCam(hideCams);
    //        toggle(hideObjects);
    //        if(sunPanel.activeSelf == true)
    //        {
    //            sunPanel.SetActive(false);
    //        }
    //        /*
    //        for (int i = 0; i < appears.Count; i++)
    //        {
    //            appears[i].enabled = false;
    //        }
            
    //    windPanel.SetActive(true);
    //    setDefualtSkybox();
    //    }
    //    */
    //}

    ///*
    //void Update()
    //{
    //    if (ray().Equals("Sun"))
    //    {
    //        toggleCam(hideCams);
    //        if (windPanel.activeSelf == true)
    //        {
    //            windPanel.SetActive(false);
    //        }
    //        /*
    //        for(int i = 0; i < appears.Count; i++)
    //        {
    //            appears[i].enabled = false;
    //        }
    //        */
    //        /* sunPanel.SetActive(true); //this is now being activated by diagramState
    //         toggle(hideObjects);
    //         setDefualtSkybox();

    //         /*
    //         //Turns the ground camera off
    //         cam.enabled = false;
    //         //Turns the groundfps off
    //         fps.SetActive(false);

    //         //Turns the skyfps on
    //         fps2.SetActive(true);
    //         //Turns the skycam on
    //         cam2.enabled = true;
    //         */
    //        //}
    //        /*
    //        if (ray().Equals("Wind"))
    //        {
    //            toggleCam(hideCams);
    //            toggle(hideObjects);
    //            if(sunPanel.activeSelf == true)
    //            {
    //                sunPanel.SetActive(false);
    //            }
    //            /*
    //            for (int i = 0; i < appears.Count; i++)
    //            {
    //                appears[i].enabled = false;
    //            }
    //            */
    //        /*
    //        windPanel.SetActive(true);
    //        setDefualtSkybox();
    //    }

    //        //if (Input.GetKeyDown(KeyCode.Z))
    //        //{

    //        /*
    //        //Turns the ground camera off
    //        cam2.enabled = false;
    //        //Turns the groundfps off
    //        fps2.SetActive(false);

    //        //Turns the skyfps on
    //        fps.SetActive(true);
    //        //Turns the skycam on
    //        cam.enabled = true;
    //        */
    //        //}
    //        // }

    //public void returnToGround()
    //{
    //    toggleCam(hideCams);
    //    Organized.Instance.toggle(hideObjects);
    //    Organized.Instance.changeSkybox();
    //    if (sunPanel.activeSelf == true)
    //    {
    //        sunPanel.SetActive(false);
    //    }
    //    if (windPanel.activeSelf == true)
    //    {
    //        windPanel.SetActive(false);
    //    }
    //}

    //public void setDefualtSkybox()
    //{
    //    if (RenderSettings.skybox == Organized.Instance.sunnySky)
    //    {
    //        //Debug.Log("Update Sky");
    //        RenderSettings.skybox = Organized.Instance.defaultSky;
    //    }
    //    else
    //    {
    //        //Debug.Log("Sunny Sky");
    //        RenderSettings.skybox = Organized.Instance.sunnySky;
    //    }
    //}

    ////Toggles objects in list
    //public void toggleCam(List<Camera> hide)
    //{
    //    for (int i = 0; i < hide.Count; i++)
    //    {
    //        if (hide[i].enabled == true)
    //        {
    //            //Debug.Log("active is true");
    //            hide[i].enabled = false;
    //        }
    //        else
    //        {
    //            //Debug.Log("active is false");
    //            hide[i].enabled = true;
    //        }
    //    }
    //}

    //public string ray()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //Debug.Log("Ray was called in class: " + this);

    //        RaycastHit hit = new RaycastHit();

    //        //if raycast hit
    //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) //pulse.maxDistance))
    //        {
    //            if (hit.collider.tag == "Sun")
    //            {
    //                //Debug.Log("Sun Hit!");
    //                EventManager.TriggerEvent("SunDiagramActive");
    //                return "Sun";
    //            }

    //            if (hit.collider.tag == "Wind")
    //            {
    //                //Debug.Log("Wind Hit!");
    //                //EventManager.TriggerEvent("WindDiagramActive");
    //                return "Wind";
    //            }
    //        }
    //    }
    //    return "";
    //}
}









    