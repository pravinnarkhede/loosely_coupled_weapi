using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<ModifireViewModel> Modifires { get; set; }
    }
}
