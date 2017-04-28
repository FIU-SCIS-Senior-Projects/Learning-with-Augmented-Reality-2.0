using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explode { // : OrganizedDetail {

 //   public float radius;

 //   //Debug Variables
 //   private List<Vector3> oldPos = new List<Vector3>();
 //   private List<Vector3> newPos = new List<Vector3>();

 //   //toggle hide objects
 //   public List<GameObject> hideObjs = new List<GameObject>();
 //   private string type;

 //   // Use this for initialization
 //   void Start ()
 //   {
 //       //Prepare for Movement
 //       interval = radius / layers.Count;
 //       getPositions();
 //       type = gameObject.tag;
 //       addTag(type);
 //   }
	
	//// Update is called once per frame
        
	//void Update ()
 //   {
 //       if(Input.GetKeyDown(KeyCode.G))
 //       {
 //           toggle(hideObjs);
 //           activateExplode();
 //       }
 //       ray();

 //       if(ray().Equals("Detail1"))
 //       {
 //           if (moved == false)
 //           {
 //               hide(hideObjs);
 //           }
 //           else
 //           {
 //               unHide(hideObjs);
 //           }
 //           activateExplode();
 //           changeSkybox();
 //       }
	//}

 //   public void getPositions()
 //   {
 //       for (int i = 0; i < layers.Count; i++)
 //       {
 //           oldPos.Add(layers[i].transform.position);

 //           Vector3 tempPos = (oldPos[i] + new Vector3(0, 0, -(i * interval)));
 //           newPos.Add(tempPos);

 //           //With Physics (not working yet)
 //           //bodies[i].AddForce(Vector3.forward);
 //       }
 //   }

 //   /*
 //   void OnMouseDown()
 //   {
 //       MeshCollider collider = GetComponent<MeshCollider>();
 //       collider.convex = true;
 //       collider.isTrigger = true;
 //       Debug.Log("click");

 //       activateExplode();
 //   }
 //   */

 //   public void activateExplode()
 //   {
 //       if (moved == false)
 //       {
 //           StartCoroutine(MoveCoroutine());
 //           moved = true;
 //       }
 //       else
 //       {
 //           StartCoroutine(MoveBackCoroutine());
 //           moved = false;
 //       }
 //   }

 //   //Move layers transform
 //   IEnumerator MoveCoroutine()
 //   {
 //       float timeSinceStarted = 0f;

 //       while (Vector3.Distance(layers[1].position, newPos[1]) > 0f)
 //       {
 //           timeSinceStarted += Time.deltaTime;
 //           for (int i = 1; i < layers.Count; i++)
 //           {
 //               layers[i].position = Vector3.Lerp(oldPos[i], newPos[i], timeSinceStarted);
 //           }

 //           for (int i = 1; i < layers.Count; i++)
 //           {
 //               if (oldPos[i] == newPos[i])
 //               {
 //                   yield break;
 //               }
 //               yield return null;
 //           }
 //       }
 //   }

 //   IEnumerator MoveBackCoroutine()
 //   {
 //       float timeSinceStarted = 0f;

 //       while (Vector3.Distance(layers[1].position, oldPos[1]) > 0f)
 //       {
 //           timeSinceStarted += Time.deltaTime;
 //           for (int i = 1; i < layers.Count; i++)
 //           {
 //               layers[i].position = Vector3.Lerp(newPos[i], oldPos[i], timeSinceStarted);
 //           }

 //           for (int i = 1; i < layers.Count; i++)
 //           {
 //               if (oldPos[i] == newPos[i])
 //               {
 //                   yield break;
 //               }
 //               yield return null;
 //           }
 //       }
 //   }

 //   //Moves the layer by a distance based on its hiearchy/ radius 
 //   public void Move()
 //   {
 //       if (Input.GetKeyDown(KeyCode.E))
 //       {
 //           for (int x = 0; x < layers.Count; x++)
 //           {
 //               layers[x].transform.position = Vector3.Lerp(oldPos[x], newPos[x], 1f);
 //           }
 //           moved = true;
 //       }
 //   }

 //   public void MoveBack()
 //   {
 //       if (Input.GetKeyDown(KeyCode.E))
 //       {
 //           for (int i = 0; i < layers.Count; i++)
 //           {
 //               layers[i].transform.position = Vector3.Lerp(newPos[i], oldPos[i], 1f);
 //           }
 //           moved = false;
 //       }
 //   }
}
