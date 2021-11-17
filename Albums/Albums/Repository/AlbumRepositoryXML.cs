using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;

namespace Repository
{
    public class AlbumRepositoryXML:AlbumRepository
    {
      
        public AlbumRepositoryXML(string path)
        {
            base.path = path;
            Album album = new Album();
            string contentOfXML = System.IO.File.ReadAllText(path);
            base.Albums=album.ParseXML(contentOfXML);
        }

        public override void Save()
        {
            FileInfo fileInfo = new FileInfo(base.path);
            string newPath = fileInfo.DirectoryName + "\\result.xml";
            XMLList albums = new XMLList();
            albums.albums = base.Albums;
            Album album = new Album();
            album.Serialize(newPath, albums);
        }
    }
}
