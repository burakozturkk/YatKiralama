using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YatKiralama.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Mail { get; set; }
        public string Sifre { get; set; }

        public bool admin { get; set; }
    }
}
