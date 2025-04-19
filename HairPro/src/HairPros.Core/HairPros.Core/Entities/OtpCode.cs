using HairPro.Core.Enums;
using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Core.Entities
{
    public class OtpCode : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public DateTime ExpiryTime { get; set; }
        public OtpCodeStatus Status { get; set; }
     
      

    }
}
