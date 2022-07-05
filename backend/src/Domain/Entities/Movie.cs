using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Classification { get; set; }
        public MovieType MovieType { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}