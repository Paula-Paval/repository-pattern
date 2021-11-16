using System;
using System.Collections.Generic;
using System.Text;

namespace Albums
{
    public class Album
    {
        public int  Id { get; set; }
        public string Musician { get; set; }
        public string Name { get; set; }
      
        public int Year { get; set; }
        public string Genre { get; set; }
        public bool Owned { get; set; }
        public string RecordLabel { get; set; }
        public string ToString()
        {
            return ($"{Id},{Musician},{Name},{Year},{Genre},{Owned},{RecordLabel}");
        }
        public  Album Parse(string row)
        {
            string[] values = row.Split(',');
            Album album = new Album();
            album.Id = Int16.Parse(values[0]);
            album.Musician = values[1];
            album.Name = values[2];
            album.Year = Int32.Parse(values[3]);
            album.Genre = values[4];
            album.Owned = bool.Parse(values[5]);
            album.RecordLabel = values[6];
            return album;
        }



    }
}
