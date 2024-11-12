using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Payment
{
    public class PaymentHistoryResponse
    {
        public Guid? Id { get; set; }
        public string? Code { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }
}
