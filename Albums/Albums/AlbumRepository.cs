using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Albums
{
    public class AlbumRepository:IAlbumRepository
    {
        private string Path;
        private List<Album>  Albums = new List<Album>();

        public AlbumRepository(string path)
        {
            this.Path = path;
            Album album = new Album();
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {                   
                    Albums.Add(album.Parse(s));
            }
            }
        }
        public void Delete(int albumId)
        {

            if (AnOldAlbumAlreadyExists(albumId))
                Albums.Remove(Albums.Where(x => x.Id == albumId).First());
            else
                Console.WriteLine("Id not found");
        }

        public IEnumerable<Album> GetAll()
        {
            return Albums;
        }

        public IEnumerable<Album> GetByGenre(string genre)
        {
            return Albums.Where(x => x.Genre == genre).ToList();
        }

        public Album GetById(int albumId)
        {
            return Albums.Where(x => x.Id == albumId).FirstOrDefault();
        }

        public IEnumerable<Album> GetByMusician(string musician)
        {
            return Albums.Where(x => x.Musician == musician).ToList();
        }

        public IEnumerable<Album> GetByName(string name)
        {
            return Albums.Where(x => x.Name == name).ToList();
        }

        public IEnumerable<Album> GetByOwned(bool owned)
        {
            return Albums.Where(x => x.Owned== owned).ToList();
        }

        public IEnumerable<Album> GetByRecordLabel(string recordLabel)
        {
            return Albums.Where(x => x.RecordLabel == recordLabel).ToList();
        }

        public IEnumerable<Album> GetByYear(int year)
        {
            return Albums.Where(x => x.Year == year).ToList();
        }

        public void Insert(Album album)
        {

            if (!AnOldAlbumAlreadyExists(album.Id))
                Albums.Add(album);
            else
                Console.WriteLine("Album already exists!");
        }

        public void Save()
        {
            if (File.Exists(Path))
            {                               
                using (StreamWriter sw = File.CreateText(Path))
                {
                    foreach(var album in Albums)
                    {
                         sw.WriteLine($"{album.Id},{album.Musician},{album.Name},{album.Year},{album.Genre},{album.Owned},{album.RecordLabel}");
                    }                   
                }
            }
        }

        public void Update(Album album)
        {
          
            if (AnOldAlbumAlreadyExists(album.Id))
            {
                var oldalbum = Albums.Where(x => x.Id == album.Id).First();
                Albums.Remove(oldalbum);
                oldalbum.Musician = album.Musician;
                oldalbum.Name = album.Name;
                oldalbum.Year = album.Year;
                oldalbum.Genre = album.Genre;
                oldalbum.Owned = album.Owned;
                oldalbum.RecordLabel = album.RecordLabel;
                Albums.Add(oldalbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
                                  
        }
        public void UpdateById(int Id)
        {
            
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldalbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldalbum);
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
                            oldalbum.Musician = newMusician;
                            break;
                        case "Name":
                            Console.WriteLine("New Name:");
                            var newName = Console.ReadLine();
                            oldalbum.Musician = newName;
                            break;
                        case "Year":
                            Console.WriteLine("New Year:");
                            var newYear = Console.ReadLine();
                            oldalbum.Year = int.Parse(newYear);
                            break;
                        case "Genre":
                            Console.WriteLine("New genre:");
                            var newGenre = Console.ReadLine();
                            oldalbum.Genre = newGenre;
                            break;
                        case "Owned":
                            Console.WriteLine("Is owned or not?");
                            var isOwned = Console.ReadLine();
                            oldalbum.Owned = bool.Parse(isOwned);
                            break;
                        case "RexordLabel":
                            Console.WriteLine("New record label:");
                            var newRecordLabel = Console.ReadLine();
                            oldalbum.RecordLabel = newRecordLabel;
                            break;

                    }
                    Albums.Add(oldalbum);
                    Console.WriteLine("Do ypu want to change something else?(Y/N)");
                    optionForContinue = Console.ReadLine();
                    if (optionForContinue == "Y")
                    {
                        Console.WriteLine("What do you want to change? (Musician, Name, Year, Genre, Owned ,RecordLabel)");
                        option = Console.ReadLine();
                    }

                } while (optionForContinue == "Y");                
            }
            {
                Console.WriteLine("Id not found!");
            }

        }
        private bool AnOldAlbumAlreadyExists(int Id)
        {
            return Albums.Where(x => x.Id == Id).Any();
        }
    }
}
