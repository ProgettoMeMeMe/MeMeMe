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
    
    public partial class Prelievo
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        public System.DateTime data { get; set; }
        public Nullable<decimal> leucociti { get; set; }
        public Nullable<decimal> eritrociti { get; set; }
        public Nullable<decimal> emoglobina { get; set; }
        public Nullable<decimal> ematocrito { get; set; }
        public Nullable<decimal> MCV { get; set; }
        public Nullable<decimal> MCH { get; set; }
        public Nullable<decimal> MCHC { get; set; }
        public Nullable<decimal> RDW { get; set; }
        public Nullable<int> piastrine { get; set; }
        public Nullable<decimal> MPV { get; set; }
        public Nullable<decimal> neutrofili_pc { get; set; }
        public Nullable<decimal> neutrofili_nm { get; set; }
        public Nullable<decimal> linfociti_pc { get; set; }
        public Nullable<decimal> linfociti_nm { get; set; }
        public Nullable<decimal> monociti_pc { get; set; }
        public Nullable<decimal> monociti_nm { get; set; }
        public Nullable<decimal> eosinofili_pc { get; set; }
        public Nullable<decimal> eosinofili_nm { get; set; }
        public Nullable<decimal> basofili_pc { get; set; }
        public Nullable<decimal> basofili_nm { get; set; }
        public Nullable<decimal> grandicellule_pc { get; set; }
        public Nullable<decimal> grandicellule_nm { get; set; }
        public int glicemia { get; set; }
        public decimal creatininemia { get; set; }
        public Nullable<int> transaminasiGOT_AST { get; set; }
        public Nullable<int> transaminasiGPL_ALT { get; set; }
        public Nullable<int> gammaGlutammil { get; set; }
        public int colesterolemia { get; set; }
        public int HDL { get; set; }
        public Nullable<int> LDL { get; set; }
        public int trigliceridi { get; set; }
        public Nullable<decimal> EGFR { get; set; }
        public string urinePh { get; set; }
        public string urineLeucociti { get; set; }
        public string urineNitriti { get; set; }
        public string urineAlbumina { get; set; }
        public string urineGlucosio { get; set; }
        public string urineChetoni { get; set; }
        public string urineUrobinologico { get; set; }
        public string urineBilirubina { get; set; }
        public string urineEmoglobina { get; set; }
        public string urinePesoSpecifico { get; set; }
        public string urineAspetto { get; set; }
        public string urineColore { get; set; }
        public string urineEsameSedimento { get; set; }
        public string note { get; set; }
    
        public virtual StatiRegistro StatiRegistro { get; set; }
    }
}
