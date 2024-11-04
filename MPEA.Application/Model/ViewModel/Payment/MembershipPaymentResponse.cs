using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Payment
{
    public class MembershipPaymentResponse
    {
        public Guid? Id { get; set; }
        public string? Membership { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public string? UserCode { get; set; }
    }
}
