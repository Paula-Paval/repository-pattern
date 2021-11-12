using System;
using System.Collections.Generic;

namespace Albums
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlbumRepository albumRepository = new AlbumRepository(@"..\..\..\albums.csv");
            Album album = new Album();
            Console.WriteLine("Choose an option:\n select by id=1 \n select by musician=2 \n select by name=3\n select by year=4\n select by genre=5\n select by owned=6 \n select by record label=7"
                            + "\n select all=8 \ndelete an album=9 \n insert an album=10 \n update an album=11 \n update by id=12 \nexit=exit ");
            var option = Console.ReadLine();
            while(option!="exit")
            {
                switch(option)
                {
                    case "1":
                        Console.WriteLine("Read an id:");
                        var id = Console.ReadLine(); 
                        if(albumRepository.GetById(Int32.Parse(id))!=null)
                             Console.WriteLine(albumRepository.GetById(Int32.Parse(id)).ToString());                    
                         break;
                    case "2":Console.WriteLine("Read a musician:");
                        var musician = Console.ReadLine();
                        PrintElements(albumRepository.GetByMusician(musician));
                        break;
                    case "3":Console.WriteLine("Read a name:");
                        var name = Console.ReadLine();
                        PrintElements(albumRepository.GetByName(name));
                        break;
                    case "4":Console.WriteLine("Read a year:");
                        var year = Console.ReadLine();
                        PrintElements(albumRepository.GetByYear(Int32.Parse(year)));
                        break;
                    case "5":Console.WriteLine("Read a genre:");
                        var genre = Console.ReadLine();
                        PrintElements(albumRepository.GetByGenre(genre));
                        break;
                    case "6":Console.WriteLine("Do you want to see what albums you own (yes/no)");
                        var own = Console.ReadLine();
                        PrintElements(albumRepository.GetByOwned(bool.Parse(own)));
                        break;
                    case "7":Console.WriteLine("Choose a record label:");
                        var recordlabel = Console.ReadLine();
                        PrintElements(albumRepository.GetByRecordLabel(recordlabel));
                        break;
                    case "8":Console.WriteLine("All albums:");
                            var albums=albumRepository.GetAll();
                            PrintElements(albums);
                            break;
                    case "9":Console.WriteLine("What album do you want to delete(id)?");
                        var albumId = Console.ReadLine();                       
                        albumRepository.Delete(Int32.Parse(albumId));                      
                        albumRepository.Save();
                        break;
                    case "10":Console.WriteLine("New album:(Please insert an album in this order and separated by commas:id,musician,name,year,genre,owned,record label)");
                        var newRecord = Console.ReadLine();
                        albumRepository.Insert(album.Parse(newRecord));                                                
                        albumRepository.Save();
                        break;
                    case "11":Console.WriteLine("What album do you want to update");
                        var newRecord1 = Console.ReadLine();
                        albumRepository.Update(album.Parse(newRecord1));                      
                        albumRepository.Save();
                        break;
                    case "12":
                        Console.WriteLine("What album do you want to update (by id)?");
                        var Id = Console.ReadLine();
                        albumRepository.UpdateById(int.Parse(Id));
                        albumRepository.Save();
                        break;
                    default: 
                        break;
                }
                Console.WriteLine("Choose an option:\n select by id=1 \n select by musician=2 \n select by name=3\n select by year=4\n select by genre=5\n select by owned=6 \n select by record label=7"
                           + "\n select all=8 \ndelete an album=9 \n insert an album=10 \n update an album=11 \n update by id=12 \nexit=exit ");
                option = Console.ReadLine();

            }           

        }
       static void PrintElements(IEnumerable<Album> albums)
        {
            foreach (var elem in albums)
            {
                Console.WriteLine(elem.ToString());
            }
        }
    }
}
