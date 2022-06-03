using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entities;

namespace DTO.Maps
{
    public class BillDetailMap : EntityTypeConfiguration<BillDetail>
    {
        public const string TABLE_NAME = "bill_details";

        public BillDetailMap()
        {
            // Table Name
            ToTable(TABLE_NAME);

            // Key
            HasKey(bd => new { bd.BillId, bd.ServiceId });

        }
    }
}
