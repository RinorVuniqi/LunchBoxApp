using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace LunchBoxApp.Domain.Models
{
    public class Product
    {
        [PrimaryKey]
        public Guid ProductId { get; set; }
        
        [NotNull, MaxLength(50)]
        public string ProductName { get; set; }

        [NotNull]
        public bool ProductOfTheWeek { get; set; }

        [MaxLength(100)]
        public string ProductDescription { get; set; }

        [MaxLength(500)]
        public string ProductNote { get; set; }

        [NotNull]
        public decimal ProductPrice { get; set; }

        [NotNull]
        public int ProductQuantity { get; set; }

        [MaxLength(100)]
        public string ProductPersonName { get; set; }

        [NotNull]
        public string ImageUrl { get; set; }

        public List<string> Ingredients { get; set; }

        [ForeignKey(typeof(Subcategory))]
        public Guid SubcategoryId { get; set; }

        [ManyToOne(nameof(SubcategoryId))]
        public Subcategory Subcategory { get; set; }
    }
}
