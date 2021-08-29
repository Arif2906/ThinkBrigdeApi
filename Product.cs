using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int unit_Price { get; set; }
        [StringLength(1, ErrorMessage = "Can have only value Y or N")]
        public string Available { get; set; }
        public int Quantity { get; set; }
        public string image { get; set; }
    }
}
