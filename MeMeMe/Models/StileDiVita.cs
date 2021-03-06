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
    
    public partial class StileDiVita
    {
        public int idStatoRegistro { get; set; }
        public System.DateTime dataInserimento { get; set; }
        public string userName { get; set; }
        public System.DateTime data { get; set; }
        public bool mPreoccupazione { get; set; }
        public bool mRicerca { get; set; }
        public bool mStile { get; set; }
        public bool mAltro { get; set; }
        public string motivazioneAltro { get; set; }
        public Nullable<int> fumo { get; set; }
        public Nullable<int> fumoFine { get; set; }
        public Nullable<int> fumoInizio { get; set; }
        public Nullable<int> fumoSigaretteMedia { get; set; }
        public Nullable<int> fumoSigaretteMax { get; set; }
        public Nullable<byte> fumoSigari { get; set; }
        public Nullable<byte> fumoPipa { get; set; }
        public byte ipertensione { get; set; }
        public Nullable<byte> ipertensioneTrattamento { get; set; }
        public byte patologiaApparatoCardiocircolatorio { get; set; }
        public bool pacAngina { get; set; }
        public bool pacCardiomiopatia { get; set; }
        public bool pacStenosi { get; set; }
        public bool pacAritmia { get; set; }
        public bool pacTIA { get; set; }
        public bool pacAltre { get; set; }
        public string pacAltreTxt { get; set; }
        public byte patologiaApparatoRespiratorio { get; set; }
        public bool parAsma { get; set; }
        public bool parEnfisema { get; set; }
        public bool parAltre { get; set; }
        public string parAltreTxt { get; set; }
        public byte patologiaApparatoDigerente { get; set; }
        public bool padGastrite { get; set; }
        public bool padUlcera { get; set; }
        public bool padPolipi { get; set; }
        public bool padDiverticolite { get; set; }
        public bool padErnia { get; set; }
        public bool padAltre { get; set; }
        public string padAltreTxt { get; set; }
        public byte patologiaApparatoUrogenitale { get; set; }
        public bool pauNefrite { get; set; }
        public bool pauCalcolosi { get; set; }
        public bool pauInsufficienza { get; set; }
        public bool pauProstata { get; set; }
        public bool pauOvaio { get; set; }
        public bool pauUtero { get; set; }
        public bool pauAltre { get; set; }
        public string pauAltreTxt { get; set; }
        public byte patologiaApparatoOsteoarticolare { get; set; }
        public bool paoArtrite { get; set; }
        public bool paoArtrosi { get; set; }
        public bool paoErnia { get; set; }
        public bool paoGotta { get; set; }
        public bool paoOsteoporosi { get; set; }
        public bool paoAltre { get; set; }
        public string paoAltreTxt { get; set; }
        public byte patologiaSistemaNervoso { get; set; }
        public bool patParkinson { get; set; }
        public bool patAlzheimer { get; set; }
        public bool patEmicrania { get; set; }
        public bool patAltre { get; set; }
        public string patAltreTxt { get; set; }
        public byte patologiaEndocrino { get; set; }
        public bool peTiroide { get; set; }
        public bool peIpofisi { get; set; }
        public bool peSurrene { get; set; }
        public bool peAltre { get; set; }
        public string peAltreTxt { get; set; }
        public byte patologiaMetabolismo { get; set; }
        public bool pmColesterolo { get; set; }
        public bool pmTrigliceridi { get; set; }
        public bool pmGlicemia { get; set; }
        public bool pmUricemia { get; set; }
        public bool pmSteatosi { get; set; }
        public bool pmAltre { get; set; }
        public string pmAltreTxt { get; set; }
        public byte patologiaOcchio { get; set; }
        public bool poCataratta { get; set; }
        public bool poGlaucoma { get; set; }
        public bool poRetinopatia { get; set; }
        public bool poMaculopatia { get; set; }
        public bool poAltre { get; set; }
        public string poAltreTxt { get; set; }
        public byte altrePatologie { get; set; }
        public bool apPsoriasi { get; set; }
        public bool apLupus { get; set; }
        public bool apSclerodermia { get; set; }
        public bool apArtriteReumatoide { get; set; }
        public bool apAltre { get; set; }
        public string apAltreTxt { get; set; }
        public string patologieNoteTxt { get; set; }
        public Nullable<int> mestruazioni { get; set; }
        public Nullable<int> menopausa { get; set; }
        public Nullable<System.DateTime> mestruazioniDataUltima { get; set; }
        public bool mestruazioniDataUltimaNsNr { get; set; }
        public Nullable<int> menopausaEta { get; set; }
        public Nullable<int> mestruazioniCessazione { get; set; }
        public Nullable<int> mestruazioniCessazioneEta { get; set; }
        public string mestruazioniCessazioneTipoIntervento { get; set; }
        public string mestruazioniCessazioneMotivazione { get; set; }
        public string mestruazioniCessazioneAltro { get; set; }
        public string mestruazioniCessazioneAltroMotivazione { get; set; }
        public Nullable<int> estrogeni { get; set; }
        public Nullable<int> terapiaOrmonale { get; set; }
        public Nullable<int> terapiaOrmonaleTempo { get; set; }
        public Nullable<int> pillolaContraccettiva { get; set; }
        public Nullable<int> pillolaContraccettivaTempo { get; set; }
        public Nullable<int> altriOrmonali { get; set; }
        public Nullable<int> altriOrmonaliTempo { get; set; }
        public Nullable<int> gravidanze { get; set; }
        public Nullable<int> gravidanzeNumero { get; set; }
        public Nullable<int> gravidanzeConcluse { get; set; }
        public Nullable<int> gravidanzeEtaPrimofiglio { get; set; }
        public Nullable<int> gravidanzeTentativi { get; set; }
        public Nullable<int> gravidanzeCureOrmonali { get; set; }
        public Nullable<int> stitichezza { get; set; }
        public Nullable<int> stitichezzaLassativi { get; set; }
        public Nullable<int> peso20Anni { get; set; }
        public Nullable<int> pesoMax { get; set; }
        public Nullable<int> pesoPrimeMestruazioni { get; set; }
    
        public virtual StatiRegistro StatiRegistro { get; set; }
    }
}
