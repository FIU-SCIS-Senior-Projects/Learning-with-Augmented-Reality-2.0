using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MajorSystem : MonoBehaviour { //IComparable<MajorSystem> {

    //Variables//

    //Object variables
    public Transform root;
    public int radius;
    public List<Transform> parts = new List<Transform>(); //The parts needed
    public List<Transform> layers = new List<Transform>();

    public List<Transform> clickab = new List<Transform>();

    //Helper variables
    public Transform[] allParts; //all the components parts
    public int direction = 1;
    [HideInInspector]
    public float interval;
    public List<Vector3> oldPos = new List<Vector3>();
    public List<Vector3> newPos = new List<Vector3>();
    public List<GameObject> hideObjs = new List<GameObject>();
    //public List<Rigidbody> bodies = new List<Rigidbody>();

    private string type;

    //Constructor//
    public MajorSystem(Transform r, List<GameObject> h, List<Transform> click, int rad, int di) //List<Transform> prts, List<Transform> lays)
    {
        root = r;
        radius = rad;
        direction = di;
        parts = CollectParts();
        layers = CollectParentLayers();
        hideObjs = h;
        clickab = click;

        //Prepare for Movement
        interval = radius / layers.Count;
        getPositions();

        addColliders();
        getPositions();

        type = root.tag;
        //Debug.Log(type);
        addTag(type);

        //Debug.Log(click.Count);
        //Debug.Log(parts.Count);
    }

    //Sorts the list
    //public int CompareTo(MajorSystem other)
    //{
    //    return 0;
    //}

    public void getPositions()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            oldPos.Add(layers[i].transform.position);

            Vector3 tempPos = (oldPos[i] + new Vector3(0, 0, -(i * interval * direction)));
            newPos.Add(tempPos);

            //With Physics (not working yet)
            //bodies[i].AddForce(Vector3.forward);
        }
    }

    //Add colliders
    public void addColliders()
    {
        for (int i = 0; i < parts.Count; i++)
        {
            if (parts[i].GetComponent<Collider>() == null)
            {
                MeshCollider collider = parts[i].gameObject.AddComponent<MeshCollider>();
            }
            //collider.convex = true;
        }
    }

    //Get all the parts
    public List<Transform> CollectParts()
    {
        allParts = root.GetComponentsInChildren<Transform>();

        //Add them to the list parts except the root transform
        for (int i = 0; i < allParts.Length; i++)
        {
            parts.Add(allParts[i]);
        }
        return parts;
    }

    //Get parent layers for transform
    public List<Transform> CollectParentLayers()
    {
        //add root to initialize layerName list
        //layers.Add(root);

        for (int y = 0; y < allParts.Length; y++)
        {
            //if this layer dosn't exist add it to list
            if (!layers.Contains(parts[y].transform.parent))
            {
                layers.Add(parts[y].transform.parent);
            }
        }

        //Removes The Main folder and then the Root
        layers.RemoveAt(0);
        layers.RemoveAt(0);

        return layers;
    }

    public void addTag(string tag)
    {
        for (int i = 0; i < clickab.Count; i++)
        {
            //Debug.Log(tag);
            //Debug.Log(clickable[i].name);
            clickab[i].tag = tag;
            //Debug.Log(clickab[i]);
            //clickable[i].gameObject.AddComponent<MeshCollider>();
        }
    }

}
