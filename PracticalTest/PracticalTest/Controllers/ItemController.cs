using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTest.Controllers
{
    public class ItemController : Controller
    {
       private readonly IItemInterface _itemInterface;
       private readonly IPriceChangeInterface _priceChangeInterface;
        public ItemController(IItemInterface itemInterface,IPriceChangeInterface priceChangeInterface)
        {
            _itemInterface = itemInterface;
            _priceChangeInterface = priceChangeInterface;
        }
        
        public IActionResult GetItems()
        {
           List<ItemDTO> items = _itemInterface.ListItems();
            
            return View(items);
        }

        public IActionResult AddItem(ItemDTO itemDTO)
        {
            TempData["status"]=_itemInterface.AddItem(itemDTO);
            return View();
        }

        public IActionResult GetPriceChanges()
        {
            List<PriceChangeDTO> changeList=_priceChangeInterface.ListPriceChanges();
            return View(changeList);
        }

        public IActionResult AddPriceChange(PriceChangeDTO priceChangeDTO)
        {

            TempData["status"] = _priceChangeInterface.AddPriceChangeAndUpdateItem(priceChangeDTO);
            return View();
        }
    }
}
