using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public interface IInventoryServices
    {

        InventoryItems AddInventoryItems(InventoryItems items);
        Dictionary<string,InventoryItems> GetInventoryItems();
    }
}
