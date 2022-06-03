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
    public class Account
    {
        public string EmployeeId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; } 

        //public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
