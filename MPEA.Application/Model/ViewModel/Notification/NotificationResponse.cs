using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Notification
{
    public class NotificationResponse
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserId { get; set; }

    }
}
