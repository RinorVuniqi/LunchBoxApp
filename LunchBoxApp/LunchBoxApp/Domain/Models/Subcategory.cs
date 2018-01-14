using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace LunchBoxApp.Domain.Models
{
    public class Subcategory
    {
        [PrimaryKey]
        public Guid SubcategoryId { get; set; }

        [NotNull, MaxLength(50)]
        public string SubcategoryName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Product> Products { get; set; }

        [NotNull]
        public string ImageUrl { get; set; }

        [ForeignKey(typeof(Category))]
        public Guid CategoryId { get; set; }

        [ManyToOne(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
