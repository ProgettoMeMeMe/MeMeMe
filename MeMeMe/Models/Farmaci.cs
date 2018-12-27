using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{
    public class FarmaciListato
    {
        public int idAssegnazioneRegistro { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [Display(Name = "regitrazione")]
        public System.DateTime consegna { get; set; }
        public string fase { get; set; }
        public string flaconi { get; set; }
        [Display(Name = "dosaggio")]
        public string dosaggio { get; set; }
        public string pilloleFasePrecedente { get; set; }
        [Display(Name = "gg*")]
        public string PeriodoDaTmeno1 { get; set; }
    }

    public class Scorte
    {
        [Display(Name = "Lotto")]
        public string lotto { get; set; }
        [Display(Name = "Flaconi")]
        public Nullable<int> totale { get; set; }
        [Display(Name = "Resi")]
        public Nullable<int> resi { get; set; }
        [Display(Name = "Assegnati")]
        public Nullable<int> assegnati { get; set; }
        [Display(Name = "Disponibili")]
        public Nullable<int> disponibili { get; set; }
        [Display(Name = "Conesgna")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")] 
        public Nullable<System.DateTime> dataConsegna { get; set; }
        [Display(Name = "Scadenza")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")] 
        public Nullable<System.DateTime> scadenzaFarmaco { get; set; }
    }

    public class RiepilogoFarmaci
    {
        public int pilloleDPAssegnate { get; set; }
        public int pilloleDPAssunte { get; set; }
        public int pilloleDPInCarico { get; set; }
        public int pilloleMDAssegnate { get; set; }
        public int pilloleMDAssunte { get; set; }
        public int pilloleMDInCarico { get; set; }

        public int flaconiDPAssegnati { get; set; }
        public int flaconiDPInCarico { get; set; }
        public int flaconiMDAssegnati { get; set; }
        public int flaconiMDInCarico { get; set; }
    }
 }