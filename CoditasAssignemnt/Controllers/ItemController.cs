using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignemnt.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        // GET: api/Item
        public Response<List<ItemViewModel>> Get()
        {
            return itemService.GetItems();
        }

        // GET: api/Item/5
        public Response<ItemViewModel> Get(int id)
        {
            return itemService.GetItem(id);
        }

        // POST: api/Item
        public Response<ItemViewModel> Post(ItemViewModel item)
        {
            return itemService.AddItem(item);
        }

        // PUT: api/Item/5
        public Response<ItemViewModel> Put(ItemViewModel item)
        {
            return itemService.UpdateItem(item);
        }

        // DELETE: api/Item/5
        public Response<ItemViewModel> Delete(int id)
        {
            return itemService.DeleteItem(id);
        }
    }
}

