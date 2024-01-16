using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VendorManagementSystem.ViewModel
{
    public class RoleViewModel
    {
        [ReadOnly(true)]
        public string Guid { get; set; }
        public string Name {get; set; }
    }
}