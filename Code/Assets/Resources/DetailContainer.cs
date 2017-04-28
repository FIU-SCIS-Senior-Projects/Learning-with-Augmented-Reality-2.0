using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DetailCollection")]
public class DetailContainer
{
    [XmlArray("Details")]
    [XmlArrayItem("Detail")]
    public List<Detail> details = new List<Detail>();

	public static DetailContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer seralizer = new XmlSerializer(typeof(DetailContainer));

        StringReader reader = new StringReader(_xml.text);

        DetailContainer details = seralizer.Deserialize(reader) as DetailContainer;

        reader.Close();

        return details;
    }
}
