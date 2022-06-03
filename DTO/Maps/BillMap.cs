using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class BillMap : EntityTypeConfiguration<Bill>
    {
        public const string TABLE_NAME = "bills";

        public BillMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            //Key
            HasKey(b => b.Id);

            // FK
            HasMany(b => b.BillDetails).
                WithRequired().HasForeignKey(b => b.BillId);    
          
        }
    }
}
