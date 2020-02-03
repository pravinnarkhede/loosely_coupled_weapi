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
    public class ModifireController : ApiController
    {
        private readonly IModifireService modifireService;

        public ModifireController(IModifireService modifireService)
        {
            this.modifireService = modifireService;
        }

        // GET: api/Modifire
        public Response<List<ModifireViewModel>> Get()
        {
            return modifireService.GetModifires();
        }

        // GET: api/Modifire/5
        public Response<ModifireViewModel> Get(int id)
        {
            return modifireService.GetModifire(id);
        }

        // POST: api/Modifire
        public Response<ModifireViewModel> Post(ModifireViewModel modifire)
        {
            return modifireService.AddModifire(modifire);
        }

        // PUT: api/Modifire/5
        public Response<ModifireViewModel> Put(ModifireViewModel modifire)
        {
            return modifireService.UpdateModifire(modifire);
        }

        // DELETE: api/Modifire/5
        public Response<ModifireViewModel> Delete(int id)
        {
            return modifireService.DeleteModifire(id);
        }
    }
}

