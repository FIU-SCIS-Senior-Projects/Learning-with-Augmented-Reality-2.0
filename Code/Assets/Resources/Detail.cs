using System.Xml;
using System.Xml.Serialization;

public class Detail
{
    [XmlAttribute("detailType")]
    public string detailType;

    [XmlElement("Name")]
    public string name;

    [XmlElement("Material")]
    public string material;

    [XmlElement("RValue")]
    public double rValue;

    [XmlElement("UValue")]
    public double uValue;

    [XmlElement("Cost")]
    public double cost;
}
