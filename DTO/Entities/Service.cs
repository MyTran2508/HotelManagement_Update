using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Dich Vu
    public class Service
    {
        public string Id { get; set; }
       
        public string Name { get; set; }
       
        public float Price { get; set; }
        public virtual List<BillDetail> BillDetails { get; set; }   

    }
}
