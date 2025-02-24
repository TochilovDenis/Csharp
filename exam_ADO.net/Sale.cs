using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ADO.net
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int RecordID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
