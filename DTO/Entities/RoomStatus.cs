using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{

    // Trang Thai Phong
    public class RoomStatus
    {
        // Trạng Thái Phòng
        public string Id { get; set; }

        // Tên Trạng Thái Phòng
        public string Name { get; set; }

        // Colection navigation
        public virtual List<Room> Rooms { get; set; }

    }
}
