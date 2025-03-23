using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberShops
{
    public class BarberShopResponseModel : BaseResponseModel
    { 
        public string Name { get; set; }
        public Guid ResponsibleBarberId { get; set; }
        public string Location { get; set; }
        public string DocumentPath { get; set; }
    }
}
