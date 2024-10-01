using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Exchange
    {
        // Properties

        public string? Id { get; set; }
        public string? ExchangeTypeId { get; set; }
        public string? Status {  get; set; }
        public string? AgreementTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public string? FirstExchagerId { get; set; }
        public string? SecondExchangerId { get; set; }

        // Relationships

        public User FirstExchager { get; set; }
        public User SecondExchager { get; set; }
        public ExchangeType ExchangeType { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    
    }
}
