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
            albumRepository = new AlbumRepositoryCSV(@"..\..\..\Data\albums.csv");
        }
        [Fact]
        public void Save_CommitTheContentOfTheListInAnResultFile()
        {

            albumRepository.Save();

            Assert.Equal(System.IO.File.ReadAllText(@"..\..\..\Data\albums.csv"), System.IO.File.ReadAllText(@"..\..\..\Data\result.csv"));
        }

    }
}
