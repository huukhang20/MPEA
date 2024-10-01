﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class ExchangePart
    {
        // Properties

        public string? Id { get; set; }
        public string? ExchangeId {  get; set; }
        public string? SparePartId { get; set; }
        public string? ExchangerId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt {  get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Relationships

        public SparePart SparePart { get; set; }
        public Exchange Exchange { get; set; }  
        public User Exchager { get; set; }
    }
}
