using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.SqlClient;
using System.Text;
using System.Data.Entity.Validation;
using System.Dynamic;

namespace MeMeMe.Controllers
{
    public class AgendaController : Controller
    {

        private MeMeMeEntities db = new MeMeMeEntities();
        private ApplicationDbContext context = new ApplicationDbContext();


        [SessionExpireFilter]
        [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
        public ActionResult Index(FormCollection collection)
        {
            //Interrogazione
            dynamic mymodel = new ExpandoObject();
            Agenda range = new Agenda();

            //date impostata
            range.dataA = null;
            range.dataDa = null;
            if (String.IsNullOrEmpty(collection["scadenziario.dataDa"])==false && String.IsNullOrEmpty(collection["scadenziario.dataA"])==false)
            {
                range.dataDa = Convert.ToDateTime(collection["scadenziario.dataDa"]);
                range.dataA = Convert.ToDateTime(collection["scadenziario.dataA"]);
            }
            mymodel.scadenziario = range;

            //listato
            var agendaListato = new List<dynamic>();
            var anagrafica = db.sp_ScadenziarioFlaconi(range.dataDa, range.dataA);
            foreach (var fr in anagrafica)
            {
                dynamic al = new AgendaListato();
                var sucf = StatoUltimoChiusoFarmaco(fr.idPaziente);
                al.idPaziente = fr.idPaziente;
                al.idMeMeMe = "MINT" + String.Format("{0:00000}", fr.idPaziente);
                al.paziente = fr.Cognome + " " + fr.Nome;
                al.cfiscale = fr.cfiscale;
                al.fase = sucf.AssegnazioniElenco.descrizione;
                al.flaconi = 1 + "(Dosaggio pieno)";
                if(sucf.AssegnazioniElenco.idAssegnazioneElenco!=1){
                    if(sucf.AssegnazioniElenco.dosaggioPieno==sucf.AssegnazioneFarmaco.flaconiAssegnati){
                        al.flaconi = sucf.AssegnazioneFarmaco.flaconiAssegnati + "(Dosaggio pieno)";
                    }else{
                        al.flaconi = sucf.AssegnazioneFarmaco.flaconiAssegnati + "(Mezzo dosaggio)";
                    }
                    
                }
                al.prossimoRitiro = (Convert.ToDateTime(fr.prossimoRitiro)).ToLongDateString();
                al.prossimoRitiroData = Convert.ToDateTime(fr.prossimoRitiro);
                agendaListato.Add(al);
            }
            mymodel.agendaListato = agendaListato;


            return View(mymodel);
        }

        public ActionResult ElencoPrelievi(FormCollection collection)
        {
            //Interrogazione
            dynamic mymodel = new ExpandoObject();
            Agenda range = new Agenda();

            //date impostata
            range.dataA = null;
            range.dataDa = null;
            if (String.IsNullOrEmpty(collection["scadenziario.dataDa"]) == false && String.IsNullOrEmpty(collection["scadenziario.dataA"]) == false)
            {
                range.dataDa = Convert.ToDateTime(collection["scadenziario.dataDa"]);
                range.dataA = Convert.ToDateTime(collection["scadenziario.dataA"]);
            }
            mymodel.scadenziario = range;

            //listato
            var agendaListato = new List<dynamic>();
            var elenco = db.sp_ElencoPrelievi(range.dataDa, range.dataA);

            foreach (var ep in elenco)
            {
                dynamic p = new PrelieviListato();
                p.progetto = ep.progetto;
                p.dataPrelievo = (Convert.ToDateTime(ep.dataPrelievo)).ToLongDateString();
                p.idPaziente = ep.idPaziente;
                p.paziente = ep.cognome + " " + ep.nome;
                p.dieta = ep.Dieta;
                p.telefonoCasa = ep.telefonocasa;
                p.telefonoLavoro = ep.telefonolavoro;
                p.telefonoCellulare = ep.telefonocellulare;

                agendaListato.Add(p);
            }
            mymodel.agendaListato = agendaListato;


            return View(mymodel);
        }

        public StatiRegistro StatoCorrente(int idPaziente)
        {
            StatiRegistro sc = new StatiRegistro();
            var statoCorrente = from s in db.StatiRegistro
                                where s.idPaziente == idPaziente && s.Completamento == false
                                select s;
            if (statoCorrente.Count() == 1)
            {
                sc = db.StatiRegistro.Single(u => u.idPaziente == idPaziente && u.Completamento == false);
            }
            return sc;
        }

        public AssegnazioniRegistro StatoCorrenteFarmaco(int idPaziente)
        {
            AssegnazioniRegistro scf = new AssegnazioniRegistro();
            var statoCorrenteF = from s in db.AssegnazioniRegistro
                                 where s.idPaziente == idPaziente && s.Completamento == false
                                 select s;
            if (statoCorrenteF.Count() == 1)
            {
                scf = db.AssegnazioniRegistro.Single(u => u.idPaziente == idPaziente && u.Completamento == false);
            }
            return scf;
        }

        public AssegnazioniRegistro StatoUltimoChiusoFarmaco(int idPaziente)
        {
            AssegnazioniRegistro sucf = new AssegnazioniRegistro();
            AssegnazioniRegistro scf = db.AssegnazioniRegistro.SingleOrDefault(u => u.idPaziente == idPaziente && u.Completamento == false);
            if(scf!=null){
                if (scf.idAssegnazioneElenco == 1)
                {
                    sucf = db.AssegnazioniRegistro.Single(ar => ar.idPaziente == idPaziente && ar.idAssegnazioneElenco == scf.idAssegnazioneElenco);
                }
                if (scf.idAssegnazioneElenco > 1) { 
                    sucf = db.AssegnazioniRegistro.Single(ar => ar.idPaziente == idPaziente && ar.idAssegnazioneElenco == scf.idAssegnazioneElenco-1 );
                }
            }

            return sucf;
        }
    }
}

