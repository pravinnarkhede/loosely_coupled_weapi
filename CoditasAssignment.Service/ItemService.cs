using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignment.Service
{
    public interface IItemService
    {
        Response<List<ItemViewModel>> GetItems(string name = null);
        Response<ItemViewModel> GetItem(int id);
        Response<ItemViewModel> GetItem(string name);
        Response<ItemViewModel> AddItem(ItemViewModel item);
        Response<ItemViewModel> UpdateItem(ItemViewModel item);
        Response<ItemViewModel> DeleteItem(int id);
        void SaveItem();
    }

    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly IOrderRepository orderRepository;

        private readonly IUnitOfWork unitOfWork;

        public ItemService(IItemRepository itemRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IItemService Members

        public Response<List<ItemViewModel>> GetItems(string name = null)
        {
            var items = new List<Item>();
            if (string.IsNullOrEmpty(name))
                items = itemRepository.GetAll().ToList();
            else
                items = itemRepository.GetAll().Where(c => c.name == name).ToList();

            return new Response<List<ItemViewModel>>
            {
                Status = 1,
                Record = items.Select(s => new ItemViewModel
                {
                    Id = s.id,
                    Name = s.name,
                    Modifires = s.ItemModifires.Select(m => new ModifireViewModel
                    {
                        Id = m.id,
                        Name = m.name,
                        Price = m.price
                    }).ToList(),
                }).ToList(),
                Message = "Success"
            };
        }

        public Response<ItemViewModel> GetItem(int id)
        {
            var item = itemRepository.GetById(id);
            if (item == null)
                return new Response<ItemViewModel> { Status = 0, Message = "No record found" };

            var itemViewModel = Mapper.Map<Item, ItemViewModel>(item);

            return new Response<ItemViewModel>
            {
                Status = 1,
                Record = itemViewModel,
                Message = "Success"
            };
        }

        public Response<ItemViewModel> GetItem(string name)
        {
            var item = itemRepository.GetItemByName(name);
            if (item == null)
                return new Response<ItemViewModel> { Status = 0, Message = "No record found" };

            return new Response<ItemViewModel>
            {
                Status = 1,
                Record = new ItemViewModel
                {
                    Id = item.id,
                    Name = item.name,
                    Modifires = item.ItemModifires.Select(m => new ModifireViewModel
                    {
                        Id = m.id,
                        Name = m.name,
                        Price = m.price
                    }).ToList()
                },
                Message = "Success"
            };
        }

        public Response<ItemViewModel> AddItem(ItemViewModel itemViewModel)
        {
            var item = Mapper.Map<ItemViewModel, Item>(itemViewModel);
            itemRepository.Add(item);
            SaveItem();

            itemViewModel = Mapper.Map<Item, ItemViewModel>(item);
            return new Response<ItemViewModel>
            {
                Status = 1,
                Record = itemViewModel,
                Message = "Success"
            };
        }

        public Response<ItemViewModel> UpdateItem(ItemViewModel item)
        {
            var existingItem = GetItem(item.Id);
            if (existingItem == null)
                return new Response<ItemViewModel>
                {
                    Status = 1,
                    Record = item,
                    Message = "Success"
                };

            //itemRepository.Update(existingItem.Record);
            //SaveItem();
            return new Response<ItemViewModel>
            {
                Status = 1,
                Record = item,
                Message = "Success"
            };
        }

        public Response<ItemViewModel> DeleteItem(int id)
        {
            return null;
            //var item = GetItem(id);
            //if (item == null)
            //    return false;

            //if (orderRepository.GetAll().SelectMany(c => c.OrderItems.Where(f => f.item_id == id)).Count() > 0)
            //    return false;

            //itemRepository.Delete(item);
            //SaveItem();
            //return true;
        }

        public void SaveItem()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
