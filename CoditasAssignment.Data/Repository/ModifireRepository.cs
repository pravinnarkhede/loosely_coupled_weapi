using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class ModifireRepository : RepositoryBase<ItemModifire>, IModifireRepository
    {
        public ModifireRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public ItemModifire GetModifireByName(string modifireName)
        {
            var modifire = this.DbContext.ItemModifires.Where(c => c.name == modifireName).FirstOrDefault();
            return modifire;
        }
    }

    public interface IModifireRepository : IRepository<ItemModifire>
    {
        ItemModifire GetModifireByName(string modifireName);
    }
}
