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

    public partial class Project : ISoftDeletable, IDateUpdate
    {
        public Project()
        {
            this.CompanyProjects = new HashSet<CompanyProject>();
        }
    
        public string guid { get; set; }
        public string name { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public string status { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    
        public virtual ICollection<CompanyProject> CompanyProjects { get; set; }
    }
}
