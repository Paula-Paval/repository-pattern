using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albums.Tests
{

    public class AlbumRepositoryCSVTests
    {

        private IAlbumRepository albumRepository;
        public AlbumRepositoryCSVTests()
        {
            albumRepository = new AlbumRepositoryCSV(@"..\..\..\data\albums.csv");
        }
        [Fact]
        public void SaveShouldCommitTheContentOfTheListInAnResultFile()
        {

            albumRepository.Save();

            Assert.Equal(System.IO.File.ReadAllText(@"..\..\..\data\albums.csv"), System.IO.File.ReadAllText(@"..\..\..\data\result.csv"));
        }

    }
}
