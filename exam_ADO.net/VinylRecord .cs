using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ADO.net
{
    public class VinylRecord
    {
        public int RecordID { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Publisher { get; set; }
        public int TrackCount { get; set; }
        public int GenreId { get; set; }
        public int ReleaseYear { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }


    }
}
