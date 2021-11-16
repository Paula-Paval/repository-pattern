using System;
using System.Collections.Generic;

namespace Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlbumRepository albumRepository = new AlbumRepository(@"..\..\..\data\albums.csv");
            
            Console.WriteLine("Choose an option:\n select by id=1 \n select by musician=2 \n select by name=3\n select by year=4\n select by genre=5\n select by owned=6 \n select by record label=7"
                            + "\n select all=8 \ndelete an album=9 \n insert an album=10 \n update an album=11 \n update by id=12 \n save=13 \nexit=exit ");
            
            var option = Console.ReadLine();
            Menu menu = new Menu(albumRepository);
            menu.choose(option);      
  

        }
       
    }
}
