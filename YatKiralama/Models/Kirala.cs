using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YatKiralama.Models
{
    public class Kirala
    {
        public int ID { get; set; }
        public int YatID { get; set; }
      
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Tarih Seçiniz.")]
        public int SaatID { get; set; }
        [Required(ErrorMessage = "Saat Seçiniz.")] 
        public int UserID { get; set; }

    }
}
