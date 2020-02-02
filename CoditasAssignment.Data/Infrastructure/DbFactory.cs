using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        AssignmentEntities dbContext;

        public AssignmentEntities Init()
        {
            return dbContext ?? (dbContext = new AssignmentEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
