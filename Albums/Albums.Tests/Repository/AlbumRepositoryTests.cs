using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Model;
using Repository;

namespace Albums.Tests
{
    public class AlbumRepositoryTests
    {

        private IAlbumRepository albumRepository;
        public AlbumRepositoryTests()
        {
           albumRepository = new AlbumRepositoryCSV(@"..\..\..\Data\albums.csv");
        }
        [Fact]
        public void GetById_TakeAnId_ReturnAnAlbumWithTheSameId()
        {
            var albumId = 10;

            Album album = albumRepository.GetById(albumId);

            Assert.NotNull(album);
            Assert.Equal(albumId, album.Id);
        }
        [Fact]
        public void GetById_TakeAnId_ReturNull()
        {
            var albumId = 11;

            Album album = albumRepository.GetById(albumId);

            Assert.Null(album);
        }

        [Fact]
        public void GetByMusician_TakeAMusician_ReturnAListWithAlbumsWithTheSameMusician()
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
        public void GetByMusician_TakeAMusician_ReturnAnEmtyList()
        {
            var musician = "Eminem";

            IEnumerable<Album> albums = albumRepository.GetByMusician(musician);

            Assert.Empty(albums);
           
        }
        [Fact]
        public void GetByName_TakeAName_ReturnAListWithAlbumsWithTheSameName()
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
        public void GetByName_TakeAName_ReturnAnEmtyList()
        {
            var name = "FuneraL";

            IEnumerable<Album> albums = albumRepository.GetByName(name);

            Assert.Empty(albums);
        }
        [Fact]
        public void GetByYear_TakeAYear_ReturnAListWithAlbumsWithTheSameYear()
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
        public void GetByYear_TakeAYear_ReturnAnEmtyList()
        {
            var year = 2020;

            IEnumerable<Album> albums = albumRepository.GetByYear(year);

            Assert.Empty(albums);           
        }
        [Fact]
        public void GetByGenre_TakeAGenre_ReturnAListWithAlbumsWithTheSameGenre()
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
        public void GetByGenre_TakeAGenre_ReturnAnEmtyList()
        {
            var genre = "k-pop";

            IEnumerable<Album> albums = albumRepository.GetByGenre(genre);

            Assert.Empty(albums);

        }
        
          [Fact]
        public void GetByOwned_TakeAOwnedState_ReturnAListWithAlbumsWithTheSameOwnedState()
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
        public void GetByRecordLabel_TakeARecordLabel_ReturnAListWithAlbumsWithTheSameRecordLabel()
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
        public void GetByRecordLabel_TakeARecordLabel_ReturnAnEmtyList()
        {
            var recordLabel = "MergE";

            IEnumerable<Album> albums = albumRepository.GetByRecordLabel(recordLabel);

            Assert.Empty(albums);          

        }
        [Fact]
        public void GetAll_ReturnAnNotEmtyList()
        {

            IEnumerable<Album> albums = albumRepository.GetAll();

            Assert.NotEmpty(albums);

        }
        [Fact]
        public void DeleteBy_TakeAnId_GetByIdReturnNull()
        {
            var id = 30;

            albumRepository.Delete(id);
            var album = albumRepository.GetById(id);

            Assert.Null(album);

        }
        [Fact]
        public void Insert_TakeAnAlbum_GetByIdReturnNotNull()
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
        public void Update_TakeAnAlbum_GetByIdRetunAnAlbumWithTheSameFields()
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
        public void UpdateMusician_TakeAnIdAndAMusician_GetByIdReturnAnAlbumWithTheSameMusician()
        {
            int Id = 30;
            string musician = "Harry";

            albumRepository.UpdateMusician(30, musician);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(musician, result.Musician);
           
        }

        [Fact]
        public void UpdateName_TakeAnIdAndName_GetByIdReturnAnAlbumWithTheSameName()
        {
            int Id = 30;
            string name= "Sign of the Time";

            albumRepository.UpdateName(Id, name);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(name, result.Name);

        }

        [Fact]
        public void UpdateYear_TakeAnIdAndAYear_GetByIdReturnAnAlbumWithTheSameYear()
        {
            int Id = 30;
            int year = 2017;

            albumRepository.UpdateYear(Id, year);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(year, result.Year);

        }

        [Fact]
        public void UpdateGenre_TakeAnIdAndAGenre_GetByIdReturnAnAlbumWithTheSameGenre()
        {
            int Id = 30;
            string genre = "k-pop";

            albumRepository.UpdateGenre(Id, genre);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(genre, result.Genre);

        }

        [Fact]
        public void UpdateOwned_TakeAnIdAndAOwned_GetByIdReturnAnAlbumWithTheSameOwned()
        {
            int Id = 30;
            bool owned = true;

            albumRepository.UpdateOwned(Id, owned);
            var result = albumRepository.GetById(Id);

            Assert.Equal(Id, result.Id);
            Assert.Equal(owned, result.Owned);

        }


        [Fact]
        public void UpdateRecordLabel_TakeAnIdAndARecodLabel_GetByIdReturnAnAlbumWithTheRecoordLabel()
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
