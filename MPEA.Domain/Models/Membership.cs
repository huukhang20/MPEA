﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Membership
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Duration {  get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
