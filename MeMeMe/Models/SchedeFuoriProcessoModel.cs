using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{
    public class TrailCodeList
    {
        public Int32 idPaziente { get; set; }
        public string trialCode { get; set; }
    }

    public class SAEListato
    {
        public int idSAE { get; set; }
        public int idPaziente { get; set; }
        [Display(Name = "Codice paziente")]
        public string trialCode { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public System.DateTime dataSAE { get; set; }
        [Display(Name = "Seriousness")]
        public string gravita { get; set; }
    }

    public class AEListato
    {
        public int idAE { get; set; }
        public int idPaziente { get; set; }
        [Display(Name = "Codice paziente")]
        public string trialCode { get; set; }
        [Display(Name = "Eventi")]
        public int nEventi { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public System.DateTime dataAE { get; set; }
    }

    public class AEDettaglioListato
    {
        public int idAEDettaglio { get; set; }
        public int idAE { get; set; }
        public string tipoEvento { get; set; }
        public string tipoEventoAltro { get; set; }
        public string serietaEvento { get; set; }
        public string reazioneFarmaco { get; set; }
        public string serietaGrado { get; set; }
        public string dataInizio { get; set; }
        public string dataFine { get; set; }
        public string outcome { get; set; }
    }

    [MetadataType(typeof(SAEMetadata))]
    public partial class SAE
    {
    }

    public class SAEMetadata
    {

        public int idSAE { get; set; }
        [Display(Name = "Trialcode ")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int idPaziente { get; set; }

        [Display(Name = "Study drug administered")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public string studyDrug { get; set; }
        [Display(Name = "Intended dose")]
        public Nullable<int> dosaggio { get; set; }
        [Display(Name = "Administered dose")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public string assunzioneSAE { get; set; }

        [Display(Name = "Start date")]
        [Required(ErrorMessage = "campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public System.DateTime dataAssegnazionePeriodoProva { get; set; }

        [Display(Name = "Last administration date")]
        [Required(ErrorMessage = "campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public System.DateTime dataUltimaAssunzione { get; set; }

        [Display(Name = "Date of SAE awareness")]
        [Required(ErrorMessage = "campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public System.DateTime dataSAE { get; set; }
        [Display(Name = "Serious adverse event Term/Diagnosis")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public string diagnosi { get; set; }
        [Display(Name = "Seriousness")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int gravita { get; set; }
        [Display(Name = "Causal relation to IMP/Study Drug")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int relazioneCausale { get; set; }
        [Display(Name = "Action taken with IMP")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public string azioneIntrapresa { get; set; }
        [Display(Name = "SAE Start Date")]
        [Required(ErrorMessage = "campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public System.DateTime inizioSAE { get; set; }
        [Display(Name = "SAE Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> fineSAE { get; set; }

        [Display(Name = "Did event abate after stopping drug?")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int reazioneArresto { get; set; }
        [Display(Name = "Was suspected drug re-administered?")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int risomministrazioneFarmaco { get; set; }
        [Display(Name = "If yes, please specify the date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> dataRisomministrazioneFarmaco { get; set; }
        [Display(Name = "Did event reappear after drug reintroduction?")]
        public Nullable<int> ripetizioneDopoRiassunzione { get; set; }
        [Display(Name = "Outcome")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int risultato { get; set; }
        [Display(Name = "Death due to the SAE?")]
        public Nullable<int> eventoFatale { get; set; }
        [Display(Name = "Date of death")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> dataMorte { get; set; }

        [Display(Name = "Was the dismetabolic condition that allowed the eligibility of the patient the primary cause of SAE?")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public Nullable<int> malattiaCausaSAE { get; set; }

        [Display(Name = "Name")]
        public string concomitante1 { get; set; }
        [Display(Name = "Indication ")]
        public string concomitante1Diagnosi { get; set; }
        [Display(Name = "Daily Dose")]
        public string concomitante1DoseGG { get; set; }
        [Display(Name = "Route")]
        public string concomitante1DaQuanto { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> concomitante1DataInzio { get; set; }
        [Display(Name = "Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> concomitante1DataFine { get; set; }
        [Display(Name = "Ongoing")]
        public Nullable<int> concomitante1InCorso { get; set; }
        [Display(Name = "Primary cause of the SAE?")]
        public Nullable<int> concomitante1CauseSAE { get; set; }
        [Display(Name = "If yes, does it require modification of the conduct of the trial?")]
        public Nullable<int> concomitante1modificaConduzioneTrial { get; set; }

        //[Display(Name = "2 Name")]
        public string concomitante2 { get; set; }
        //[Display(Name = "2 Indication ")]
        public string concomitante2Diagnosi { get; set; }
        //[Display(Name = "2 Daily Dose")]
        public string concomitante2DoseGG { get; set; }
        //[Display(Name = "2 Route")]
        public string concomitante2DaQuanto { get; set; }
        //[Display(Name = "2 Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> concomitante2DataInzio { get; set; }
        //[Display(Name = "2 Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> concomitante2DataFine { get; set; }
        //[Display(Name = "2 Ongoing")]
        public Nullable<int> concomitante2InCorso { get; set; }
        [Display(Name = "2 Primary cause of the SAE?")]
        public Nullable<int> concomitante2CauseSAE { get; set; }
        //[Display(Name = "3 Name")]
        public string concomitante3 { get; set; }
        //[Display(Name = "3 Indication")]
        public string concomitante3Diagnosi { get; set; }
        //[Display(Name = "3 Daily Dose")]
        public string concomitante3DoseGG { get; set; }
        //[Display(Name = "3 Route")]
        public string concomitante3DaQuanto { get; set; }
        //[Display(Name = "3 Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> concomitante3DataInzio { get; set; }
        //[Display(Name = "3 Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> concomitante3DataFine { get; set; }
        //[Display(Name = "3 Ongoing")]
        public Nullable<int> concomitante3InCorso { get; set; }
        //[Display(Name = "3 Primary cause of the SAE?")]
        public Nullable<int> concomitante3CauseSAE { get; set; }


        [Display(Name = "Disease/ Allergies/Risk Factors")]
        public byte[] malattiaAllergiaRischio1 { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> malattiaAllergiaRischio1DataInizio { get; set; }
        [Display(Name = "Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> malattiaAllergiaRischio1DataFine { get; set; }
        [Display(Name = "Ongoing")]
        public Nullable<int> malattiaAllergiaRischio1InCorso { get; set; }
        [Display(Name = "Primary cause of the SAE?")]
        public Nullable<int> malattiaAllergiaRischio1CausaPrimariaSAE { get; set; }
        //[Display(Name = "2 Disease/ Allergies/Risk Factors")]
        public byte[] malattiaAllergiaRischio2 { get; set; }
        //[Display(Name = "2 Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> malattiaAllergiaRischio2DataInizio { get; set; }
        //[Display(Name = "2 Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> malattiaAllergiaRischio2DataFine { get; set; }
        //[Display(Name = "2 Ongoing")]
        public Nullable<int> malattiaAllergiaRischio2InCorso { get; set; }
        //[Display(Name = "2 Primary cause of the SAE?")]
        public Nullable<int> malattiaAllergiaRischio2CausaPrimariaSAE { get; set; }
        //[Display(Name = "3 Disease/ Allergies/Risk Factors")]
        public byte[] malattiaAllergiaRischio3 { get; set; }
        //[Display(Name = "3 Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> malattiaAllergiaRischio3DataInizio { get; set; }
        //[Display(Name = "3 Stop Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> malattiaAllergiaRischio3DataFine { get; set; }
        //[Display(Name = "3 Ongoing")]
        public Nullable<int> malattiaAllergiaRischio3InCorso { get; set; }
        //[Display(Name = "3 Primary cause of the SAE?")]
        public Nullable<int> malattiaAllergiaRischio3CausaPrimariaSAE { get; set; }


        [Display(Name = "SAE Narrative")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public string osservazioni { get; set; }

    }

    [MetadataType(typeof(AEMetadata))]
    public partial class AE
    {
    }

    public class AEMetadata
    {
        public int idAE { get; set; }
        [Display(Name = "Trialcode ")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int idPaziente { get; set; }
        [Display(Name = "Data scheda")]
        [Required(ErrorMessage = "campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public System.DateTime dataAE { get; set; }
    }

    [MetadataType(typeof(AEDettaglioMetadata))]
    public partial class AEDettaglio
    {
    }
    public class AEDettaglioMetadata
    {
        public int idAEDettaglio { get; set; }
        public int idAE { get; set; }
        [Display(Name = "tipo evento")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int tipoEvento { get; set; }
        public string tipoEventoAltro { get; set; }
        [Display(Name = "serietà")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int serietaEvento { get; set; }
        [Display(Name = "relazione con il farmaco in studio")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int reazioneFarmaco { get; set; }
        [Display(Name = "grado")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int serietaGrado { get; set; }
        [Display(Name = "data inizio")]
        [Required(ErrorMessage = "campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public System.DateTime dataInizio { get; set; }
        [Display(Name = "data fine")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> dataFine { get; set; }
        [Display(Name = "outcome")]
        [Required(ErrorMessage = "campo obbligatorio")]
        public int outcome { get; set; }

        public virtual AE AE { get; set; }
        public virtual LUAE_Grado LUAE_Grado { get; set; }
        public virtual LUAE_Outcome LUAE_Outcome { get; set; }
        public virtual LUAE_TipoEvento LUAE_TipoEvento { get; set; }
    }


}