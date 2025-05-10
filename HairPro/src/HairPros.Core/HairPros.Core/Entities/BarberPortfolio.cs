using HairPros.Core.Common;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Core.Entities
{
    public class BarberPortfolio : BaseEntity
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BarberId { get; set; } // Barber bilan bog‘lash uchun
        public string FilePath { get; set; } // Fayl URL manzili
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Barber Barber { get; set; }

     

    }

 

}
