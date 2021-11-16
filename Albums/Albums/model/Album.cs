using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Model
{
   
    public class Album
    {      
        [XmlElement("id")]
        public int  Id { get; set; }
        [XmlElement("musician")]
        public string Musician { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("year")]
        public int Year { get; set; }
        [XmlElement("genre")]
        public string Genre { get; set; }
        [XmlElement("owned")]
        public bool Owned { get; set; }
        [XmlElement("recordlabel")]
        public string RecordLabel { get; set; }
        public string ToString()
        {
            return ($"{Id},{Musician},{Name},{Year},{Genre},{Owned},{RecordLabel}");
        }
        public  Album ParseCSV(string row)
        {
            string[] values = row.Split(',');
            Album album = new Album();
            album.Id = Int16.Parse(values[0]);
            album.Musician = values[1];
            album.Name = values[2];
            album.Year = Int32.Parse(values[3]);
            album.Genre = values[4];
            album.Owned = bool.Parse(values[5]);
            album.RecordLabel = values[6];
            return album;
        }
        public List<Album> ParseXML(string fileContent)
        {
            List<Album> albums = new List<Album>();
            XElement albumroot = XElement.Parse(fileContent);
            List<XElement> listOfAlbums = albumroot.Elements("album").ToList();

            foreach (var album in listOfAlbums)
            {
                Album newAlbum = new Album();
                newAlbum.Id=int.Parse(album.Elements("id").ToList().FirstOrDefault().Value);
                newAlbum.Musician = album.Elements("musician").ToList().FirstOrDefault().Value;
                newAlbum.Name= album.Elements("name").ToList().FirstOrDefault().Value;
                newAlbum.Year= int.Parse(album.Elements("year").ToList().FirstOrDefault().Value);
                newAlbum.Genre= album.Elements("genre").ToList().FirstOrDefault().Value;
                newAlbum.Owned = bool.Parse(album.Elements("owned").ToList().FirstOrDefault().Value);
                newAlbum.RecordLabel= album.Elements("recordlabel").ToList().FirstOrDefault().Value;
                albums.Add(newAlbum);
            }
            return albums;
        }
        public void Serialize(string path,  XMLList xMLList)
        {
            XmlSerializer x = new XmlSerializer(typeof(XMLList));
            x.Serialize(new StreamWriter(path), xMLList);
        }


    }
}
