using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DiagramList : MonoBehaviour
{
    public Sprite[] size;

    void Start()
    {
        List<Diagram> diagrams = new List<Diagram>();

        for (int i = 0; i < size.Length; i++)
        {
            diagrams.Add(new Diagram(gameObject.GetComponent<Sprite>(), i));
        }

        foreach (Diagram dia in diagrams)
        {
            print(dia.diagram + " " + dia.diagramNum);
        }
    }
}
