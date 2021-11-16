using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repository
{
    public interface IAlbumRepository
    {
        Album GetById(int albumId);
        IEnumerable<Album> GetByName(string name);
        IEnumerable<Album> GetByMusician(string musician);
        IEnumerable<Album> GetByYear(int year);
        IEnumerable<Album> GetByGenre(string genre);
        IEnumerable<Album> GetByOwned(bool owned);
        IEnumerable<Album> GetByRecordLabel(string recordLabel);
        IEnumerable<Album> GetAll();
        void Insert(Album album);
        void Update(Album album);
        public void UpdateMusician(int Id, string Musician);
        public void UpdateName(int Id, string Name);
        public void UpdateYear(int Id, int Year);
        public void UpdateGenre(int Id, string Genre);
        public void UpdateOwned(int Id, bool Owned);
        public void UpdateRecordLabel(int Id, string RecordLabel);
        void Delete(int albumId);
        void Save();

    }
}
