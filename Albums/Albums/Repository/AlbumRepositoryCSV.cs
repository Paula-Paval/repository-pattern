using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class AlbumRepositoryCSV : AlbumRepository
    {
       
        public AlbumRepositoryCSV(string path)
        {
            base.path = path;
            base.Albums = new List<Album>();
            Album album = new Album();
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Albums.Add(album.ParseCSV(s));
                }
            }
        }
        public override void Save()
        {
            FileInfo fileInfo = new FileInfo(base.path);
            string newPath = fileInfo.DirectoryName + "\\result.csv";
            if (File.Exists(newPath))
            {
                using (StreamWriter sw = File.CreateText(newPath))
                {
                    foreach (var album in base.Albums)
                    {
                        sw.WriteLine($"{album.Id},{album.Musician},{album.Name},{album.Year},{album.Genre},{album.Owned},{album.RecordLabel}");
                    }
                }
            }
        }

    }
}
