using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class RoomStatusMap : EntityTypeConfiguration<RoomStatus>
    {
        public const string TABLE_NAME = "room_status";

        public RoomStatusMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // PK
            HasKey(rs => rs.Id);

            // Props
            Property(rs => rs.Name).IsRequired();

            // FK
            HasMany(rs => rs.Rooms)
                .WithRequired().HasForeignKey(r => r.RoomStatusId);
            
        }
    }
}
