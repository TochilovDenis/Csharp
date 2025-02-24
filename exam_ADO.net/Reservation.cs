using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ADO.net
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int RecordID { get; set; }
        public int CustomerID { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
