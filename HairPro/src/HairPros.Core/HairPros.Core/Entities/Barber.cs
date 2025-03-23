using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class Barber : BaseEntity , IAuditedEntity
    {
        public Guid UserId { get; set; }
        public Guid BarberShopId { get; set; }
        public float AverageRating { get; set; }

        public User User { get; set; }
        public BarberShop BarberShop { get; set; }

        // Audit maydonlari
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
