using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DetailCollection")]
public class DetailContainer2
{

    [XmlArray("Detials")]
    [XmlArrayItem("Detail")]
    public List<Detail> Details = new List<Detail>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(DetailContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static DetailContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(DetailContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as DetailContainer;
        }
    }

    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static DetailContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(DetailContainer));
        return serializer.Deserialize(new StringReader(text)) as DetailContainer;
    }

    //Reading data
    //var serializer = new XmlSerializer(typeof(DetailContainer));
    //var stream = new FileStream(path, FileMode.Open);
    //var container = ser

    //Writing data
    //var serializer = new XmlSerializer(typeof(DetailContainer));
    //var stream = new FileStream(path, FileMode.Create));
    //serializer.Serialize(stream, this);
    //stream.Close();
}
