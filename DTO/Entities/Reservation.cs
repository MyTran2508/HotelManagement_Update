using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Thue phong
    public class Reservation
    {
        public string Id { get; set; }

        public string EmployeeId { get; set; }  
        public virtual Employee Employee { get; set; }

        public string RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }  

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        string DateIn_s { get; set; }
        string DateOut_s { get; set; }

        // Tinh Trang Thanh Toan
        public string Status { get; set; }
        public virtual Bill Bill { get; set; }  

    }
}
