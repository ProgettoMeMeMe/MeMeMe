//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeMeMe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LUIParentela
    {
        public LUIParentela()
        {
            this.Anagrafica = new HashSet<Anagrafica>();
        }
    
        public int idParentela { get; set; }
        public string parentela { get; set; }
    
        public virtual ICollection<Anagrafica> Anagrafica { get; set; }
    }
}
