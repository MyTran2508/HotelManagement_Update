using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    // Loai Phong
    public class KindOfRoom
    {
        public string Id { get; set; }
        
        // Ten loai phong
        public string Name { get; set; }

        // So nguoi toi da
        public int Max { get; set; }

        // Don gia
        public float Price { get; set; }

        public  virtual List<Room> Rooms { get; set; }

    }
}
