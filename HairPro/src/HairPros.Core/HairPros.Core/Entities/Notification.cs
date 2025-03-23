using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{

    public class Notification : BaseEntity
    {
        public string Message { get; set; } // Xabar matni
        public bool IsRead { get; set; } = false; // O‘qilgan yoki yo‘q
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Bildirishnoma vaqti
        public Guid UserId { get; set; } // Bildirishnoma kimga yuborilgan
        public User User { get; set; } // Bog‘langan foydalanuvchi
    }

}
