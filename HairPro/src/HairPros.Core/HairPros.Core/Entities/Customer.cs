using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class Customer : BaseEntity
    {

        public Guid UserId { get; set; }
        public User User { get; set; }


    
    }
}
