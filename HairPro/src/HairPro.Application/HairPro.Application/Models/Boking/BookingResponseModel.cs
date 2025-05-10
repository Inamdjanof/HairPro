using HairPro.Application.Models.BarberService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.Boking
{
    public class BookingResponseModel : BaseResponseModel
    { 
        public Guid OrderId { get; set; }
        public Guid BarberServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public bool IsConfirmed { get; set; }

        // Qo'shimcha ma'lumotlar (masalan, Order va BarberService haqida)
       // public OrderResponseModel Order { get; set; }
        public BarberServiceResponseModel BarberService { get; set; }
    }

}
