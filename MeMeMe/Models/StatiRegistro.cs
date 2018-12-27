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
    
    public partial class StatiRegistro
    {
        public StatiRegistro()
        {
            this.Drop = new HashSet<Drop>();
        }
    
        public int idStatoRegistro { get; set; }
        public int idPaziente { get; set; }
        public int idStato { get; set; }
        public System.DateTime DataApertura { get; set; }
        public Nullable<System.DateTime> DataChiusura { get; set; }
        public bool Completamento { get; set; }
    
        public virtual Antropometria Antropometria { get; set; }
        public virtual AttivitaFisica AttivitaFisica { get; set; }
        public virtual DiarioDieta24 DiarioDieta24 { get; set; }
        public virtual Prelievo Prelievo { get; set; }
        public virtual StatiElenco StatiElenco { get; set; }
        public virtual Trattamenti Trattamenti { get; set; }
        public virtual ValutazioneMetformina ValutazioneMetformina { get; set; }
        public virtual StileDiVita StileDiVita { get; set; }
        public virtual ICollection<Drop> Drop { get; set; }
        public virtual Anagrafica Anagrafica { get; set; }
        public virtual MEDAS MEDAS { get; set; }
    }
}
