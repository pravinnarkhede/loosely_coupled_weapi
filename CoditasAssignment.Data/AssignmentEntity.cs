namespace CoditasAssignment.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class AssignmentEntities : DbContext
    {
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
