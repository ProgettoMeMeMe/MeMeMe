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
    
    public partial class LUDropMotivazioni
    {
        public LUDropMotivazioni()
        {
            this.Drop = new HashSet<Drop>();
        }
    
        public int idMotivazione { get; set; }
        public string motivazione { get; set; }
    
        public virtual ICollection<Drop> Drop { get; set; }
    }
}
