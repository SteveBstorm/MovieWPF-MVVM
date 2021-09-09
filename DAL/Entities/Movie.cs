using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int ReleaseYear { get; set; }
        public string Realisator { get; set; }
    }
}
