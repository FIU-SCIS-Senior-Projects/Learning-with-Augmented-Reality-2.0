using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Item : MonoBehaviour {

    [XmlAttribute("ObjName")]
    public string objName;

    [XmlElement("Material")]
    public string material;

    [XmlElement("RValue")]
    public double rValue;

    [XmlElement("UValue")]
    public double uValue;

    [XmlElement("Cost")]
    public double cost;

}
