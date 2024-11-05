using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Chat
{
    public class ChatSentResponse
    {
        public Guid? Id { get; set; }
        public string? MessageText { get; set; }
        public DateTime? Time { get; set; }
    }
}
