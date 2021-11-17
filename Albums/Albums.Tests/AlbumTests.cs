using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Model;
using Repository;

namespace Albums.Tests
{
    public class AlbumTests
    {

        private IAlbumRepository albumRepository;
        public AlbumTests()
        {
           albumRepository = new AlbumRepositoryCSV(@"..\..\..\data\albums.csv");
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
        public void GetByRecordLabelReturnAListWithAlbumsWithTheSameRecordLabel()
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
            album.Id = 30;
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
        [Fact]
        public void UpdateMusician_GetByIdReturnAnAlbumWithTheSameMusician()
        {
            int Id = 30;
            string musician = "Harry";

            albumRepository.UpdateMusician(30, musician);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(musician, result.Musician);
           
        }

        [Fact]
        public void UpdateName_GetByIdReturnAnAlbumWithTheSameName()
        {
            int Id = 30;
            string name= "Sign of the Time";

            albumRepository.UpdateName(Id, name);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(name, result.Name);

        }

        [Fact]
        public void UpdateYear_GetByIdReturnAnAlbumWithTheSameYear()
        {
            int Id = 30;
            int year = 2017;

            albumRepository.UpdateYear(Id, year);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(year, result.Year);

        }

        [Fact]
        public void UpdateGenre_GetByIdReturnAnAlbumWithTheSameGenre()
        {
            int Id = 30;
            string genre = "k-pop";

            albumRepository.UpdateGenre(Id, genre);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(genre, result.Genre);

        }

        [Fact]
        public void UpdateOwned_GetByIdReturnAnAlbumWithTheSameOwned()
        {
            int Id = 30;
            bool owned = true;

            albumRepository.UpdateOwned(Id, owned);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(owned, result.Owned);

        }


        [Fact]
        public void UpdateRecordLabel_GetByIdReturnAnAlbumWithTheRecoordLabel()
        {
            int Id = 30;
            string recordLabel = "Columbia";

            albumRepository.UpdateRecordLabel(Id, recordLabel);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(recordLabel, result.RecordLabel);

        }







    }
}
