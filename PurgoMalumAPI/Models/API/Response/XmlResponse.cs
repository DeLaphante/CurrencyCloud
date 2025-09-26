using System.Xml.Serialization;

namespace PurgoMalumAPI.Models.API.Response
{
    [XmlRoot(ElementName = "PurgoMalum", Namespace = "http://www.purgomalum.com")]
    public class XmlResponse
    {
        [XmlElement(ElementName = "result")]
        public string Result { get; set; }

        [XmlElement(ElementName = "error")]
        public string Error { get; set; }
    }
}
