using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.BarberShop
{

    public class BarberShopUpdateModel
    {
        public Guid Id { get; set; }  
        public string Name { get; set; } = string.Empty;
        public Guid ResponsibleBarberId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string DocumentPath { get; set; } = string.Empty;
    }


}
