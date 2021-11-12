using System;
using System.Collections.Generic;
using System.Text;

namespace Albums
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
        public void UpdateById(int Id);
        void Delete(int albumId);
        void Save();

    }
}
