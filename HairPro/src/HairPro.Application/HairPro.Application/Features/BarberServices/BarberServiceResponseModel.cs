using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberServices
{
    public class BarberServiceResponseModel : BaseResponseModel
    {

        public Guid BarberId { get; set; }
        public string BarberName { get; set; } // Barber nomini olish uchun
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; } // Service nomini olish uchun
        public decimal Price { get; set; }

    }

}

