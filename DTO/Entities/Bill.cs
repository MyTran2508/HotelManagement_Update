using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class Bill
    {
        public string Id { get; set; }
        
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public string ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }   
        
        float TotalPrice { get; set; }

        public virtual List<BillDetail> BillDetails { get; set; }   

    }
}
