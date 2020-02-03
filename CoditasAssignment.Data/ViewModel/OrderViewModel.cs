using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string OrderNumber { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
    public class OrderItemModifireViewModel
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int ModifireId { get; set; }
    }
}
