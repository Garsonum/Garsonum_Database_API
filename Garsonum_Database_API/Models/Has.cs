//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garsonum_Database_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Has
    {
        public int u_id { get; set; }
        public int o_id { get; set; }
        public int p_id { get; set; }
        public Nullable<double> p_portion { get; set; }
        public int p_amount { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
