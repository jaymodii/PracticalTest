using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PriceChangeDTO
    {
        public int itemcode { get; set; }

        public string increaseDecrease { get; set; } = null!;

        public string priceType { get; set; } = null!;

        public string priceUpate { get; set; } = null!;

        public decimal amount { get; set; }

        public PriceChangeDTO(int itemcode, string increaseDecrease, string priceType, string priceUpate, decimal amount)
        {
            this.itemcode = itemcode;
            this.increaseDecrease = increaseDecrease;
            this.priceType = priceType;
            this.priceUpate = priceUpate;
            this.amount = amount;

        }
    }
}
