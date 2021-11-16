using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository;


namespace Albums
{
    class Menu
    {
        private IAlbumRepository albumRepository;
        private Album album;
        public Menu(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
            this.album=new Album();
        }
        public void choose(string option)
        {
            while (option != "exit")
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Read an id:");
                        var id = Console.ReadLine();
                        if (albumRepository.GetById(Int32.Parse(id)) != null)
                            Console.WriteLine(albumRepository.GetById(Int32.Parse(id)).ToString());
                        break;
                    case "2":
                        Console.WriteLine("Read a musician:");
                        var musician = Console.ReadLine();
                        PrintElements(albumRepository.GetByMusician(musician));
                        break;
                    case "3":
                        Console.WriteLine("Read a name:");
                        var name = Console.ReadLine();
                        PrintElements(albumRepository.GetByName(name));
                        break;
                    case "4":
                        Console.WriteLine("Read a year:");
                        var year = Console.ReadLine();
                        PrintElements(albumRepository.GetByYear(Int32.Parse(year)));
                        break;
                    case "5":
                        Console.WriteLine("Read a genre:");
                        var genre = Console.ReadLine();
                        PrintElements(albumRepository.GetByGenre(genre));
                        break;
                    case "6":
                        Console.WriteLine("Do you want to see what albums you own (yes/no)");
                        var own = Console.ReadLine();
                        PrintElements(albumRepository.GetByOwned(bool.Parse(own)));
                        break;
                    case "7":
                        Console.WriteLine("Choose a record label:");
                        var recordlabel = Console.ReadLine();
                        PrintElements(albumRepository.GetByRecordLabel(recordlabel));
                        break;
                    case "8":
                        Console.WriteLine("All albums:");
                        var albums = albumRepository.GetAll();
                        PrintElements(albums);
                        break;
                    case "9":
                        Console.WriteLine("What album do you want to delete(id)?");
                        var albumId = Console.ReadLine();
                        albumRepository.Delete(Int32.Parse(albumId));
                        break;
                    case "10":
                        Console.WriteLine("New album:(Please insert an album in this order and separated by commas:id,musician,name,year,genre,owned,record label)");
                        var newRecord = Console.ReadLine();
                        albumRepository.Insert(album.ParseCSV(newRecord));
                        break;
                    case "11":
                        Console.WriteLine("What album do you want to update");
                        var newRecord1 = Console.ReadLine();
                        albumRepository.Update(album.ParseCSV(newRecord1));
                        break;
                    case "12":
                        Console.WriteLine("What album do you want to update (by id)?");
                        var Id = Console.ReadLine();
                        UpdateMeniu(int.Parse(Id));
                        break;
                    case "13":
                        Console.WriteLine("Do you want to save?(yes/no)");
                        var validation = Console.ReadLine();
                        if (validation == "yes")
                        {
                            albumRepository.Save();
                        }
                        break;

                    default:
                        break;
                }
                Console.WriteLine("Choose an option:\n select by id=1 \n select by musician=2 \n select by name=3\n select by year=4\n select by genre=5\n select by owned=6 \n select by record label=7"
                           + "\n select all=8 \ndelete an album=9 \n insert an album=10 \n update an album=11 \n update by id=12 \n save=13\nexit=exit ");
                option = Console.ReadLine();
            }
        }
        private void UpdateMeniu(int Id)
        {

            Console.WriteLine("What do you want to change? (Musician, Name, Year, Genre, Owned ,RecordLabel)");
            var option = Console.ReadLine();
            string optionForContinue = "Y";
            do
            {
                switch (option)
                {
                    case "Musician":
                        Console.WriteLine("New musician:");
                        var newMusician = Console.ReadLine();
                        albumRepository.UpdateMusician(Id, newMusician);
                        break;
                    case "Name":
                        Console.WriteLine("New Name:");
                        var newName = Console.ReadLine();
                        albumRepository.UpdateName(Id, newName);
                        break;
                    case "Year":
                        Console.WriteLine("New Year:");
                        var newYear = Console.ReadLine();
                        albumRepository.UpdateYear(Id, int.Parse(newYear));
                        break;
                    case "Genre":
                        Console.WriteLine("New genre:");
                        var newGenre = Console.ReadLine();
                        albumRepository.UpdateGenre(Id, newGenre);
                        break;
                    case "Owned":
                        Console.WriteLine("Is owned or not?(yes/no)");
                        var isOwned = Console.ReadLine();
                        var value = (isOwned == "yes");
                        albumRepository.UpdateOwned(Id, value);
                        break;
                    case "RexordLabel":
                        Console.WriteLine("New record label:");
                        var newRecordLabel = Console.ReadLine();
                        albumRepository.UpdateRecordLabel(Id, newRecordLabel);
                        break;

                }
                Console.WriteLine("Do you want to change something else?(Y/N)");
                optionForContinue = Console.ReadLine();
                if (optionForContinue == "Y")
                {
                    Console.WriteLine("What do you want to change? (Musician, Name, Year, Genre, Owned ,RecordLabel)");
                    option = Console.ReadLine();
                }

            } while (optionForContinue == "Y");
        }
        
        private void PrintElements(IEnumerable<Album> albums)
        {
            foreach (var elem in albums)
            {
                Console.WriteLine(elem.ToString());
            }
        }
    }
}

