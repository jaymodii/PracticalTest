using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class ItemDTO
    {
        public int Srno { get; set; }
        public int Itemcode { get; set; }
        public string Barcode { get; set; } = null!;
        public string Itemname { get; set; } = null!;
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ItemDTO(int srno, int itemcode, string barcode, string itemname, decimal cost, decimal price, DateTime created, DateTime Updated)
        {
            Srno = srno;
            Itemcode = itemcode;
            Barcode = barcode;
            Itemname = itemname;
            Cost = cost;
            Price = price;
            CreateDate = created;
            UpdateDate = Updated;
        }
        public ItemDTO() { }
    }
}
