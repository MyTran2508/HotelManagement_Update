using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Entities
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }

        public virtual Account Account { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public virtual List<Bill> Bills { get; set; }
    }
}