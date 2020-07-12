using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YatKiralama.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Detail { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public int YatId { get; set; }

        public int UserID { get; set; }
    }
}
