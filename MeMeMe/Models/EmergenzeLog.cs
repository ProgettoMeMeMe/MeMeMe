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
    
    public partial class EmergenzeLog
    {
        public int idEmergenza { get; set; }
        public System.DateTime dataRegistrazione { get; set; }
        public string userName { get; set; }
        public string ricercaEsito { get; set; }
        public string ricerca { get; set; }
        public bool adminChecked { get; set; }
    }
}
