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
    
    public partial class User
    {
        public User()
        {
            this.Companies = new HashSet<Company>();
            this.Companies1 = new HashSet<Company>();
        }
    
        public string guid { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string role_guid { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Company> Companies1 { get; set; }
        public virtual Role Role { get; set; }
    }
}