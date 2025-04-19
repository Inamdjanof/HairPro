using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.BarberRating
{
    public class BarberRatingResponseModel : BaseResponseModel
    {
        public Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
        public short Rating { get; set; }
        public string? Comment { get; set; }

        
   
    }

}
