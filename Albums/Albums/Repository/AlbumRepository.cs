using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;

namespace Repository
{
    public abstract class AlbumRepository:IAlbumRepository
    {
        protected string path;
        protected List<Album> Albums;

       
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
        public void UpdateMusician(int Id, string Musician)
        {
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldalbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldalbum);
                oldalbum.Musician = Musician;
                Albums.Add(oldalbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
        }
        public void UpdateName(int Id, string Name)
        {
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldalbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldalbum);
                oldalbum.Name = Name;
                Albums.Add(oldalbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
        }
        public void UpdateYear(int Id, int Year)
        {
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldAlbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldAlbum);
                oldAlbum.Year = Year;
                Albums.Add(oldAlbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }

        }
        public void UpdateGenre(int Id, string Genre)
        {
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldalbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldalbum);
                oldalbum.Genre = Genre;
                Albums.Add(oldalbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
        }
        public void UpdateOwned(int Id, bool Owned)
        {
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldalbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldalbum);
                oldalbum.Owned = Owned;
                Albums.Add(oldalbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
        }
        public void UpdateRecordLabel(int Id, string RecordLabel)
        {
            if (AnOldAlbumAlreadyExists(Id))
            {
                var oldalbum = Albums.Where(x => x.Id == Id).First();
                Albums.Remove(oldalbum);
                oldalbum.RecordLabel = RecordLabel;
                Albums.Add(oldalbum);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
        }

        private bool AnOldAlbumAlreadyExists(int Id)
        {
            return Albums.Where(x => x.Id == Id).Any();
        }

        public abstract void Save();
    }
}
