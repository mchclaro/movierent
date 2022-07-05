using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Rent
{
    public class RentCreateReqDTO
    {
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int ClientId { get; set; }
        public int MovieId { get; set; }
    }
}