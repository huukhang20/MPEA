using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Exchange
{
    public class ExchangeResponse
    {
        public Guid? Id { get; set; }
        public string? ProviderCode{ get; set; }
        public string? OffererCode { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
