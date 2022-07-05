using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Rent
{
    public class RentUpdateReqDTO
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
    }
}