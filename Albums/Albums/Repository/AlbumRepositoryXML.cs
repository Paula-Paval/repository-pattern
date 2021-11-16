using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repository
{
    class AlbumRepositoryXML:AlbumRepository
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
            XMLList albums = new XMLList();
            albums.albums = base.Albums;
            Album album = new Album();
            album.Serialize(@"..\..\..\data\result.xml", albums);
        }
    }
}
