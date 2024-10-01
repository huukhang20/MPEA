using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class User
    {
        // Properties
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Relationships

        public ICollection<UserAddress> Addresses { get; set; }
        public ICollection<SparePart> SpareParts { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }    
        public ICollection<Exchange> ExchangeProviders { get; set; }
        public ICollection<Exchange> ExchangeOffers { get; set; }
        public ICollection<Chat> ChatReceiveds { get; set; }
        public ICollection<Chat> ChatSents {  get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Report> Reports { get; set; }    
        public ICollection<ExchangePart> ExchangeParts { get; set; }
    }
}
