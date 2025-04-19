using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.Notification
{
    public class NotificationCreateModel
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
    }

}
