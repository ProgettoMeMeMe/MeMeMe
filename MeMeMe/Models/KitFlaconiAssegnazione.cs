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
    
    public partial class KitFlaconiAssegnazione
    {
        public int idAssegnazione { get; set; }
        public string Kit { get; set; }
        public string utente { get; set; }
        public System.DateTime dataAssegnazione { get; set; }
        public int idPaziente { get; set; }
        public int idAssegnazioneElenco { get; set; }
    
        public virtual AssegnazioniElenco AssegnazioniElenco { get; set; }
        public virtual KitRandomizzazione KitRandomizzazione { get; set; }
        public virtual Anagrafica Anagrafica { get; set; }
    }
}
