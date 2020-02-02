using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Store GetStoreByName(string storeName)
        {
            var store = this.DbContext.Stores.Where(c => c.name == storeName).FirstOrDefault();

            return store;
        }

        public override Store Update(Store entity)
        {
            // entity.DateUpdated = DateTime.Now;
           return base.Update(entity);
        }
    }

    public interface IStoreRepository : IRepository<Store>
    {
        Store GetStoreByName(string storeName);
    }
}
