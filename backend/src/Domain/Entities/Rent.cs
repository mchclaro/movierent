using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
        public bool IsReturned { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Client Client { get; set; }

        // public Rent()
        // {
        //     RentalDate = DateTime.Now;
            
        //     if ((int)Movie.MovieType == 1)
        //     {
        //         ReturnDate = DateTime.Now.AddDays(2);
        //     }
        //     else
        //     {
        //         ReturnDate = DateTime.Now.AddDays(3);
        //     }
        // }
    }
}