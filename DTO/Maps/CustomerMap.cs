using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public const string TABLE_NAME = "customers";

        public CustomerMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // PK
            HasKey(c => c.Id);

            // Props
            Property(c => c.Name).IsRequired();
            Property(c => c.CustomerId).IsRequired();

            // FK
            HasMany(c => c.Reservations)
               .WithRequired().HasForeignKey(r => r.CustomerId);
        }
    }
}
