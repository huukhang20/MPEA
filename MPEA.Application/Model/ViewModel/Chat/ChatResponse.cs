using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Chat
{
    public class ChatResponse
    {
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public string? MessageText { get; set; }
        public DateTime? Time { get; set; }
        public string? Status { get; set; }
    }
}
