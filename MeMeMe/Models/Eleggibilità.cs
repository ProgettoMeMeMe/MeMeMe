using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{
    public class Eleggibilità
    {
        public int idPaziente { get; set; }
        public string sesso { get; set; }
        public int eta { get; set; }
        public bool etaCheck { get; set; }
        public string pressione { get; set; }
        public bool pressioneCheck { get; set; }
        public decimal circonferenzaVita { get; set; }
        public bool circonferenzaVitaCheck { get; set; }
        public int glicemia { get; set; }
        public bool glicemiaCheck { get; set; }
        public int trigliceridi { get; set; }
        public bool trigliceridiCheck { get; set; }
        public int colesterolemia { get; set; }
        public int colesteroloHDL { get; set; }
        public bool colesteroloHDLCheck { get; set; }
        public bool valutazioneCheck { get; set; }
        public bool ipertensioneCheck { get; set; }
        public bool ipercolesterolemiaCheck { get; set; }
        public bool ipertrigliceridemiaCheck { get; set; }
        public bool effettiCollateraliCheck { get; set; }   
        public decimal creatininemia { get; set; }
        public bool creatininemiaCheck { get; set; }
    }
 }