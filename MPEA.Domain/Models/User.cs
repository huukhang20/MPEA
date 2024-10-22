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
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? AvatarURL { get; set; }
        public string? Role { get; set; }
        public string? Code { get; set; }
        public string? Status { get; set; } 
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Relationships

        public virtual ICollection<UserAddress> Addresses { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }    
        public virtual ICollection<Exchange> ExchangeProviders { get; set; }
        public virtual ICollection<Exchange> ExchangeOffers { get; set; }
        public virtual ICollection<Chat> ChatReceiveds { get; set; }
        public virtual ICollection<Chat> ChatSents {  get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Report> Reports { get; set; }    
        public virtual ICollection<ExchangePart> ExchangeParts { get; set; }
    }
}
