using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YatKiralama.Models
{
    public class Yat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Capacity { get; set; }
        public string Details { get; set; }


        public string ImgLocation { get; set; }

        public string ImgLocation2 { get; set; }

        public string ImgLocation3 { get; set; }

        public virtual List<Comment> Comments { get; set; }



    }
}
