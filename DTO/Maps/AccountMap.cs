using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public const string TABLE_NAME = "accounts";

        public AccountMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // PK
            HasKey(a => a.EmployeeId);

            // Props
            Property(acc => acc.Username).HasMaxLength(255).IsRequired();
            HasIndex(acc => acc.Username).IsUnique();

            Property(acc => acc.Password).IsRequired();

            // FK
            //HasRequired(a => a.Employee).WithRequiredDependent();
        }
    }
}
