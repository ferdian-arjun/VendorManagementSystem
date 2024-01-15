//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VendorManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using VendorManagementSystem.Interfaces;

    public partial class CategoryType : ISoftDeletable
    {
        public CategoryType()
        {
            this.Companies = new HashSet<Company>();
        }
    
        public string guid { get; set; }
        public string business_type_guid { get; set; }
        public string name { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    
        public virtual BusinessType BusinessType { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
