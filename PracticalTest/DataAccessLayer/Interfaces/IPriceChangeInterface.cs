using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPriceChangeInterface
    {
        public string AddPriceChangeAndUpdateItem(PriceChangeDTO pricedata);

        public List<PriceChangeDTO> ListPriceChanges();
    }
}
