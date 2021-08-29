using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sales
    {
        public string invoice_Number { get; set; }
        public string employee_ID { get; set; }
        public bool discount { get; set; }
        public string vat { get; set; }
        public string invoice_Total { get; set; }
        public DateTime dateOfSale { get; set; }
    }
}
