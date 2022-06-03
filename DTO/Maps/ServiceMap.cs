using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Maps
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public const string TABLE_NAME = "services";

        public ServiceMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // Primary Key
            HasKey(s => s.Id);

            // Properties
            Property(s => s.Name).IsRequired();
            Property(s => s.Price).IsRequired();

            // FK
            HasMany(b => b.BillDetails).
                WithRequired().HasForeignKey(s => s.ServiceId);

        }
    }
}
