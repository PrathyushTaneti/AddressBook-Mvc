using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
    public partial class PersonDetail
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Landline { get; set; } = null!;
        public string Website { get; set; } = null!;
        public string? Address { get; set; }
    }
}
