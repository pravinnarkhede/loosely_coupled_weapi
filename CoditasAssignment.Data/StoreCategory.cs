//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoditasAssignment.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreCategory
    {
        public int id { get; set; }
        public Nullable<int> store_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public bool is_active { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Store Store { get; set; }
    }
}
