using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{
    public class FamiglieList
    {
        public Int32 famiglia { get; set; }
        public string famigliaDescrizione { get; set; }
    }
    public class AnagraficheList
    {
        public Int32 idPaziente { get; set; }
        public string idMeMeMe { get; set; }
        public Int32 randomizzazioneDieta { get; set; }
        public string paziente { get; set; }
        public string cfiscale { get; set; }
        public string tipoPaziente { get; set; }
    }


    public class AnagraficheInserimenti
    {
        public Int32 idPaziente { get; set; }
        public string idMeMeMe { get; set; }
        public Int32 randomizzazioneDieta { get; set; }
        public string paziente { get; set; }
        public string cfiscale { get; set; }
        public string tipoPaziente { get; set; }
    }

    [MetadataType(typeof(AnagraficaMetadata))]
    public partial class Anagrafica
    {
        public IEnumerable<SelectListItem> ListaProvince
        {
            get
            {
                return new[] { 
                new SelectListItem {Value="AG",Text="Agrigento"},
                new SelectListItem {Value="AL",Text="Alessandria"},
                new SelectListItem {Value="AN",Text="Ancona"},
                new SelectListItem {Value="AR",Text="Arezzo"},
                new SelectListItem {Value="AP",Text="Ascoli Piceno"},
                new SelectListItem {Value="AT",Text="Asti"},
                new SelectListItem {Value="AV",Text="Avellino"},
                new SelectListItem {Value="BA",Text="Bari"},
                new SelectListItem {Value="BT",Text="Barletta-Andria-Trani"},
                new SelectListItem {Value="BL",Text="Belluno"},
                new SelectListItem {Value="BN",Text="Benevento"},
                new SelectListItem {Value="BG",Text="Bergamo"},
                new SelectListItem {Value="BI",Text="Biella"},
                new SelectListItem {Value="BO",Text="Bologna"},
                new SelectListItem {Value="BZ",Text="Bolzano/Bozen"},
                new SelectListItem {Value="BS",Text="Brescia"},
                new SelectListItem {Value="BR",Text="Brindisi"},
                new SelectListItem {Value="CA",Text="Cagliari"},
                new SelectListItem {Value="CL",Text="Caltanissetta"},
                new SelectListItem {Value="CB",Text="Campobasso"},
                new SelectListItem {Value="CI",Text="Carbonia-Iglesias"},
                new SelectListItem {Value="CE",Text="Caserta"},
                new SelectListItem {Value="CT",Text="Catania"},
                new SelectListItem {Value="CZ",Text="Catanzaro"},
                new SelectListItem {Value="CH",Text="Chieti"},
                new SelectListItem {Value="CO",Text="Como"},
                new SelectListItem {Value="CS",Text="Cosenza"},
                new SelectListItem {Value="CR",Text="Cremona"},
                new SelectListItem {Value="KR",Text="Crotone"},
                new SelectListItem {Value="CN",Text="Cuneo"},
                new SelectListItem {Value="EN",Text="Enna"},
                new SelectListItem {Value="FM",Text="Fermo"},
                new SelectListItem {Value="FE",Text="Ferrara"},
                new SelectListItem {Value="FI",Text="Firenze"},
                new SelectListItem {Value="FG",Text="Foggia"},
                new SelectListItem {Value="FC",Text="Forlì-Cesena"},
                new SelectListItem {Value="FR",Text="Frosinone"},
                new SelectListItem {Value="GE",Text="Genova"},
                new SelectListItem {Value="GO",Text="Gorizia"},
                new SelectListItem {Value="GR",Text="Grosseto"},
                new SelectListItem {Value="IM",Text="Imperia"},
                new SelectListItem {Value="IS",Text="Isernia"},
                new SelectListItem {Value="SP",Text="La Spezia"},
                new SelectListItem {Value="AQ",Text="L'Aquila"},
                new SelectListItem {Value="LT",Text="Latina"},
                new SelectListItem {Value="LE",Text="Lecce"},
                new SelectListItem {Value="LC",Text="Lecco"},
                new SelectListItem {Value="LI",Text="Livorno"},
                new SelectListItem {Value="LO",Text="Lodi"},
                new SelectListItem {Value="LU",Text="Lucca"},
                new SelectListItem {Value="MC",Text="Macerata"},
                new SelectListItem {Value="MN",Text="Mantova"},
                new SelectListItem {Value="MS",Text="Massa-Carrara"},
                new SelectListItem {Value="MT",Text="Matera"},
                new SelectListItem {Value="VS",Text="Medio Campidano"},
                new SelectListItem {Value="ME",Text="Messina"},
                new SelectListItem {Value="MI",Text="Milano"},
                new SelectListItem {Value="MO",Text="Modena"},
                new SelectListItem {Value="MB",Text="Monza e Brianza"},
                new SelectListItem {Value="NA",Text="Napoli"},
                new SelectListItem {Value="NO",Text="Novara"},
                new SelectListItem {Value="NU",Text="Nuoro"},
                new SelectListItem {Value="OG",Text="Ogliastra"},
                new SelectListItem {Value="OT",Text="Olbia-Tempio"},
                new SelectListItem {Value="OR",Text="Oristano"},
                new SelectListItem {Value="PD",Text="Padova"},
                new SelectListItem {Value="PA",Text="Palermo"},
                new SelectListItem {Value="PR",Text="Parma"},
                new SelectListItem {Value="PV",Text="Pavia"},
                new SelectListItem {Value="PG",Text="Perugia"},
                new SelectListItem {Value="PU",Text="Pesaro e Urbino"},
                new SelectListItem {Value="PE",Text="Pescara"},
                new SelectListItem {Value="PC",Text="Piacenza"},
                new SelectListItem {Value="PI",Text="Pisa"},
                new SelectListItem {Value="PT",Text="Pistoia"},
                new SelectListItem {Value="PN",Text="Pordenone"},
                new SelectListItem {Value="PZ",Text="Potenza"},
                new SelectListItem {Value="PO",Text="Prato"},
                new SelectListItem {Value="RG",Text="Ragusa"},
                new SelectListItem {Value="RA",Text="Ravenna"},
                new SelectListItem {Value="RC",Text="Reggio di Calabria"},
                new SelectListItem {Value="RE",Text="Reggio nell'Emilia"},
                new SelectListItem {Value="RI",Text="Rieti"},
                new SelectListItem {Value="RN",Text="Rimini"},
                new SelectListItem {Value="RM",Text="Roma"},
                new SelectListItem {Value="RO",Text="Rovigo"},
                new SelectListItem {Value="SA",Text="Salerno"},
                new SelectListItem {Value="SS",Text="Sassari"},
                new SelectListItem {Value="SV",Text="Savona"},
                new SelectListItem {Value="SI",Text="Siena"},
                new SelectListItem {Value="SR",Text="Siracusa"},
                new SelectListItem {Value="SO",Text="Sondrio"},
                new SelectListItem {Value="TA",Text="Taranto"},
                new SelectListItem {Value="TE",Text="Teramo"},
                new SelectListItem {Value="TR",Text="Terni"},
                new SelectListItem {Value="TO",Text="Torino"},
                new SelectListItem {Value="TP",Text="Trapani"},
                new SelectListItem {Value="TN",Text="Trento"},
                new SelectListItem {Value="TV",Text="Treviso"},
                new SelectListItem {Value="TS",Text="Trieste"},
                new SelectListItem {Value="UD",Text="Udine"},
                new SelectListItem {Value="AO",Text="Valle d'Aosta/Vallée d'Aoste"},
                new SelectListItem {Value="VA",Text="Varese"},
                new SelectListItem {Value="VE",Text="Venezia"},
                new SelectListItem {Value="VB",Text="Verbano-Cusio-Ossola"},
                new SelectListItem {Value="VC",Text="Vercelli"},
                new SelectListItem {Value="VR",Text="Verona"},
                new SelectListItem {Value="VV",Text="Vibo Valentia"},
                new SelectListItem {Value="VI",Text="Vicenza"},
                new SelectListItem {Value="VT",Text="Viterbo"},
                new SelectListItem {Value="SM",Text="San Marino"}
                };
            }
        }

    }
    public class AnagraficaMetadata
    {


        public int idPaziente { get; set; }

        [Display(Name = "probando/a-famiglia riferimento")]
        [Required(ErrorMessage = "dato obbligatorio")]
        public Int32 famiglia { get; set; }

        [Display(Name = "parentela")]
        [Required(ErrorMessage = "parentela obbligatorio")]
        public Int32 parentela { get; set; }

        [Display(Name = "nome")]
        [Required(ErrorMessage = "Nome obbligatorio")]
        public string nome { get; set; }

        [Display(Name = "cognome")]
        [Required(ErrorMessage = "Cognome obbligatorio")]
        public string cognome { get; set; }

        [Display(Name = "data di nascita")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "data nascita obbligatoria")]
		[UIHint("SoloDate")]
        public DateTime datanascita { get; set; }

        [Display(Name = "comune di nascita")]
        [Required(ErrorMessage = "Comune nascita obbligatorio")]
        public string comuneNascita { get; set; }

        [Display(Name = "indirizzo")]
        [Required(ErrorMessage = "Indirizzo obbligatorio")]
        public string indirizzo { get; set; }

        [Display(Name = "provincia")]
        [Required(ErrorMessage = "Provincia obbligatoria")]
        public string provincia { get; set; }

        [Display(Name = "comune di residenza")]
        [Required(ErrorMessage = "Comune obbligatorio")]
        public string comune { get; set; }

        [Display(Name = "località")]
        public string localita { get; set; }

        [Display(Name = "cap")]
        [Required(ErrorMessage = "CAP obbligatorio")]
        [RegularExpression("\\d{5}", ErrorMessage = "Il CAP non è del formato corretto!")]
        public string cap { get; set; }


        [Display(Name = "codice fiscale")]
        [Required(ErrorMessage = "codice fiscale obbligatorio")]
        [Remote("cfUnivoco", "Reclutamento", ErrorMessage = "codice fiscale dupplicato")]
        [RegularExpression("^[A-Za-z]{6}[0-9LMNPQRSTUV]{2}[A-Za-z]{1}[0-9LMNPQRSTUV]{2}[A-Za-z]{1}[0-9LMNPQRSTUV]{3}[A-Za-z]{1}$", ErrorMessage = "Il codice fiscale non è del formato corretto!")]
        public global::System.String cfiscale { get; set; }

        [Display(Name = "stato civile")]
        public Int32 statocivile { get; set; }

        [Display(Name = "istruzione")]
        public Int32 istruzione { get; set; }

        [Display(Name = "professione")]
        public Int32 professione { get; set; }

        [Display(Name = "telefono casa")]
        public string telefonoFisso { get; set; }

        [Display(Name = "telefono lavoro")]
        public string telefonoLavoro { get; set; }

        [Display(Name = "cellulare")]
        [Required(ErrorMessage = "numero cellulare obbligatorio")]
        public string telefonoCellulare { get; set; }

        [Display(Name = "email")]
        public string email { get; set; }


        [Display(Name = "nome")]
        [Required(ErrorMessage = "nome obbligatorio")]
        public string medicoNome { get; set; }

        [Display(Name = "cognome")]
        [Required(ErrorMessage = "cognome obbligatorio")]
        public string medicoCognome { get; set; }

        [Display(Name = "indirizzo")]
        public string medicoIndirizzo { get; set; }

        [Display(Name = "citta")]
        public string medicoCitta { get; set; }

        [Display(Name = "telefono studio")]
        public string medicoTelefonoStudio { get; set; }

        [Display(Name = "telefono cellulare")]
        public string medicoTelefonoCellulare { get; set; }


        [Display(Name = "nome")]
        [Required(ErrorMessage = "nome obbligatorio")]
        public string riferimentoNome { get; set; }
        [Display(Name = "cognome")]
        [Required(ErrorMessage = "cognome obbligatorio")]
        public string riferimentoCognome { get; set; }
        [Display(Name = "telefono")]
        public string riferimentoTelefono { get; set; }


        [Display(Name = "consenso privacy")]
        public bool consensoPrivacy { get; set; }

        [Display(Name = "consenso informato")]
        public bool consensoInformato { get; set; }


        [Display(Name = "consenso partecipazione studio genetica")]
        public bool studioGeneticaPartecipazione { get; set; }

        [Display(Name = "autorizzo utilizzo campioni biologici per studio genetica")]
        public bool studioGeneticaUtilizzo { get; set; }

        [Display(Name = "consenso conservazioe campioni biologici per altri studi")]
        public bool altriStudiConservazione { get; set; }

        [Display(Name = "autorizzo contatti per studio genetica")]
        public bool studioGeneticaContatti { get; set; }

        [Display(Name = "data firma")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        public DateTime dataConsensoInformato { get; set; }

        public virtual Comuni Comuni { get; set; }
        public virtual LUIParentela LUIParentela { get; set; }
        public virtual LUIstruzione LUIstruzione { get; set; }
        public virtual LUProfessione LUProfessione { get; set; }
        public virtual LUStatoCivile LUStatoCivile { get; set; }
        public virtual ICollection<KitFlaconiAssegnazione> KitFlaconiAssegnazione { get; set; }
        public virtual ICollection<StatiRegistro> StatiRegistro { get; set; }
        public virtual ICollection<AssegnazioniRegistro> AssegnazioniRegistro { get; set; }

    }


}