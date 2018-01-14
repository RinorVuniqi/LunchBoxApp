using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace LunchBoxApp.Domain.Models
{
    public class Payment
    {
        [PrimaryKey]
        public Guid PaymentId { get; set; }

        [NotNull, MaxLength(50)]
        public string PaymentName { get; set; }
    }
}
