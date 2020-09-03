using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public CuisinType CType { get; set; }

    }
}
