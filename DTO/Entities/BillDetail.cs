using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class BillDetail
    {
        public string BillId { get; set; }
        public string ServiceId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Service Service { get; set; }    
    }
}
