using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Model;

namespace Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            //IAlbumRepository albumRepository = new AlbumRepository(@"..\..\..\data\albums.csv");
            
            //Console.WriteLine("Choose an option:\n select by id=1 \n select by musician=2 \n select by name=3\n select by year=4\n select by genre=5\n select by owned=6 \n select by record label=7"
            //                + "\n select all=8 \ndelete an album=9 \n insert an album=10 \n update an album=11 \n update by id=12 \n save=13 \nexit=exit ");
            
            //var option = Console.ReadLine();
            //Menu menu = new Menu(albumRepository);
            //menu.choose(option); 
            IAlbumRepository albumRepositoryXML= new AlbumRepositoryXML(@"..\..\..\data\albums.xml");
            List<Album> albums = albumRepositoryXML.GetAll().ToList();
            foreach (var elem in albums)
            {
                Console.WriteLine(elem.ToString());
            }
            Album album = new Album();
            album.Id = 60;
            album.Musician = "Harry Style";
            album.Name = "Fine Line";
            album.Year = 2019;
            album.Genre = "pop";
            album.Owned = false;
            album.RecordLabel = "Columbia";
            albumRepositoryXML.Insert(album);
            albumRepositoryXML.Save();
        }
       
    }
}
