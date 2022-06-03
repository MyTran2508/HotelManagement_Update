using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Maps
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public const string TABLE_NAME = "employees";

        public EmployeeMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // PK
            HasKey(e => e.Id);

            // Props
            Property(e => e.Name).IsRequired();

            // FK
            HasOptional(a => a.Account).WithRequired(e => e.Employee);

            HasMany(e => e.Reservations).WithRequired().HasForeignKey(r => r.EmployeeId);
            HasMany(e => e.Bills).WithRequired().HasForeignKey(b => b.EmployeeId);
        }

    }
}
