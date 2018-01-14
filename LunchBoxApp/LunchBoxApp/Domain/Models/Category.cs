using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace LunchBoxApp.Domain.Models
{
    public class Category
    {
        [PrimaryKey]
        public Guid CategoryId { get; set; }

        [NotNull, MaxLength(50)]
        public string CategoryName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Subcategory> Subcategories { get; set; }
    }
}
