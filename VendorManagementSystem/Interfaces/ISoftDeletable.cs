using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorManagementSystem.Interfaces
{
    public interface ISoftDeletable
    {
        Nullable<System.DateTime> deleted_at { get; set; }
    }
}
