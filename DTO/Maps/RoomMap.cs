using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Maps
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public const string TABLE_NAME = "rooms";

        public RoomMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // PK
            HasKey(r => r.Id);

            // Props
            Property(r => r.Name).IsRequired();
            Property(r => r.KindOfRoomId).IsRequired();
            Property(r => r.RoomStatusId).IsRequired();

           // FK
            HasMany(ro => ro.Reservations).
                WithRequired().HasForeignKey(re => re.RoomId);
        }
    }
}
