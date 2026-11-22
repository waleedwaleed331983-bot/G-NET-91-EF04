using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_04.Models
{
    [Owned]
    public class Address
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

        public override string ToString()
        {
            return $"{Country}, {City}, {Street}";
        }

    }
}
