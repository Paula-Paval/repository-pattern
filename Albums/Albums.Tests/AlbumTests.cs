using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Albums.Tests
{
    public class AlbumTests
    {

        private IAlbumRepository albumRepository;
        public AlbumTests()
        {
           albumRepository = new AlbumRepository(@"..\..\..\albums.csv");
        }
        [Fact]
        public void GetByIdReturnAnAlbumWithTheSameId()
        {
            var albumId = 10;

            Album album = albumRepository.GetById(albumId);

            Assert.NotNull(album);
            Assert.Equal(albumId, album.Id);
        }
        [Fact]
        public void GetByIdReturNull()
        {
            var albumId = 11;

            Album album = albumRepository.GetById(albumId);

            Assert.Null(album);
        }

        [Fact]
        public void GetByMusicianReturnAListWithAlbumsWithTheSameMusician()
        {
            var musician = "Sakira";

            IEnumerable < Album > albums = albumRepository.GetByMusician(musician);

            Assert.NotEmpty(albums);
            foreach(var album in albums)
            {
                Assert.Equal(musician, album.Musician);
            }
        }

        [Fact]
        public void GetByMusicianReturnAnEmtyList()
        {
            var musician = "Eminem";

            IEnumerable<Album> albums = albumRepository.GetByMusician(musician);

            Assert.Empty(albums);
           
        }
        [Fact]
        public void GetByNameReturnAListWithAlbumsWithTheSameName()
        {
            var name = "Funeral";

            IEnumerable<Album> albums = albumRepository.GetByName(name);

            Assert.NotEmpty(albums);
            foreach (var album in albums)
            {
                Assert.Equal(name, album.Name);
            }
        }

        [Fact]
        public void GetByNameReturnAnEmtyList()
        {
            var name = "FuneraL";

            IEnumerable<Album> albums = albumRepository.GetByName(name);

            Assert.Empty(albums);
        }
        [Fact]
        public void GetByYearReturnAListWithAlbumsWithTheSameYear()
        {
            var year = 2004;

            IEnumerable<Album> albums = albumRepository.GetByYear(year);

            Assert.NotEmpty(albums);
            foreach (var album in albums)
            {
                Assert.Equal(year, album.Year);
            }
        }

        [Fact]
        public void GetByYearReturnAnEmtyList()
        {
            var year = 2020;

            IEnumerable<Album> albums = albumRepository.GetByYear(year);

            Assert.Empty(albums);           
        }
        [Fact]
        public void GetByGenreReturnAListWithAlbumsWithTheSameGenre()
        {
            var genre = "pop";

            IEnumerable<Album> albums = albumRepository.GetByGenre(genre);

            Assert.NotEmpty(albums);
            foreach (var album in albums)
            {
                Assert.Equal(genre, album.Genre);
            }
        }

        [Fact]
        public void GetByGenreReturnAnEmtyList()
        {
            var genre = "k-pop";

            IEnumerable<Album> albums = albumRepository.GetByGenre(genre);

            Assert.Empty(albums);

        }
        
          [Fact]
        public void GetByOwnedReturnAListWithAlbumsWithTheSameOwnedState()
        {
            var owned = true;

            IEnumerable<Album> albums = albumRepository.GetByOwned(owned);

            Assert.NotEmpty(albums);
            foreach (var album in albums)
            {
                Assert.Equal(owned, album.Owned);
            }
        }
        [Fact]
        public void GetByRecordLabelReturnAListWithAlbumsWithTheSSameRecordLabel()
        {
            var recordLabel = "Merge";

            IEnumerable<Album> albums = albumRepository.GetByRecordLabel(recordLabel);

            Assert.NotEmpty(albums);
            foreach (var album in albums)
            {
                Assert.Equal(recordLabel, album.RecordLabel);
            }
        }

        [Fact]
        public void GetByRecordLabelReturnAnEmtyList()
        {
            var recordLabel = "MergE";

            IEnumerable<Album> albums = albumRepository.GetByRecordLabel(recordLabel);

            Assert.Empty(albums);          

        }
        [Fact]
        public void GetAllReturnAnNotEmtyList()
        {

            IEnumerable<Album> albums = albumRepository.GetAll();

            Assert.NotEmpty(albums);

        }
        [Fact]
        public void DeleteBy_GetByIdReturnNull()
        {
            var id = 30;

            albumRepository.Delete(id);
            albumRepository.Save();
            var album = albumRepository.GetById(id);

            Assert.Null(album);

        }
        [Fact]
        public void Insert_GetByIdReturnNotNull()
        {
            Album album = new Album();
            album.Id = 60;
            album.Musician = "Harry Style";
            album.Name = "Fine Line";
            album.Year = 2019;
            album.Genre = "pop";
            album.Owned = false;
            album.RecordLabel = "Columbia";

            albumRepository.Insert(album);
            var result = albumRepository.GetById(album.Id);

            Assert.NotNull(result);
        }
        [Fact]
        public void Update_GetByIdRetunAnAlbumWithTheSameFields()
        {
            Album album = new Album();
            album.Id = 60;
            album.Musician = "Harry Style";
            album.Name = "Fine Line";
            album.Year = 2019;
            album.Genre = "k-pop";
            album.Owned = false;
            album.RecordLabel = "Columbia";

            albumRepository.Update(album);
            var result = albumRepository.GetById(album.Id);

            Assert.Equal(album.Id, result.Id);
            Assert.Equal(album.Musician, result.Musician);
            Assert.Equal(album.Name, result.Name);
            Assert.Equal(album.Year, result.Year);
            Assert.Equal(album.Genre, result.Genre);
            Assert.Equal(album.Owned, result.Owned);
            Assert.Equal(album.RecordLabel, result.RecordLabel);

        }
       

    }
}
