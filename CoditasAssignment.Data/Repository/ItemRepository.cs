using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Item GetItemByName(string itemName)
        {
            var item = this.DbContext.Items.Where(c => c.name == itemName).FirstOrDefault();

            return item;
        }

        public override Item Update(Item entity)
        {
            // entity.DateUpdated = DateTime.Now;
           return base.Update(entity);
        }
    }

    public interface IItemRepository : IRepository<Item>
    {
        Item GetItemByName(string itemName);
    }
}
