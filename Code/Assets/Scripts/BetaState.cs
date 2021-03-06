﻿using UnityEngine;
using System.Collections.Generic;

public class BetaState : IARState
{
    private readonly StatePatternAR envi;

    public BetaState(StatePatternAR statePatternAR) { envi = statePatternAR; }

    public void UpdateState()
    {
        if (envi.isGetSubPanelCalled == true)
        {
            Description.Instance.setDescript(envi.currentSubPanelName);
            envi.isGetSubPanelCalled = false;
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

		//if(IOS or Android device)
		//Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

		Debug.Log("Stand Alone or Webplayer");

        //if raycast hits
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, ((1 << 9) | (1 << 10) | (1 << 12)))) //no componet layer anymore becuase we are relying on ExpandIcons to go to Subcomponent State
        {
            if (hit.collider != null)
            {
                collidertag = hit.collider.tag;
                Debug.Log(collidertag);
                if (envi.isMoving == false)
                {
                    if (collidertag.Equals("ExpandIcon"))
                    {
                        envi.priorToIconState = envi.BetaState;

                        //Saves players position
                        //envi.currentPlayerPos = Camera.main.transform;
                        envi.tempPlayerPos = Organized.Instance.player.transform.position;

                        envi.currentExpandIconGameObject = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        //envi.currentExpandIcon = envi.currentExpandIconGameObject.GetComponent<ExpandIcon>();

                        //Moves camera to zoomPosition
                        envi.activateCameraCoroutine(Organized.Instance.systemDictionary["M1"].majorComponentDictionary[envi.currentExpandIconGameObject.name].iconControl.zoomPos.position);
                        //envi.cameraHead.transform.position = Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].majorComponentDictionary[envi.currentExpandIcon.name].iconControl.zoomPos.position;

                        Organized.Instance.systemDictionary["M1"].expandIconDictionary[envi.currentExpandIconGameObject.name].expand();

						//Highlight//

						envi.selectedComponent = hit.collider.gameObject;

						//If its a expandIcon
						if (hit.collider.tag == "ExpandIcon")
						{
							//selectedComponent.GetComponent<Renderer>().material.shader = highlightShader;
							hit.collider.gameObject.GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.cyan);
						}

						envi.previousSelectedComponent = envi.selectedComponent;

                        //Debug.Log("From MajorComponentState " + envi.currentExpandIconGameObject.GetComponent<ExpandIcon>().window);
                        //envi.currentExpandIconGameObject.GetComponent<ExpandIcon>().expand();

                        Debug.Log("ExpandIcon hit!");
                        //Debug.Log(hit.collider.gameObject.name);

                        tempEventNames.Add("ExpandIcon");
                        envi.BroadcastEvents(tempEventNames);

                        //ToIconState();
                        envi.currentState = envi.iconStateAR;
                    }

                    //If it hits a return button
                    if (collidertag.Equals("Return"))
                    {

                        Organized.Instance.toggle(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].expandIcons);

                        try
                        {
                            //Adds the hit colliders system and its trans system
                            systemsHit.Add(Organized.Instance.systemDictionary[envi.currentSystemName].layerDictionary[envi.currentSystemName + "Detail"].gameObject);
                            
                            systemsHit.Add(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"]._root.gameObject);
                            
                            envi.toggle(systemsHit);
                        }

                        catch
                        {
                            Debug.Log("Error: the hit collider's tag does not match any current systems.");
                        }

                        //Add collider tag as an event
                        tempEventNames.Add(collidertag);

                        //Broadcast the events
                        envi.BroadcastEvents(tempEventNames);
                        envi.currentState = envi.mainStateAR;
                    }
                }
            }
        }
		#endif


		#if UNITY_IOS


		Debug.Log("Mobile IOS");

		if(Input.touches.Length > 0)
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.touches[0].position), out hit, Mathf.Infinity, ((1 << 9) | (1 << 10) | (1 << 12)))) //no componet layer anymore becuase we are relying on ExpandIcons to go to Subcomponent State
			{
				if (hit.collider != null)
				{
					collidertag = hit.collider.tag;
					Debug.Log(collidertag);
					if (envi.isMoving == false)
					{
						if (collidertag.Equals("ExpandIcon"))
						{
							envi.priorToIconState = envi.BetaState;

							//Saves players position
							//envi.currentPlayerPos = Camera.main.transform;
							envi.tempPlayerPos = Organized.Instance.player.transform.position;

							envi.currentExpandIconGameObject = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
							//envi.currentExpandIcon = envi.currentExpandIconGameObject.GetComponent<ExpandIcon>();

							//Moves camera to zoomPosition
							envi.activateCameraCoroutine(Organized.Instance.systemDictionary["M1"].majorComponentDictionary[envi.currentExpandIconGameObject.name].iconControl.zoomPos.position);
							//envi.cameraHead.transform.position = Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].majorComponentDictionary[envi.currentExpandIcon.name].iconControl.zoomPos.position;

							//Disables Physics and Movement for Camera while zoomed
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_GravityMultiplier = 0;
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 0;
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 0;
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_JumpSpeed = 0;
							//envi.cameraHead.GetComponent<Rigidbody>().isKinematic = true;

							Organized.Instance.systemDictionary["M1"].expandIconDictionary[envi.currentExpandIconGameObject.name].expand();

							//Highlight//

							envi.selectedComponent = hit.collider.gameObject;

							//If its a expandIcon
							if (hit.collider.tag == "ExpandIcon")
							{
								//selectedComponent.GetComponent<Renderer>().material.shader = highlightShader;
								hit.collider.gameObject.GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.cyan);
							}

							envi.previousSelectedComponent = envi.selectedComponent;

							//Debug.Log("From MajorComponentState " + envi.currentExpandIconGameObject.GetComponent<ExpandIcon>().window);
							//envi.currentExpandIconGameObject.GetComponent<ExpandIcon>().expand();

							Debug.Log("ExpandIcon hit!");
							//Debug.Log(hit.collider.gameObject.name);

							tempEventNames.Add("ExpandIcon");
							envi.BroadcastEvents(tempEventNames);

							//ToIconState();
							envi.currentState = envi.iconStateAR;
						}

						//If it hits a return button
						if (collidertag.Equals("Return"))
						{

							Organized.Instance.toggle(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].expandIcons);
							//Organized.Instance.toggle(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].expandIconGameObjects);
							//Debug.Log (Organized.Instance.systems[15].name); //worked
							//Debug.Log(Organized.Instance.systemDictionary["VR_Heavy"]); //did not work
							//Debug.Log(Organized.Instance.systemsList[15].name); //did not work
							//Debug.Log(Organized.Instance.systemDictionary[envi.currentSystemName]._name);

							try
							{
								//Adds the hit colliders system and its trans system
								
								systemsHit.Add(Organized.Instance.systemDictionary[envi.currentSystemName].layerDictionary[envi.currentSystemName + "Detail"].gameObject);
								
								systemsHit.Add(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"]._root.gameObject);
								//systemsHit.Add(Organized.Instance.panelDictionary["Panel_Annotation"]);
								envi.toggle(systemsHit);
							}

							catch
							{
								Debug.Log("Error: the hit collider's tag does not match any current systems.");
							}

							//Add collider tag as an event
							tempEventNames.Add(collidertag);

							//Broadcast the events
							envi.BroadcastEvents(tempEventNames);
							envi.currentState = envi.mainStateAR;
						}
					}	
				}
			}
		}
		#endif

		#if UNITY_ANDROID


		Debug.Log("Mobile Android");

		if(Input.touchCount > 0)
		{
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit, Mathf.Infinity, ((1 << 9) | (1 << 10) | (1 << 12)))) //no componet layer anymore becuase we are relying on ExpandIcons to go to Subcomponent State
			{
				if (hit.collider != null)
				{
					collidertag = hit.collider.tag;
					Debug.Log(collidertag);
					if (envi.isMoving == false)
					{
						if (collidertag.Equals("ExpandIcon"))
						{
							envi.priorToIconState = envi.BetaState;

							//Saves players position
							//envi.currentPlayerPos = Camera.main.transform;
							envi.tempPlayerPos = Organized.Instance.player.transform.position;

							envi.currentExpandIconGameObject = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
							//envi.currentExpandIcon = envi.currentExpandIconGameObject.GetComponent<ExpandIcon>();

							//Moves camera to zoomPosition
							envi.activateCameraCoroutine(Organized.Instance.systemDictionary["M1"].majorComponentDictionary[envi.currentExpandIconGameObject.name].iconControl.zoomPos.position);
							//envi.cameraHead.transform.position = Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].majorComponentDictionary[envi.currentExpandIcon.name].iconControl.zoomPos.position;

							//Disables Physics and Movement for Camera while zoomed
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_GravityMultiplier = 0;
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 0;
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 0;
							//envi.cameraHead.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_JumpSpeed = 0;
							//envi.cameraHead.GetComponent<Rigidbody>().isKinematic = true;

							Organized.Instance.systemDictionary["M1"].expandIconDictionary[envi.currentExpandIconGameObject.name].expand();

							//Highlight//

							envi.selectedComponent = hit.collider.gameObject;

							//If its a expandIcon
							if (hit.collider.tag == "ExpandIcon")
							{
								//selectedComponent.GetComponent<Renderer>().material.shader = highlightShader;
								hit.collider.gameObject.GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.cyan);
							}

							envi.previousSelectedComponent = envi.selectedComponent;

							//Debug.Log("From MajorComponentState " + envi.currentExpandIconGameObject.GetComponent<ExpandIcon>().window);
							//envi.currentExpandIconGameObject.GetComponent<ExpandIcon>().expand();

							Debug.Log("ExpandIcon hit!");
							//Debug.Log(hit.collider.gameObject.name);

							tempEventNames.Add("ExpandIcon");
							envi.BroadcastEvents(tempEventNames);

							//ToIconState();
							envi.currentState = envi.iconStateAR;
						}

						//If it hits a return button
						if (collidertag.Equals("Return"))
						{

							Organized.Instance.toggle(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].expandIcons);
							//Organized.Instance.toggle(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"].expandIconGameObjects);
							//Debug.Log (Organized.Instance.systems[15].name); //worked
							//Debug.Log(Organized.Instance.systemDictionary["VR_Heavy"]); //did not work
							//Debug.Log(Organized.Instance.systemsList[15].name); //did not work
							//Debug.Log(Organized.Instance.systemDictionary[envi.currentSystemName]._name);

							try
							{
								//Adds the hit colliders system and its trans system

								systemsHit.Add(Organized.Instance.systemDictionary[envi.currentSystemName].layerDictionary[envi.currentSystemName + "Detail"].gameObject);

								systemsHit.Add(Organized.Instance.systemDictionary[envi.currentSystemName + " (Trans)"]._root.gameObject);
								//systemsHit.Add(Organized.Instance.panelDictionary["Panel_Annotation"]);
								envi.toggle(systemsHit);
							}

							catch
							{
								Debug.Log("Error: the hit collider's tag does not match any current systems.");
							}

							//Add collider tag as an event
							tempEventNames.Add(collidertag);

							//Broadcast the events
							envi.BroadcastEvents(tempEventNames);
							envi.currentState = envi.mainStateAR;
						}
					}	
				}
			}
		}
		#endif
    }
}
