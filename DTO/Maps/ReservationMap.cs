using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public const string TABLE_NAME = "reservations";
        public ReservationMap()
        {
            ToTable(TABLE_NAME);

            // PK
            HasKey(r => r.Id);
            
            // Props
            Property(r => r.Status).IsRequired();

            // FK
            HasOptional(b => b.Bill).WithRequired(r => r.Reservation);
        }

    }
}
