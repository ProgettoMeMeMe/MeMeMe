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
    
    public partial class LUAE_TipoEvento
    {
        public LUAE_TipoEvento()
        {
            this.AEDettaglio = new HashSet<AEDettaglio>();
        }
    
        public int idAETipoEvento { get; set; }
        public string TipoEvento { get; set; }
    
        public virtual ICollection<AEDettaglio> AEDettaglio { get; set; }
    }
}
