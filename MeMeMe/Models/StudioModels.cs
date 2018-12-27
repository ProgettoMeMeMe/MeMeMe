using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{

    public class InserimentiList
    {
        public Int32 idPaziente { get; set; }
        public string idMeMeMe { get; set; }
        public Int32 randomizzazioneDieta { get; set; }
        public string paziente { get; set; }
        public string cfiscale { get; set; }
        public Int32 flaconiRicevuti { get; set; }
        public string statoFase { get; set; }
        public string statoPaziente { get; set; }
        public string descrizioneForm { get; set; }
        public string motivazione { get; set; }
        public Int32 SAE { get; set; }
        public Int32 AE { get; set; }
        public Int32 fromTevere { get; set; }
    }

    public class flaconiList
    {
        public Int32 idPaziente { get; set; }
        public Int32 idAssegnazione { get; set; }
        public string kit { get; set; }
        public string idMeMeMe { get; set; }
        public string paziente { get; set; }
        public System.DateTime dataAssegnazione { get; set; }
        public string utente { get; set; }
        public string faseAssegnazione { get; set; }
        public string dosaggio { get; set; }
    }


    //form STILE DI VITA
    [MetadataType(typeof(StileDiVitaMetadata))]
    public partial class StileDiVita
    {
    }
    public class StileDiVitaMetadata
    {
        public int idStatoRegistro { get; set; }

        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }

        [Display(Name = "data scheda")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime data { get; set; }

        [Display(Name = "preoccupazione per la salute")]
        public bool mPreoccupazione { get; set; }
        [Display(Name = "aiutare la ricerca")]
        public bool mRicerca { get; set; }
        [Display(Name = "adottare uno stile di vita più sano")]
        public bool mStile { get; set; }
        [Display(Name = "altro")]
        public bool mAltro { get; set; }
        public string motivazioneAltro { get; set; }
        [Display(Name = "Lei fuma o ha fumato abitualmente sigarette?")]
        public Nullable<int> fumo { get; set; }
        [Display(Name = "età")]
        public Nullable<int> fumoFine { get; set; }
        [Display(Name = "Se fuma o ha fumato, a che età ha iniziato a fumare regolarmente")]
        public Nullable<int> fumoInizio { get; set; }
        [Display(Name = "Quante sigarette fuma o fumava in media al giorno? ")]
        public Nullable<int> fumoSigaretteMedia { get; set; }
        [Display(Name = "Nel periodo in cui ha fumato di più, quante sigarette fumava al giorno?")]
        public Nullable<int> fumoSigaretteMax { get; set; }
        [Display(Name = "Lei fuma o ha fumato abitualmente sigari")]
        public Nullable<byte> fumoSigari { get; set; }
        [Display(Name = "Lei fuma o ha fumato abitualmente pipa")]
        public Nullable<byte> fumoPipa { get; set; }

        [Display(Name = "Le è stata diagnosticata ipertensione?")]
        [Required(ErrorMessage = "diagnosi ipertensione obbligatoria")]
        public byte ipertensione { get; set; }
        [Display(Name = "La sua ipertensione è trattata farmacologicamente?")]
        public Nullable<byte> ipertensioneTrattamento { get; set; }
        [Display(Name = "1 Patologie apparato cardiocircolatorio?")]
        public byte patologiaApparatoCardiocircolatorio { get; set; }
        [Display(Name = "Angina")]
        public bool pacAngina { get; set; }
        [Display(Name = "Cardiomiopatia")]
        public bool pacCardiomiopatia { get; set; }
        [Display(Name = "Stenosi")]
        public bool pacStenosi { get; set; }
        [Display(Name = "Aritmia")]
        public bool pacAritmia { get; set; }
        [Display(Name = "TIA")]
        public bool pacTIA { get; set; }
        [Display(Name = "Altre")]
        public bool pacAltre { get; set; }
        [Display(Name = "altre")]
        public string pacAltreTxt { get; set; }
        [Display(Name = "2 Patologie apparato respiratorio?")]

        public byte patologiaApparatoRespiratorio { get; set; }
        [Display(Name = "Asma")]
        public bool parAsma { get; set; }
        [Display(Name = "Enfisema")]
        public bool parEnfisema { get; set; }
        [Display(Name = "Altre")]
        public bool parAltre { get; set; }
        [Display(Name = "altre")]
        public string parAltreTxt { get; set; }

        [Display(Name = "3 Patologie apparato digerente?")]
        public byte patologiaApparatoDigerente { get; set; }
        [Display(Name = "Gastrite")]
        public bool padGastrite { get; set; }
        [Display(Name = "Ulcera")]
        public bool padUlcera { get; set; }
        [Display(Name = "Polipi")]
        public bool padPolipi { get; set; }
        [Display(Name = "Diverticolite")]
        public bool padDiverticolite { get; set; }
        [Display(Name = "Ernia")]
        public bool padErnia { get; set; }
        [Display(Name = "Altre")]
        public bool padAltre { get; set; }
        [Display(Name = "altre")]
        public string padAltreTxt { get; set; }

        [Display(Name = "4 Patologie apparato urogenitale?")]
        public byte patologiaApparatoUrogenitale { get; set; }
        [Display(Name = "Nefrite")]
        public bool pauNefrite { get; set; }
        [Display(Name = "Calcolosi")]
        public bool pauCalcolosi { get; set; }
        [Display(Name = "Insufficienza renale")]
        public bool pauInsufficienza { get; set; }
        [Display(Name = "Prostata")]
        public bool pauProstata { get; set; }
        [Display(Name = "Ovaio")]
        public bool pauOvaio { get; set; }
        [Display(Name = "Utero")]
        public bool pauUtero { get; set; }
        [Display(Name = "Altre")]
        public bool pauAltre { get; set; }
        [Display(Name = "altre")]
        public string pauAltreTxt { get; set; }

        [Display(Name = "5 Patologie apparato osteoarticolare?")]
        public byte patologiaApparatoOsteoarticolare { get; set; }
        [Display(Name = "Artrite")]
        public bool paoArtrite { get; set; }
        [Display(Name = "Artrosi")]
        public bool paoArtrosi { get; set; }
        [Display(Name = "Ernia")]
        public bool paoErnia { get; set; }
        [Display(Name = "Gotta")]
        public bool paoGotta { get; set; }
        [Display(Name = "Osteoporosi")]
        public bool paoOsteoporosi { get; set; }
        [Display(Name = "Altre")]
        public bool paoAltre { get; set; }
        [Display(Name = "altre")]
        public string paoAltreTxt { get; set; }

        [Display(Name = "6 Patologie sistema nervoso?")]
        public byte patologiaSistemaNervoso { get; set; }
        [Display(Name = "Parkinson")]
        public bool patParkinson { get; set; }
        [Display(Name = "Alzheimer")]
        public bool patAlzheimer { get; set; }
        [Display(Name = "Emicrania")]
        public bool patEmicrania { get; set; }
        [Display(Name = "Altre")]
        public bool patAltre { get; set; }
        [Display(Name = "altre")]
        public string patAltreTxt { get; set; }

        [Display(Name = "7 Patologie sistema endocrino?")]
        public byte patologiaEndocrino { get; set; }
        [Display(Name = "Tiroide")]
        public bool peTiroide { get; set; }
        [Display(Name = "Ipofisi")]
        public bool peIpofisi { get; set; }
        [Display(Name = "Surreene")]
        public bool peSurrene { get; set; }
        [Display(Name = "Altre")]
        public bool peAltre { get; set; }
        [Display(Name = "altre")]
        public string peAltreTxt { get; set; }


        [Display(Name = "8 Patologie apparato metabolismo?")]
        public byte patologiaMetabolismo { get; set; }
        [Display(Name = "Colesterolo")]
        public bool pmColesterolo { get; set; }
        [Display(Name = "Trigliceridi")]
        public bool pmTrigliceridi { get; set; }
        [Display(Name = "Uricemia")]
        public bool pmUricemia { get; set; }
        [Display(Name = "Glicemia")]
        public bool pmGlicemia { get; set; }
        [Display(Name = "Steatosi")]
        public bool pmSteatosi { get; set; }
        [Display(Name = "Altre")]
        public bool pmAltre { get; set; }
        [Display(Name = "altre")]
        public string pmAltreTxt { get; set; }

        [Display(Name = "9 Patologie occhio?")]
        public byte patologiaOcchio { get; set; }
        [Display(Name = "Cataratta")]
        public bool poCataratta { get; set; }
        [Display(Name = "Glaucoma")]
        public bool poGlaucoma { get; set; }
        [Display(Name = "Retinopatia")]
        public bool poRetinopatia { get; set; }
        [Display(Name = "Maculopatia")]
        public bool poMaculopatia { get; set; }
        [Display(Name = "Altre")]
        public bool poAltre { get; set; }
        [Display(Name = "altre")]
        public string poAltreTxt { get; set; }

        [Display(Name = "10 Altre patologie?")]
        public byte altrePatologie { get; set; }
        [Display(Name = "Psoriasi")]
        public bool apPsoriasi { get; set; }
        [Display(Name = "Lupus")]
        public bool apLupus { get; set; }
        [Display(Name = "Sclerodermia")]
        public bool apSclerodermia { get; set; }
        [Display(Name = "Artrite reumatoide")]
        public bool apArtriteReumatoide { get; set; }
        [Display(Name = "Altre")]
        public bool apAltre { get; set; }
        [Display(Name = "altre")]
        public string apAltreTxt { get; set; }

        [Display(Name = "Patologie note libere")]
        public string patologieNoteTxt { get; set; }

        [Display(Name = "A quale età ha avuto la prima mestruazione?")]
        public Nullable<int> mestruazioni { get; set; }
        [Display(Name = "Menopausa")]
        public Nullable<int> menopausa { get; set; }

        [Display(Name = "Se NON in menopausa, data dell’ultima mestruazione")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> mestruazioniDataUltima { get; set; }
        public bool mestruazioniDataUltimaNsNr { get; set; }

        [Display(Name = "A che età è entrata in menopausa?")]
        public Nullable<int> menopausaEta { get; set; }
        [Display(Name = "Le sue mestruazioni sono cessate")]
        public Nullable<int> mestruazioniCessazione { get; set; }
        [Display(Name = "Età")]
        public Nullable<int> mestruazioniCessazioneEta { get; set; }
        [Display(Name = "Tipo di intervento")]
        public string mestruazioniCessazioneTipoIntervento { get; set; }
        [Display(Name = "Motivazione")]
        public string mestruazioniCessazioneMotivazione { get; set; }
        [Display(Name = "Altro")]
        public string mestruazioniCessazioneAltro { get; set; }
        [Display(Name = "Motivazione")]
        public string mestruazioniCessazioneAltroMotivazione { get; set; }
        [Display(Name = "Ha mai fatto uso di ormoni estrogeni e/o progestinici in passato?")]
        public Nullable<int> estrogeni { get; set; }
        [Display(Name = "Terapia Ormonale sostitutiva")]
        public Nullable<int> terapiaOrmonale { get; set; }
        [Display(Name = "per quanto tempo (mesi)")]
        public Nullable<int> terapiaOrmonaleTempo { get; set; }
        [Display(Name = "Pillola contraccettiva")]
        public Nullable<int> pillolaContraccettiva { get; set; }
        [Display(Name = "per quanto tempo (mesi)")]
        public Nullable<int> pillolaContraccettivaTempo { get; set; }
        [Display(Name = "Altri Ormonali")]
        public Nullable<int> altriOrmonali { get; set; }
        [Display(Name = "per quanto tempo (mesi)")]
        public Nullable<int> altriOrmonaliTempo { get; set; }
        [Display(Name = "Ha mai avuto gravidanze?")]
        public Nullable<int> gravidanze { get; set; }
        [Display(Name = "Quante gravidanze ha avuto?")]
        public Nullable<int> gravidanzeNumero { get; set; }
        [Display(Name = "Quante sono giunte a termine?")]
        public Nullable<int> gravidanzeConcluse { get; set; }
        [Display(Name = "A che età ha avuto il primo figlio?")]
        public Nullable<int> gravidanzeEtaPrimofiglio { get; set; }
        [Display(Name = "Ha cercato di avere figli?")]
        public Nullable<int> gravidanzeTentativi { get; set; }
        [Display(Name = "Ha fatto cure ormonali per la sterilità?")]
        public Nullable<int> gravidanzeCureOrmonali { get; set; }
        [Display(Name = "Attualmente, soffre di stitichezza?")]
        public Nullable<int> stitichezza { get; set; }
        [Display(Name = "fa uso di lassativi o clisteri?")]
        public Nullable<int> stitichezzaLassativi { get; set; }
        [Display(Name = "Approssimativamente, quanto pesava all’età di 20 anni?")]
        public Nullable<int> peso20Anni { get; set; }
        [Display(Name = "Quale è il suo peso massimo raggiunto, escluse le gravidanze?")]
        public Nullable<int> pesoMax { get; set; }
        [Display(Name = "All’età delle prime mestruazioni, rispetto alla media delle sue coetanee era?")]
        public Nullable<int> pesoPrimeMestruazioni { get; set; }

        public virtual StatiRegistro StatiRegistro { get; set; }

    }

    //form DIARIO
    [MetadataType(typeof(DiarioDieta24Metadata))]
    public partial class DiarioDieta24
    {
    }
    public class DiarioDieta24Metadata
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data scheda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime data { get; set; }
        [Display(Name = "Ieri era")]
        public int ieri { get; set; }
        [Display(Name = "Merendine, brioche, dolci con zucchero")]
        public bool merendineNC { get; set; }
        public bool merendineCO { get; set; }
        public bool merendinePR { get; set; }
        public bool merendineCE { get; set; }
        public bool merendineFP { get; set; }
        [Display(Name = "Cioccolato, caramelle, creme dolci spalmabili")]
        public bool cioccolatoNC { get; set; }
        public bool cioccolatoCO { get; set; }
        public bool cioccolatoPR { get; set; }
        public bool cioccolatoCE { get; set; }
        public bool cioccolatoFP { get; set; }
        [Display(Name = "Bibite zuccherate, succhi di frutta zuccherati")]
        public bool bibiteNC { get; set; }
        public bool bibiteCO { get; set; }
        public bool bibitePR { get; set; }
        public bool bibiteCE { get; set; }
        public bool bibiteFP { get; set; }
        [Display(Name = "Bevande alcoliche")]
        public bool bevandeAlcolicheNC { get; set; }
        public bool bevandeAlcolicheCO { get; set; }
        public bool bevandeAlcolichePR { get; set; }
        public bool bevandeAlcolicheCE { get; set; }
        public bool bevandeAlcolicheFP { get; set; }
        [Display(Name = "Latte (vaccino o di capra)")]
        public bool latteNC { get; set; }
        public bool latteCO { get; set; }
        public bool lattePR { get; set; }
        public bool latteCE { get; set; }
        public bool latteFP { get; set; }
        [Display(Name = "Yogurt zuccherato")]
        public bool yogurtZuccheratoNC { get; set; }
        public bool yogurtZuccheratoCO { get; set; }
        public bool yogurtZuccheratoPR { get; set; }
        public bool yogurtZuccheratoCE { get; set; }
        public bool yogurtZuccheratoFP { get; set; }
        [Display(Name = "Yogurt bianco naturale")]
        public bool yogurtBiancoNC { get; set; }
        public bool yogurtBiancoCO { get; set; }
        public bool yogurtBiancoPR { get; set; }
        public bool yogurtBiancoCE { get; set; }
        public bool yogurtBiancoFP { get; set; }
        [Display(Name = "Frutta")]
        public bool fruttaNC { get; set; }
        public bool fruttaCO { get; set; }
        public bool fruttaPR { get; set; }
        public bool fruttaCE { get; set; }
        public bool fruttaFP { get; set; }
        [Display(Name = "Verdure crude")]
        public bool verdureCrudeNC { get; set; }
        public bool verdureCrudeCO { get; set; }
        public bool verdureCrudePR { get; set; }
        public bool verdureCrudeCE { get; set; }
        public bool verdureCrudeFP { get; set; }
        [Display(Name = "Patate")]
        public bool patateNC { get; set; }
        public bool patateCO { get; set; }
        public bool patatePR { get; set; }
        public bool patateCE { get; set; }
        public bool patateFP { get; set; }
        [Display(Name = "Verdure cotte")]
        public bool verdureCotteNC { get; set; }
        public bool verdureCotteCO { get; set; }
        public bool verdureCottePR { get; set; }
        public bool verdureCotteCE { get; set; }
        public bool verdureCotteFP { get; set; }
        [Display(Name = "Pane bianco")]
        public bool paneBiancoNC { get; set; }
        public bool paneBiancoCO { get; set; }
        public bool paneBiancoPR { get; set; }
        public bool paneBiancoCE { get; set; }
        public bool paneBiancoFP { get; set; }
        [Display(Name = "Pane nero")]
        public bool paneNeroNC { get; set; }
        public bool paneNeroCO { get; set; }
        public bool paneNeroPR { get; set; }
        public bool paneNeroCE { get; set; }
        public bool paneNeroFP { get; set; }
        [Display(Name = "Pizza")]
        public bool pizzaNC { get; set; }
        public bool pizzaCO { get; set; }
        public bool pizzaPR { get; set; }
        public bool pizzaCE { get; set; }
        public bool pizzaFP { get; set; }
        [Display(Name = "Grissini, crackers, fette biscottate")]
        public bool grissiniNC { get; set; }
        public bool grissiniCO { get; set; }
        public bool grissiniPR { get; set; }
        public bool grissiniCE { get; set; }
        public bool grissiniFP { get; set; }
        [Display(Name = "Pasta asciutta o pastina in brodo")]
        public bool pastaAsciuttaNC { get; set; }
        public bool pastaAsciuttaCO { get; set; }
        public bool pastaAsciuttaPR { get; set; }
        public bool pastaAsciuttaCE { get; set; }
        public bool pastaAsciuttaFP { get; set; }
        [Display(Name = "Pasta ripiena (tipo ravioli, lasagne ecc)")]
        public bool pastaRipienaNC { get; set; }
        public bool pastaRipienaCO { get; set; }
        public bool pastaRipienaPR { get; set; }
        public bool pastaRipienaCE { get; set; }
        public bool pastaRipienaFP { get; set; }
        [Display(Name = "Riso bianco")]
        public bool risoBiancoNC { get; set; }
        public bool risoBiancoCO { get; set; }
        public bool risoBiancoPR { get; set; }
        public bool risoBiancoCE { get; set; }
        public bool risoBiancoFP { get; set; }
        [Display(Name = "Riso integrale")]
        public bool risoIntegraleNC { get; set; }
        public bool risoIntegraleCO { get; set; }
        public bool risoIntegralePR { get; set; }
        public bool risoIntegraleCE { get; set; }
        public bool risoIntegraleFP { get; set; }
        [Display(Name = "Cereali in chicco (farro, orzo, miglio ecc)")]
        public bool cerealiChiccoNC { get; set; }
        public bool cerealiChiccoCO { get; set; }
        public bool cerealiChiccoPR { get; set; }
        public bool cerealiChiccoCE { get; set; }
        public bool cerealiChiccoFP { get; set; }
        [Display(Name = "Fiocchi di cereali, muesli, non zuccherati")]
        public bool fiocchiNonZuccheratiNC { get; set; }
        public bool fiocchiNonZuccheratiCO { get; set; }
        public bool fiocchiNonZuccheratiPR { get; set; }
        public bool fiocchiNonZuccheratiCE { get; set; }
        public bool fiocchiNonZuccheratiFP { get; set; }
        [Display(Name = "Fiocchi, muesli con zucchero o miele")]
        public bool fiocchiZuccheratiNC { get; set; }
        public bool fiocchiZuccheratiCO { get; set; }
        public bool fiocchiZuccheratiPR { get; set; }
        public bool fiocchiZuccheratiCE { get; set; }
        public bool fiocchiZuccheratiFP { get; set; }
        [Display(Name = "Legumi (fagioli,ceci,lenticchie,piselli…)")]
        public bool legumiNC { get; set; }
        public bool legumiCO { get; set; }
        public bool legumiPR { get; set; }
        public bool legumiCE { get; set; }
        public bool legumiFP { get; set; }
        [Display(Name = "Carni rosse (bovine, equine, suine, ovine- agnello)")]
        public bool carniRosseNC { get; set; }
        public bool carniRosseCO { get; set; }
        public bool carniRossePR { get; set; }
        public bool carniRosseCE { get; set; }
        public bool carniRosseFP { get; set; }
        [Display(Name = "Salumi, wurstel, carni conservate")]
        public bool salumiNC { get; set; }
        public bool salumiCO { get; set; }
        public bool salumiPR { get; set; }
        public bool salumiCE { get; set; }
        public bool salumiFP { get; set; }
        [Display(Name = "Carni bianche (pollo, tacchino, coniglio)")]
        public bool carniBiancheNC { get; set; }
        public bool carniBiancheCO { get; set; }
        public bool carniBianchePR { get; set; }
        public bool carniBiancheCE { get; set; }
        public bool carniBiancheFP { get; set; }
        [Display(Name = "Pesce")]
        public bool pesceNC { get; set; }
        public bool pesceCO { get; set; }
        public bool pescePR { get; set; }
        public bool pesceCE { get; set; }
        public bool pesceFP { get; set; }
        [Display(Name = "Formaggi")]
        public bool formaggiNC { get; set; }
        public bool formaggiCO { get; set; }
        public bool formaggiPR { get; set; }
        public bool formaggiCE { get; set; }
        public bool formaggiFP { get; set; }
        [Display(Name = "Pietanze tradizionali ricche in formaggi o carni")]
        public bool pietanzeNC { get; set; }
        public bool pietanzeCO { get; set; }
        public bool pietanzePR { get; set; }
        public bool pietanzeCE { get; set; }
        public bool pietanzeFP { get; set; }
        [Display(Name = "Noci, mandorle, nocciole e affini, non salate")]
        public bool nociNC { get; set; }
        public bool nociCO { get; set; }
        public bool nociPR { get; set; }
        public bool nociCE { get; set; }
        public bool nociFP { get; set; }
        [Display(Name = "Snack salati (tipo patatine, pop corn, tuc, ecc)")]
        public bool snackNC { get; set; }
        public bool snackCO { get; set; }
        public bool snackPR { get; set; }
        public bool snackCE { get; set; }
        public bool snackFP { get; set; }
        [Display(Name = "Uova")]
        public bool uovaNC { get; set; }
        public bool uovaCO { get; set; }
        public bool uovaPR { get; set; }
        public bool uovaCE { get; set; }
        public bool uovaFP { get; set; }
        [Display(Name = "Zucchero aggiunto ( a caffè, tè, yogurt, frutta, spremute)")]
        public bool zuccheroNC { get; set; }
        public bool zuccheroCO { get; set; }
        public bool zuccheroPR { get; set; }
        public bool zuccheroCE { get; set; }
        public bool zuccheroFP { get; set; }
        [Display(Name = "Sale aggiunto al momento del pasto")]
        public bool saleNC { get; set; }
        public bool saleCO { get; set; }
        public bool salePR { get; set; }
        public bool saleCE { get; set; }
        public bool saleFP { get; set; }
        [Display(Name = "Olio extravergine di oliva")]
        public bool olioExtravergineNC { get; set; }
        public bool olioExtravergineCO { get; set; }
        public bool olioExtraverginePR { get; set; }
        public bool olioExtravergineCE { get; set; }
        public bool olioExtravergineFP { get; set; }
        [Display(Name = "Burro")]
        public bool burroNC { get; set; }
        public bool burroCO { get; set; }
        public bool burroPR { get; set; }
        public bool burroCE { get; set; }
        public bool burroFP { get; set; }
        [Display(Name = "Margarina")]
        public bool margarinaNC { get; set; }
        public bool margarinaCO { get; set; }
        public bool margarinaPR { get; set; }
        public bool margarinaCE { get; set; }
        public bool margarinaFP { get; set; }
        public string altro1 { get; set; }
        public bool altro1NC { get; set; }
        public bool altro1CO { get; set; }
        public bool altro1PR { get; set; }
        public bool altro1CE { get; set; }
        public bool altro1FP { get; set; }
        public string altro2 { get; set; }
        public bool altro2NC { get; set; }
        public bool altro2CO { get; set; }
        public bool altro2PR { get; set; }
        public bool altro2CE { get; set; }
        public bool altro2FP { get; set; }
        public string altro3 { get; set; }
        public bool altro3NC { get; set; }
        public bool altro3CO { get; set; }
        public bool altro3PR { get; set; }
        public bool altro3CE { get; set; }
        public bool altro3FP { get; set; }
        public string altro4 { get; set; }
        public bool altro4NC { get; set; }
        public bool altro4CO { get; set; }
        public bool altro4PR { get; set; }
        public bool altro4CE { get; set; }
        public bool altro4FP { get; set; }
        public string altro5 { get; set; }
        public bool altro5NC { get; set; }
        public bool altro5CO { get; set; }
        public bool altro5PR { get; set; }
        public bool altro5CE { get; set; }
        public bool altro5FP { get; set; }
    }

    //form ATTIVITA FISICA
    [MetadataType(typeof(AttivitaFisicaMetadata))]
    public partial class AttivitaFisica
    {
        public IEnumerable<SelectListItem> ListaQualitàSonno
        {
            get
            {
                return new[] 
                { 
                    new SelectListItem {Value="1",Text="1 -	Molto buona"},
                    new SelectListItem {Value="2",Text="2 -	Abbastanza buona"},
                    new SelectListItem {Value="3",Text="3 -	Abbastanza cattiva"},
                    new SelectListItem {Value="4",Text="4 -	Molto cattiva"},
                };
            }
        }
    }
    public class AttivitaFisicaMetadata
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data scheda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        [DataType(DataType.Date)]
        public System.DateTime data { get; set; }

        [Display(Name = "Durante gli ultimi 7 giorni ha praticato attività vigorose?")]
        [Required(ErrorMessage = "inserire attività vigorose")]
        public short attivitaVigorose { get; set; }

        [Display(Name = "durata gg")]
        [Range(1, 7, ErrorMessage = "inserire giorni in settimana 1-7")]
        public Nullable<short> attivitaVigoroseSettimanaDurata { get; set; }
        
        [Display(Name = "ns/nr")]
        public bool attivitaVigoroseSettimanaNrNr { get; set; }
        
        [Display(Name = "tipo attività")]
        public Nullable<short> attivitaVigoroseTipo { get; set; }
        [Display(Name = "durata giorno hh:mm")]
        [RegularExpression(@"^([0-1]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "formato hh:mm")]
        public string attivitaVigoroseGiornoDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool attivitaVigoroseGiornoNrNr { get; set; }
        
        [Display(Name = "Durante gli ultimi 7 giorni, su quanti giorni ha camminato per almeno 10 minuti consecutivi?")]
        [Required(ErrorMessage = "inserire camminata")]
        public short camminata { get; set; }
        
        [Display(Name = "durata giorni")]
        [Range(1, 7, ErrorMessage = "inserire giorni in settimana 1-7")]
        public Nullable<short> camminataSettimanaDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool camminataSettimanaDurataNsNr { get; set; }
        
        [Display(Name = "tipo camminata")]
        public Nullable<short> camminataTipo { get; set; }
        [Display(Name = "durata giorno hh:mm")]
        [RegularExpression(@"^([0-1]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "formato hh:mm")]
        public string camminataGiornoDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool camminataGiornoDurataNsNr { get; set; }
        
        [Display(Name = "Durante gli ultimi 7 giorni, ha praticato esercizio moderatamente attivo per almeno 10 minuti consecutivi?")]
        [Required(ErrorMessage = "inserire esercizio moderatamente attivo")]
        public short attivitaModerata { get; set; }
        [Display(Name = "durata giorni")]
        [Range(1, 7, ErrorMessage = "inserire giorni in settimana 1-7")]
        public Nullable<short> attivitaModerataSettimanaDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool attivitaModerataSettimanaDurataNsNr { get; set; }
        
        [Display(Name = "tipo attività moderata")]
        public Nullable<short> attivitaModerataTipo { get; set; }
        [Display(Name = "durata giorno hh:mm")]
        [RegularExpression(@"^([0-1]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "formato hh:mm")]
        public string attivitaModerataGiornoDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool attivitaModerataGiornoDurataNsNr { get; set; }
        
        [Display(Name = "Durante gli ultimi 7 giorni, quanto tempo ha passato in maniera sedentaria?")]
        [Required(ErrorMessage = "inserire attività sedentaria")]
        public Nullable<short> attivitaSedentariaSettimanaDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool attivitaSedentariaSettimanaDurataNsNr { get; set; }
        
        [Display(Name = "tipologia sedentaria")]
        public Nullable<short> attivitaSedentariaTipo { get; set; }
        [Display(Name = "durata mercoledì hh:mm")]
        [RegularExpression(@"^([0-1]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "formato hh:mm")]
        public string attivitaSedentariaMercolediDurata { get; set; }
        [Display(Name = "ns/nr")]
        public bool attivitaSedentariaMercolediDurataNsNr { get; set; }
        
        [Display(Name = "Nell’ultimo mese, di solito, a che ora è andata/o a letto la sera?")]
        [RegularExpression(@"^([0-1]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "formato hh:mm")]
        public string sonnoLetto { get; set; }
        [Display(Name = "Nell’ultimo mese, di solito, quanto tempo (in minuti) ha impiegato ad addormentarsi di notte?")]
        public Nullable<short> sonnoAddormentamento { get; set; }
        [Display(Name = "Nell’ultimo mese, di solito, a che ora si è alzata/o al mattino?")]
        [RegularExpression(@"^([0-1]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "formato hh:mm")]
        public string alzata { get; set; }
        [Display(Name = "Nell’ultimo mese, quante ore ha dormito effettivamente per notte?")]
        [Range(0, 24, ErrorMessage = "inserire ore 0-24")]
        public Nullable<short> durataSonno { get; set; }
        [Display(Name = "Nell’ultimo mese, come valuta complessivamente la qualità del suo sonno? ")]
        [Required(ErrorMessage = "inserire qualità sonno")]
        public Nullable<short> qualitaSonno { get; set; }
        
        public virtual StatiRegistro StatiRegistro { get; set; }

    }


    //form ANTROPOMETRIA
    [MetadataType(typeof(AntropometriaMetadata))]
    public partial class Antropometria
    {
    }
    public class AntropometriaMetadata
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data scheda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime data { get; set; }
        [Display(Name = "Altezza (cm)")]
        public decimal altezza { get; set; }
        [Display(Name = "Peso (kg)")]
        public decimal peso { get; set; }
        [Display(Name = "Circonferenza vita (cm)")]
        public decimal circonferenzaVita { get; set; }
        [Display(Name = "Circonferenza fianchi (cm)")]
        public decimal circonferenzaFianchi { get; set; }
        [Display(Name = "Pressione arteriosa max")]
        public int pressioneMax { get; set; }
        [Display(Name = "Pressione arteriosa min")]
        public int pressioneMin { get; set; }
        [Display(Name = "Pulsazioni al minuto")]
        public int pulsazioni { get; set; }
        [Display(Name = "Terapia ipertensione")]
        public bool terapiaIpertensione { get; set; }
        [Display(Name = "Terapia ipercolesterolemia")]
        public bool terapiaIpercolesterolemia { get; set; }
        [Display(Name = "Terapia ipertrigliceridemia")]
        public bool terapiaIpertrigliceridemia { get; set; }
        [Display(Name = "Cardioaspirina")]
        public bool cardioaspirina { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }

        public virtual StatiRegistro StatiRegistro { get; set; }
    }

    //form TRATTAMENTI 
    [MetadataType(typeof(TrattamentiMetadata))]
    public partial class Trattamenti
    {
    }
    public class TrattamentiMetadata
    {
        public TrattamentiMetadata()
        {
            this.TrattamentiDettaglio = new HashSet<TrattamentiDettaglio>();
        }
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data scheda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime data { get; set; }
    
        public virtual StatiRegistro StatiRegistro { get; set; }
        public virtual ICollection<TrattamentiDettaglio> TrattamentiDettaglio { get; set; }
    }

    [MetadataType(typeof(TrattamentiDettaglioMetadata))]
    public partial class TrattamentiDettaglio
    {
    }
    public class TrattamentiDettaglioMetadata
    {
        public int idTrattamentoDettaglio { get; set; }
        public int idStatoRegistro { get; set; }
        [Display(Name = "tipologia")]
        [Required(ErrorMessage = "tipo obbligaorio")]
        public int tipoTrattamento { get; set; }
        [Display(Name = "altro")]
        public string tipoTrattamentoAltro { get; set; }
        [Display(Name = "nome")]
        [Required(ErrorMessage = "nome obbligatorio")]
        public string trattamento { get; set; }
        [Display(Name = "dose")]
        [Required(ErrorMessage = "dose obbligatoria")]
        public string doseGiornaliera { get; set; }
        [Display(Name = "motivazione")]
        [Required(ErrorMessage = "motivazione obbligatoria")]
        public string motivo { get; set; }
        [Display(Name = "durata")]
        [Required(ErrorMessage = "durata obbligatoria")]
        public string durata { get; set; }

        public virtual LUTipoTrattamento LUTipoTrattamento { get; set; }
        public virtual Trattamenti Trattamenti { get; set; }
    }


    public class ListaTrattamenti
    {
        public int idTrattamentoDettaglio { get; set; }
        public int idStatoRegistro { get; set; }
        public string descrizioneTipoTrattamento { get; set; }
        public string trattamento { get; set; }
        public string doseGiornaliera { get; set; }
        public string motivo { get; set; }
        public string durata { get; set; }
    }


    //Form PRELIEVO
    [MetadataType(typeof(PrelievoMetadata))]
    public partial class Prelievo
    {
    }
    public class PrelievoMetadata
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data scheda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime data { get; set; }
        [Display(Name = "Leucociti")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> leucociti { get; set; }
        [Display(Name = "Eritrociti")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> eritrociti { get; set; }
        [Display(Name = "Emoglobina")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public Nullable<decimal> emoglobina { get; set; }
        [Display(Name = "Ematocrito")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public Nullable<decimal> ematocrito { get; set; }
        [Display(Name = "MCV - volume cellule medio")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public Nullable<decimal> MCV { get; set; }
        [Display(Name = "MCH - contenuto medio di emoglobina")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public Nullable<decimal> MCH { get; set; }
        [Display(Name = "MCHC - conc. media di emoglobina")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public Nullable<decimal> MCHC { get; set; }
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        [Display(Name = "RDW")]
        public Nullable<decimal> RDW { get; set; }
        [Display(Name = "Piastrine")]
        public Nullable<int> piastrine { get; set; }
        [Display(Name = "MPV - volume piastrinico medio")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public Nullable<decimal> MPV { get; set; }
        [Display(Name = "Neutrofili %")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        //[Range(typeof(decimal), "0,1", "100", ErrorMessage = "% 0,1-100")]
        public Nullable<decimal> neutrofili_pc { get; set; }
        [Display(Name = "Neutrofili numero")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> neutrofili_nm { get; set; }
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        //[Range(typeof(decimal), "0,1", "100", ErrorMessage = "% 0,1-100")]
        [Display(Name = "Linfociti %")]
        public Nullable<decimal> linfociti_pc { get; set; }
        [Display(Name = "Linfociti numero")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> linfociti_nm { get; set; }
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        //[Range(typeof(decimal), "0,1", "100", ErrorMessage = "% 0,1-100")]
        [Display(Name = "Monociti %")]
        public Nullable<decimal> monociti_pc { get; set; }
        [Display(Name = "Monociti numero")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> monociti_nm { get; set; }
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        //[Range(typeof(decimal), "0,1", "100", ErrorMessage = "% 0,1-100")]
        [Display(Name = "Eosinofili %")]
        public Nullable<decimal> eosinofili_pc { get; set; }
        [Display(Name = "Eosinofili numero")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> eosinofili_nm { get; set; }
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        //[Range(typeof(decimal), "0,1", "100", ErrorMessage = "% 0,1-100")]
        [Display(Name = "Basofili %")]
        public Nullable<decimal> basofili_pc { get; set; }
        [Display(Name = "Basofili numero")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> basofili_nm { get; set; }
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        //[Range(typeof(decimal), "0,1", "100", ErrorMessage = "% 0,1-100")]
        [Display(Name = "Grandi Cellule %")]
        public Nullable<decimal> grandicellule_pc { get; set; }
        [Display(Name = "Grandi Cellule numero")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<decimal> grandicellule_nm { get; set; }
        [Display(Name = "Glicemia")]
        public int glicemia { get; set; }
        [Display(Name = "Creatininemia")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public decimal creatininemia { get; set; }
        [Display(Name = "Transaminasi GOT/AST")]
        public Nullable<int> transaminasiGOT_AST { get; set; }
        [Display(Name = "Transaminasi GPL/ALT")]
        public Nullable<int> transaminasiGPL_ALT { get; set; }
        [Display(Name = "Gamma Glutammil Transpeptidasi")]
        public Nullable<int> gammaGlutammil { get; set; }
        [Display(Name = "Colesterolemia")]
        public int colesterolemia { get; set; }
        [Display(Name = "Colesterolo HDL")]
        public int HDL { get; set; }
        [Display(Name = "Colesterolo LDL")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,2})?$", ErrorMessage = "Sono ammessi fino a 2 decimali")]
        public Nullable<int> LDL { get; set; }
        [Display(Name = "Trigliceridi")]
        public int trigliceridi { get; set; }
        [Display(Name = "EGFR")]
        public Nullable<decimal> EGFR { get; set; }
        [Display(Name = "pH")]
        [RegularExpression(@"^\d{0,5}(\,\d{0,1})?$", ErrorMessage = "E' ammesso 1 solo decimale")]
        public string urinePh { get; set; }
        [Display(Name = "Leucociti")]
        public string urineLeucociti { get; set; }
        [Display(Name = "Nitriti")]
        public string urineNitriti { get; set; }
        [Display(Name = "Albumina")]
        public string urineAlbumina { get; set; }
        [Display(Name = "Glucosio")]
        public string urineGlucosio { get; set; }
        [Display(Name = "Chetoni")]
        public string urineChetoni { get; set; }
        [Display(Name = "Urobilinologico")]
        public string urineUrobinologico { get; set; }
        [Display(Name = "Bilirubina")]
        public string urineBilirubina { get; set; }
        [Display(Name = "Emoglobina")]
        public string urineEmoglobina { get; set; }
        [Display(Name = "Peso Specifico")]
        public string urinePesoSpecifico { get; set; }
        [Display(Name = "Aspetto")]
        public string urineAspetto { get; set; }
        [Display(Name = "Colore")]
        public string urineColore { get; set; }
        [Display(Name = "EsameSedimento")]
        public string urineEsameSedimento { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }

        public virtual StatiRegistro StatiRegistro { get; set; }
    }


    //Form MEDAS
    [MetadataType(typeof(MEDASMetadata))]
    public partial class MEDAS
    {
    }
    public class MEDASMetadata
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data scheda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime data { get; set; }

        [Display(Name = "d01 Utilizza olio extravergine di oliva per cucinare o come principale condimento ?")]
        public Nullable<int> d01 { get; set; }
        [Display(Name = "d02 Quanto olio extravergine utilizza in una giornata tipo (considerando sia l’olio per cucinare, friggere sia per condire)? ")]
        public Nullable<decimal> d02 { get; set; }
        [Display(Name = "d03 Quante porzioni di verdure consuma al giorno (1 porzione = ~ 200 g)")]
        public Nullable<decimal> d03 { get; set; }
        [Display(Name = "d04 Quanti frutti consuma al giorno (includendo anche i succhi di frutta senza zucchero)?")]
        public Nullable<decimal> d04 { get; set; }
        [Display(Name = "d05 Quante porzioni di carne rossa, hamburger, o carni conservate (prosciutto, salame, affettati vari) consuma al giorno?")]
        public Nullable<decimal> d05 { get; set; }
        [Display(Name = "d06 Quante porzioni di  burro, margarina o panna consuma al giorno? ")]
        public Nullable<decimal> d06 { get; set; }
        [Display(Name = "d07 Quante bevande zuccherate consuma al giorno?")]
        public Nullable<decimal> d07 { get; set; }
        [Display(Name = "d08 Quanti bicchieri di vino beve a settimana?")]
        public Nullable<decimal> d08 { get; set; }
        [Display(Name = "d09 Quante porzioni di legumi consuma a settimana?")]
        public Nullable<decimal> d09 { get; set; }
        [Display(Name = "d10 Quante porzioni di pesce e/o di frutti di mare consuma a settimana")]
        public Nullable<decimal> d10 { get; set; }
        [Display(Name = "d11 Quante volte a settimana consuma dolci, biscotti o prodotti di pasticceria  commerciale (non fatti in casa)?")]
        public Nullable<decimal> d11 { get; set; }
        [Display(Name = "d12 Quante porzioni di frutta secca (noci, mandorle, anche noccioline ecc.), semi, consuma a settimana?")]
        public Nullable<decimal> d12 { get; set; }
        [Display(Name = "d13 Consuma preferibilmente carni di pollo, tacchino, coniglio rispetto alle carni di vitello, manzo, maiale o alle carni conservate?")]
        public Nullable<int> d13 { get; set; }
        [Display(Name = "d14 Quante porzioni di pasta di grano duro (tipo spaghetti, penne ecc.) consuma a settimana?")]
        public Nullable<decimal> d14 { get; set; }


        public virtual StatiRegistro StatiRegistro { get; set; }
    }

    //Form VALUTAZIONE METFORMINA
    [MetadataType(typeof(ValutazioneMetforminaMetadata))]
    public partial class ValutazioneMetformina
    {
    }
    public class ValutazioneMetforminaMetadata
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data consegna")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data scheda obbligatoria")]
        public System.DateTime dataConsegna { get; set; }
        [Display(Name = "pillole assunte")]
        public Nullable<int> pilloleAssunte { get; set; }
        [Display(Name = "data terminazione")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> dataTerminazione { get; set; }
        [Display(Name = "Effetti collaterali")]
        public bool effettiCollaterali { get; set; }
        [Display(Name = "Osservazioni")]
        public string osservazioni { get; set; }

        public virtual StatiRegistro StatiRegistro { get; set; }
    }


    //Form ASSEGNAZIONI POSTRANDOMIZZAZIONE
    public partial class AssegnazioniRegistro
    {
    }
    public class AssegnazioniRegistroMetadata
    {
        public int idAssegnazioneRegistro { get; set; }
        public int idPaziente { get; set; }
        public int idAssegnazioneElenco { get; set; }
        public System.DateTime DataApertura { get; set; }
        public Nullable<System.DateTime> DataChiusura { get; set; }
        public bool Completamento { get; set; }

        public virtual Anagrafica Anagrafica { get; set; }
        public virtual AssegnazioneFarmaco AssegnazioneFarmaco { get; set; }
        public virtual AssegnazioniElenco AssegnazioniElenco { get; set; }
    }


    [MetadataType(typeof(AssegnazioneFarmacoMetadata))]
    public partial class AssegnazioneFarmaco
    {
    }
    public class AssegnazioneFarmacoMetadata
    {

        public int idAssegnazioneRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }

        [Display(Name = "dosaggio")]
        [Required(ErrorMessage = "impostare dosaggio")]
        public int dosaggioPieno { get; set; }

        [Display(Name = "flaconi")]
        public int flaconiAssegnati { get; set; }

        [Display(Name = "data consegna")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data consegna obbligatoria")]
        public System.DateTime dataConsegna { get; set; }
        
        [Display(Name = "pillole assunte")]
        public int pilloleAssunte { get; set; }
        [Display(Name = "Effetti collaterali")]
        public bool effettiCollaterali { get; set; }
        [Display(Name = "Osservazioni")]
        public string osservazioni { get; set; }

        public virtual AssegnazioniRegistro AssegnazioniRegistro { get; set; }
    }


    //form DROP
    [MetadataType(typeof(DropMetadata))]
    public partial class Drop
    {
    }
    public class DropMetadata
    {
        public int idDrop { get; set; }
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        [Display(Name = "data chiusura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        [Required(ErrorMessage = "data obbligatoria")]
        public System.DateTime data { get; set; }
        [Display(Name = "data ultima assunzione")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        public Nullable<System.DateTime> dataUltimaAssunzione { get; set; }
        [Display(Name = "Tipologia motivazione")]
        public int idMotivazione { get; set; }

        [Display(Name = "altra motivazione")]
        public string motivazione { get; set; }

        [Required(ErrorMessage = "dato obbligatorio")]
        [Display(Name = "Outcome Primario")]
        public byte outcomePrimario { get; set; }
        
        [Display(Name = "Il partecipante ha avuto diagnosi di tumore?")]
        //[Required(ErrorMessage = "dato obbligatorio")]
        public Nullable<byte> tumore { get; set; }

        [Display(Name = "diagnosi")]
        public string tumoreDiagnosi { get; set; }

        [Display(Name = "sede")]
        public string tumoreSede { get; set; }

        [Display(Name = "Il partecipante ha avuto un evento cardiovascolare?")]
        //[Required(ErrorMessage = "dato obbligatorio")]
        public Nullable<byte> cardiovascolare { get; set; }

        [Display(Name = "diagnosi")]
        public string cardiovascolareDiagnosi { get; set; }

        [Display(Name = "descrizione")]
        public string cardiovascolareDescrizione { get; set; }

        [Display(Name = "Il partecipante ha avuto una diagnosi di diabete di tipo 2?")]
        //[Required(ErrorMessage = "dato obbligatorio")]
        public Nullable<byte> diabeteTipo2 { get; set; }

        [Display(Name = "Il partecipante ha avuto una diagnosi diversa dalle precedenti?")]
        //[Required(ErrorMessage = "dato obbligatorio")]
        public Nullable<byte> altre { get; set; }
        
        [Display(Name = "diagnosi")]
        public string altreDiagnosi { get; set; }

        [Display(Name = "descrizione")]
        public string altreDescrizione { get; set; }

        [Display(Name = "data diagnosi principlale")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [UIHint("SoloDate")]
        //[Required(ErrorMessage = "data obbligatoria")]
        public Nullable<System.DateTime> dataDiagnosiPrincipale { get; set; }

        public virtual StatiRegistro StatiRegistro { get; set; }

    }

    //REGISTRO SCHEDE
    [MetadataType(typeof(StatiRegistroMetadata))]
    public partial class StatiRegistro
    {
    }

    public class StatiListato
    {
        public System.Int32 idStatoRegistro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [Display(Name = "registrazione")]
        public System.DateTime registrazione { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [Display(Name = "compilazione")]
        public System.DateTime compilazione { get; set; }

        public string descrizioneFase { get; set; }
        public string descrizioneForm { get; set; }

    }
    public class StatiRegistroMetadata
    {
        [Display(Name = "avviata")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")] 
        public System.DateTime DataApertura { get; set; }
        [Display(Name = "registrazione")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")] 
        public System.DateTime DataChiusura { get; set; }

        public virtual Anagrafica Anagrafica { get; set; }
        public virtual Antropometria Antropometria { get; set; }
        public virtual AttivitaFisica AttivitaFisica { get; set; }
        public virtual DiarioDieta24 DiarioDieta24 { get; set; }
        public virtual ICollection<Drop> Drop { get; set; }
        public virtual Prelievo Prelievo { get; set; }
        public virtual StatiElenco StatiElenco { get; set; }
        public virtual StileDiVita StileDiVita { get; set; }
        public virtual Trattamenti Trattamenti { get; set; }
        public virtual ValutazioneMetformina ValutazioneMetformina { get; set; }

    }

    //LOGIN
    [MetadataType(typeof(EmergenzeLogMetadata))]
    public partial class EmergenzeLog
    {
    }
    public class EmergenzeLogMetadata
    {
        public int idEmergenza { get; set; }
        public System.DateTime dataRegistrazione { get; set; }
        public string userName { get; set; }
        public string ricercaEsito { get; set; }
        public string ricerca { get; set; }
        public bool adminChecked { get; set; }
    }
}
