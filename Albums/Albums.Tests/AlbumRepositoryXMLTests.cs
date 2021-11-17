using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Albums.Tests
{
    public class AlbumRepositoryXMLTests
    {

        private IAlbumRepository albumRepository;
        public AlbumRepositoryXMLTests()
        {
            albumRepository = new AlbumRepositoryXML(@"..\..\..\data\albums.xml");
        }
        [Fact]
        public void SaveShouldCommitTheContentOfTheListInAnResultFile()
        {
            

            albumRepository.Save();

            string contentOfXML = System.IO.File.ReadAllText(@"..\..\..\data\result.xml");
            Assert.Equal(albumRepository.GetAll(), ParseXML(contentOfXML));
        }
        private List<Album> ParseXML(string fileContent)
        {
            List<Album> albums = new List<Album>();
            XElement albumroot = XElement.Parse(fileContent);
            List<XElement> listOfAlbums = albumroot.Elements("XMLList").ToList();
            List<XElement> albumsTags = listOfAlbums.Elements("albums").ToList();

            foreach (var album in albumsTags)
            {
                Album newAlbum = new Album();               
                newAlbum.Id = int.Parse(album.Elements("id").ToList().FirstOrDefault().Value);
                newAlbum.Musician = album.Elements("musician").ToList().FirstOrDefault().Value;
                newAlbum.Name = album.Elements("name").ToList().FirstOrDefault().Value;
                newAlbum.Year = int.Parse(album.Elements("year").ToList().FirstOrDefault().Value);
                newAlbum.Genre = album.Elements("genre").ToList().FirstOrDefault().Value;
                newAlbum.Owned = bool.Parse(album.Elements("owned").ToList().FirstOrDefault().Value);
                newAlbum.RecordLabel = album.Elements("recordlabel").ToList().FirstOrDefault().Value;
                albums.Add(newAlbum);
            }
            return albums;
        }
    }
}
