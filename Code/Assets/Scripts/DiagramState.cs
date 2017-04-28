using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class DiagramState : IEnvironmentState
{
    private readonly StatePatternEnvironment envi;

    public DiagramState(StatePatternEnvironment statePatternEnvi)
    {
        envi = statePatternEnvi;
    }

    public void OnTriggerPressed(Collider other)
    {

    }

    public void ToDiagramState()
    {
        Debug.Log("Can't transition to same state.");
    }

    public void ToMainState()
    {
        Debug.Log("Main State Activated");
        envi.currentState = envi.mainState;
    }

    public void ToMajorComponentState()
    {
        envi.currentState = envi.majorComponentState;
    }

    public void ToSubComponentState()
    {
        envi.currentState = envi.subComponentState;
    }

    public void ToBuildState()
    {
        envi.currentState = envi.buildState;
    }

    public void ToMechanicalState()
    {
        envi.currentState = envi.mechanicalState;
    }

    public void ToMechanicalRoomState()
    {
        envi.currentState = envi.mechanicalRoomState;
    }

    public void UpdateState()
    {
        envi.timer += Time.deltaTime;
        if (envi.timer > 5f)
        {
            Debug.Log(envi.currentState);
            envi.timer = 0;
        }

        //returns collider.tag on click
        if (Input.GetMouseButtonDown(0))
        {
            OnTriggerClicked();
        }
    }

    public void OnTriggerClicked()
    {
        string collidertag = null;
        //Debug.Log(collidertag);
        List<string> tempEventNames = new List<string>();
        List<GameObject> systemsHit = new List<GameObject>();
        RaycastHit hit = new RaycastHit();

        //if raycast hits
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider != null)
            {
                collidertag = hit.collider.tag;
                Debug.Log(collidertag);

                //If its a SoilAnimation
                if (collidertag.Equals("SoilAnimation") || collidertag.Equals("Drainage"))
                {
                    //EventManager.TriggerEvent(collidertag);
                    envi.currentPlayerPos = Camera.main.transform;

                    //Add collider tag as an event
                    tempEventNames.Add(collidertag);

                    //Organized.Instance.panelDictionary["Panel_Soil"].SetActive(false);

                    //Broadcast the events
                    envi.BroadcastEvents(tempEventNames);
                    ToMainState();
                }
            }
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("Return", ToMainState);
        //ReturnButton.OnClicked += ToMainState;
    }

    void OnDisable()
    {
        EventManager.StopListening("Return", ToMainState);
        //ReturnButton.OnClicked -= ToMainState;
    }
}