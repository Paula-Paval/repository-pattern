using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Model
{

    [XmlRoot("", Namespace = "",IsNullable = false)]
    public class XMLList
    {
        public XMLList()
        {
            albums = new List<Album>();
        }

        [XmlArray("albums")]
        [XmlArrayItem("album")]
        public List<Album> albums { get; set; }
        
    }

}
