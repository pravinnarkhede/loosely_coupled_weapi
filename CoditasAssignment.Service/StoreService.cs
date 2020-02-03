using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignment.Service
{
    public interface IStoreService
    {
        Response<List<StoreViewModel>> GetStores(string name = null);
        Response<StoreViewModel> GetStore(int id);
        Response<StoreViewModel> AddStore(StoreViewModel store);
        Response<StoreViewModel> UpdateStore(StoreViewModel store);
        Response<StoreViewModel> DeleteStore(int id);
        void SaveStore();
    }

    public class StoreService : IStoreService
    {
        private readonly IStoreRepository storeRepository;
        private readonly IItemRepository itemRepository;

        private readonly IUnitOfWork unitOfWork;

        public StoreService(IStoreRepository storeRepository, IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this.storeRepository = storeRepository;
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IStoreService Members

        public Response<List<StoreViewModel>> GetStores(string name = null)
        {
            var stores = new List<Store>();
            if (string.IsNullOrEmpty(name))
                stores = storeRepository.GetAll().ToList();
            else
                stores = storeRepository.GetAll().Where(c => c.name == name).ToList();

            var storeViewModel = Mapper.Map<List<Store>, List<StoreViewModel>>(stores);
            return new Response<List<StoreViewModel>>
            {
                Status = 1,
                Record = storeViewModel,
                Message = "Success"
            };
        }

        public Response<StoreViewModel> GetStore(int id)
        {
            var store = storeRepository.GetById(id);
            if (store == null)
                return new Response<StoreViewModel> { Status = 0, Message = "No record found" };

            var storeViewModel = Mapper.Map<Store, StoreViewModel>(store);

            return new Response<StoreViewModel>
            {
                Status = 1,
                Record = storeViewModel,
                Message = "Success"
            };
        }

        public Response<StoreViewModel> AddStore(StoreViewModel storeViewModel)
        {
            var store = Mapper.Map<StoreViewModel, Store>(storeViewModel);
            storeRepository.Add(store);
            SaveStore();

            storeViewModel = Mapper.Map<Store, StoreViewModel>(store);
            return new Response<StoreViewModel>
            {
                Status = 1,
                Record = storeViewModel,
                Message = "Success"
            };
        }

        public Response<StoreViewModel> UpdateStore(StoreViewModel storeViewModel)
        {
            var store = Mapper.Map<StoreViewModel, Store>(storeViewModel);
            storeRepository.Update(store);
            SaveStore();

            return new Response<StoreViewModel>
            {
                Status = 1,
                Record = storeViewModel,
                Message = "Success"
            };
        }

        public Response<StoreViewModel> DeleteStore(int id)
        {
            var store = storeRepository.GetById(id);
            if (store == null)
                return new Response<StoreViewModel> { Status = 0, Message = "No record found" };

            //if (itemRepository.GetAll().Where(c => c.store_id == id).Count() > 0)
            //    return new Response<StoreViewModel> { Status = 0, Message = "Reference exist in item" };

            storeRepository.Delete(store);
            SaveStore();
            var storeViewModel = Mapper.Map<Store, StoreViewModel>(store);

            return new Response<StoreViewModel>
            {
                Status = 1,
                Message = "Success"
            };
        }

        public void SaveStore()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
