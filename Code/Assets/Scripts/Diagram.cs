using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Diagram : IComparable<Diagram> {

    public Sprite diagram;
    public int diagramNum;
    public Diagram[] size;

    public Diagram(Sprite next, int number)
    {
        diagram = next;
        diagramNum = number;

    }
    
    public int CompareTo(Diagram other)
    {
        if(other == null)
        {
            return 1;
        }

        return diagramNum - other.diagramNum;
    }

    /*public void UpdateSprite(Image current)
    {
        Sprite old = current.GetComponent<Image>().sprite;
        current.GetComponent<Image>().sprite = diagram;
    }

    public Sprite GetDiagram(Sprite plug)
    {
        diagram = plug;
        return diagram;
    }
    */

}
