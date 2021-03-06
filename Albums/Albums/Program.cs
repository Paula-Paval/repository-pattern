using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Model;
using System.IO;

namespace Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlbumRepository albumRepository = ChooseRepositoryType(@"..\..\..\Data\albums.xml");

            Console.WriteLine("Choose an option:\n select by id=1 \n select by musician=2 \n select by name=3\n select by year=4\n select by genre=5\n select by owned=6 \n select by record label=7"
                            + "\n select all=8 \ndelete an album=9 \n insert an album=10 \n update an album=11 \n update by id=12 \n save=13 \nexit=exit ");

            var option = Console.ReadLine();
            var menu = new Menu(albumRepository);
            menu.choose(option);           
        }
        static IAlbumRepository ChooseRepositoryType(string path)
        {
            var file = new FileInfo(path);
            switch(file.Extension)
           {
                case ".csv":
                    return new AlbumRepositoryCSV(path);                   
                case ".xml":
                    return new AlbumRepositoryXML(path);                    
                default:
                    return null;
           }
            
        }
       
    }
}
