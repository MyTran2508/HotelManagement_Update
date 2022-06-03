using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class KindOfRoomMap : EntityTypeConfiguration<KindOfRoom>
    {
        public const string TABLE_NAME = "kind_of_rooms";

        public KindOfRoomMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // PK
            HasKey(k => k.Id);

            // Props
            Property(k => k.Name).IsRequired();

            // FK
            HasMany(k => k.Rooms)
               .WithRequired().HasForeignKey(r => r.KindOfRoomId);
        }
    }
}
