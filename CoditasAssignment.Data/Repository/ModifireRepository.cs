using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class ModifireRepository : RepositoryBase<Modifire>, IModifireRepository
    {
        public ModifireRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Modifire GetModifireByName(string modifireName)
        {
            var modifire = this.DbContext.Modifires.Where(c => c.name == modifireName).FirstOrDefault();

            return modifire;
        }

        public override Modifire Update(Modifire entity)
        {
            // entity.DateUpdated = DateTime.Now;
           return base.Update(entity);
        }
    }

    public interface IModifireRepository : IRepository<Modifire>
    {
        Modifire GetModifireByName(string modifireName);
    }
}
