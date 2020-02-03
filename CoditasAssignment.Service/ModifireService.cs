using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignment.Service
{
    public interface IModifireService
    {
        Response<List<ModifireViewModel>> GetModifires(string name = null);
        Response<ModifireViewModel> GetModifire(int id);
        Response<ModifireViewModel> AddModifire(ModifireViewModel modifire);
        Response<ModifireViewModel> UpdateModifire(ModifireViewModel modifire);
        Response<ModifireViewModel> DeleteModifire(int id);
        void SaveModifire();
    }

    public class ModifireService : IModifireService
    {
        private readonly IModifireRepository modifireRepository;
        private readonly IItemRepository itemRepository;

        private readonly IUnitOfWork unitOfWork;

        public ModifireService(IModifireRepository modifireRepository, IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this.modifireRepository = modifireRepository;
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IModifireService Members

        public Response<List<ModifireViewModel>> GetModifires(string name = null)
        {
            var modifires = new List<ItemModifire>();
            if (string.IsNullOrEmpty(name))
                modifires = modifireRepository.GetAll().ToList();
            else
                modifires = modifireRepository.GetAll().Where(c => c.name == name).ToList();

            var modifireViewModel = Mapper.Map<List<ItemModifire>, List<ModifireViewModel>>(modifires);
            return new Response<List<ModifireViewModel>>
            {
                Status = 1,
                Record = modifireViewModel,
                Message = "Success"
            };
        }

        public Response<ModifireViewModel> GetModifire(int id)
        {
            var modifire = modifireRepository.GetById(id);
            if (modifire == null)
                return new Response<ModifireViewModel> { Status = 0, Message = "No record found" };

            var modifireViewModel = Mapper.Map<ItemModifire, ModifireViewModel>(modifire);

            return new Response<ModifireViewModel>
            {
                Status = 1,
                Record = modifireViewModel,
                Message = "Success"
            };
        }

        public Response<ModifireViewModel> AddModifire(ModifireViewModel modifireViewModel)
        {
            var modifire = Mapper.Map<ModifireViewModel, ItemModifire>(modifireViewModel);
            modifireRepository.Add(modifire);
            SaveModifire();

            modifireViewModel = Mapper.Map<ItemModifire, ModifireViewModel>(modifire);
            return new Response<ModifireViewModel>
            {
                Status = 1,
                Record = modifireViewModel,
                Message = "Success"
            };
        }

        public Response<ModifireViewModel> UpdateModifire(ModifireViewModel modifireViewModel)
        {
            var modifire = Mapper.Map<ModifireViewModel, ItemModifire>(modifireViewModel);
            modifireRepository.Update(modifire);
            SaveModifire();

            return new Response<ModifireViewModel>
            {
                Status = 1,
                Record = modifireViewModel,
                Message = "Success"
            };
        }

        public Response<ModifireViewModel> DeleteModifire(int id)
        {
            var modifire = modifireRepository.GetById(id);
            if (modifire == null)
                return new Response<ModifireViewModel> { Status = 0, Message = "No record found" };

            //if (itemRepository.GetAll().Where(c => c.modifire_id == id).Count() > 0)
            //    return new Response<ModifireViewModel> { Status = 0, Message = "Reference exist in item" };

            modifireRepository.Delete(modifire);
            SaveModifire();
            var modifireViewModel = Mapper.Map<ItemModifire, ModifireViewModel>(modifire);

            return new Response<ModifireViewModel>
            {
                Status = 1,
                Message = "Success"
            };
        }

        public void SaveModifire()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
