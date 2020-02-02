using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Order GetOrderByNumber(string orderNumber)
        {
            var order = this.DbContext.Orders.Where(c => c.order_number == orderNumber).FirstOrDefault();
            return order;
        }

        public override Order Add(Order entity)
        {
            entity.order_date = DateTime.Now;
            return base.Add(entity);
        }
        public override Order Update(Order entity)
        {
            return base.Update(entity);
        }
    }

    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrderByNumber(string orderNumber);
    }
}
