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
    
    public partial class TrattamentiDettaglio
    {
        public int idTrattamentoDettaglio { get; set; }
        public int idStatoRegistro { get; set; }
        public int tipoTrattamento { get; set; }
        public string tipoTrattamentoAltro { get; set; }
        public string trattamento { get; set; }
        public string doseGiornaliera { get; set; }
        public string motivo { get; set; }
        public string durata { get; set; }
    
        public virtual LUTipoTrattamento LUTipoTrattamento { get; set; }
        public virtual Trattamenti Trattamenti { get; set; }
    }
}