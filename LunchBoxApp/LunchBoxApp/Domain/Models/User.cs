using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace LunchBoxApp.Domain.Models
{
    public class User
    {
        [PrimaryKey]
        public Guid UserId { get; set; }

        [NotNull, MaxLength(50)]
        public string UserName { get; set; }

        [NotNull, MaxLength(50)]
        public string UserEmail { get; set; }

        [NotNull, MaxLength(50)]
        public string UserPassword { get; set; }

        [NotNull, MaxLength(50)]
        public string UserFirstName { get; set; }

        [NotNull, MaxLength(50)]
        public string UserLastName { get; set; }
    }
}
