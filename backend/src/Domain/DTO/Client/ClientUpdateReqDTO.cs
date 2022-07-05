using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Client
{
    public class ClientUpdateReqDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
    }
}