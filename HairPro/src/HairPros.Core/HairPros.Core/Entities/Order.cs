using HairPros.Core.Common;
using HairPros.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid BarberId { get; set; }
        public int TotalAmount { get; set; }
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;

        public Customer Customer { get; set; }
        public Barber Barber { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }




}
