using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace LunchBoxApp.Domain.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public Guid OrderId { get; set; }

        [NotNull]
        public decimal OrderTotalPrice { get; set; }

        [NotNull]
        public int OrderTotalProductCount { get; set; }

        [NotNull]
        public Payment OrderPayment { get; set; }

        [NotNull]
        public bool DeliverySelected { get; set; }

        [MaxLength(50)]
        public string OrderCompanyName { get; set; }

        [NotNull]
        public User OrderUser { get; set; }

        [Ignore, OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Product> Products { get; set; }

        
    }
}
