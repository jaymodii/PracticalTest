﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IItemInterface
    {
        public List<ItemDTO> ListItems();

        public string AddItem(ItemDTO itemDTO);
    }
}
