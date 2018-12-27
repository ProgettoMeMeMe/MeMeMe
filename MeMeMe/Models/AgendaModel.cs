using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{
    public class Agenda
    {
        [Display(Name = "data da")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        //[Required(ErrorMessage = "data obbligatoria")]
        public System.DateTime? dataDa { get; set; }

        [Display(Name = "data a")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        //[Required(ErrorMessage = "data obbligatoria")]
        public System.DateTime? dataA { get; set; }
    }

    public class AgendaListato
    {
        public string idMeMeMe { get; set; }
        public Int32 idPaziente { get; set; }
        public string paziente { get; set; }
        public string cfiscale { get; set; }
        public string fase { get; set; }
        public DateTime consegnaFlaconi { get; set; }
        public string flaconi { get; set; }
        //public string dosaggio { get; set; }
        public string prossimoRitiro { get; set; }
        public DateTime prossimoRitiroData { get; set; }
    }

    public class PrelieviListato
    {
        public string progetto { get; set; }
        public string dataPrelievo { get; set; }
        public string paziente { get; set; }
        public Int32 idPaziente { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string dieta { get; set; }
        public string telefonoCasa { get; set; }
        public string telefonoLavoro { get; set; }
        public string telefonoCellulare { get; set; }
    }
}