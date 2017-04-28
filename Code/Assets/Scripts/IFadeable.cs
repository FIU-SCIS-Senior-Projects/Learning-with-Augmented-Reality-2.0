using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IFadeable
{
    //private Material[] materials;

    void fadeToMaterial(List<Transform> fadeObjects);
    //get all the current materials in a list
    //if any of the materials are the same dont add the duplicates
    //save a dictionary of the fadeObjects name as key and the associated material as value

//    if (materials == null)
//        {
//            InitializeMaterials();
//        }
//        gameObject.AddComponent<MeshFilter>().mesh = mesh;
//        //gameObject.AddComponent<MeshRenderer>().material = materials[depth];
//        gameObject.AddComponent<MeshRenderer>().material = material;

    //public void InitializeMaterials()
    //{
    //    materials = new Material[maxDepth + 1];
    //    for (int i = 0; i <= maxDepth; i++)
    //    {
    //        float t = i / (maxDepth - 1f);
    //        t *= t;
    //        materials[i] = new Material(material);
    //        materials[i].color = Color.Lerp(Color.white, Color.red, t);
    //    }
    //    materials[maxDepth].color = Color.red;
    //}

}
