using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using NetCoreWebApi.Services;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryServices _services;


        public InventoryController(IInventoryServices services)
        {
            Console.WriteLine("CALLING SECONDARY CTOR");
            _services = services;
        }

        [HttpPost]
        [Route("AddItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);

            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }

        [HttpGet]
        [Route("GetItems")]
        public ActionResult<Dictionary<string,InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services?.GetInventoryItems();

            if (inventoryItems?.Count == 0)
            {
                return new Dictionary<string, InventoryItems>
                {
                    {"Nothing Added", new InventoryItems{ Id = 0, ItemName = "NONE", Price = 0} }
                };
            }

            return inventoryItems;
        }

    }
}
