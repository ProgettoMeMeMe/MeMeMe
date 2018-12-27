using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.SqlClient;

namespace MeMeMe.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "emergenza")]
    public class EmergenzaController : Controller
    {
        private MeMeMeEntities db = new MeMeMeEntities();
        private ApplicationDbContext context = new ApplicationDbContext();
        int TentativiPerUtente = 5;

        public ActionResult Index(FormCollection collection)
        {
            //Controllo tentativi rimasti
            ViewBag.tentativi = null;
           // int nTentativi = db.EmergenzeLog.Where(e => e.userName == User.Identity.Name && e.ricercaEsito == "ok" && e.adminChecked == true).Count();

            //Ricerca
            if (collection["search"] == null || collection["search"] == "")
            {
                ViewBag.Serach = null;
                ViewBag.TentativiRimasti = TentativiPerUtente-TentativiRimasti(User.Identity.Name);
                return View();
            }
            else
            {
                string s = collection["search"];
                ViewBag.Search = s;
                var anagrafica = from a in db.Anagrafica
                                 where (a.cognome==s || a.cfiscale==s)
                                 select a;

                if (anagrafica.Count() == 0 || s == "")
                {
                    //scrive nel log e termina
                    EmergenzeLog el = new EmergenzeLog();
                    el.dataRegistrazione = DateTime.Now;
                    el.userName = User.Identity.Name;
                    el.ricercaEsito = "ko";
                    el.ricerca = s;
                    el.adminChecked = false;
                    db.EmergenzeLog.Add(el);
                    db.SaveChanges();
                    //esito
                    ViewBag.SearchResult = "ko";
                }
                else
                {
                    if (anagrafica.Count() > 1)
                    {
                        //scrive nel log e termina
                        EmergenzeLog el = new EmergenzeLog();
                        el.dataRegistrazione = DateTime.Now;
                        el.userName = User.Identity.Name;
                        el.ricercaEsito = "ko OMONIMI";
                        el.ricerca= s;
                        el.adminChecked = false;
                        db.EmergenzeLog.Add(el);
                        db.SaveChanges();
                        //esito
                        ViewBag.SearchResult = "ko OMONIMI";
                    }
                    else
                    {
                        //Scrive nel log
                        EmergenzeLog el = new EmergenzeLog();
                        el.dataRegistrazione = DateTime.Now;
                        el.userName = User.Identity.Name;
                        el.ricercaEsito = "ok";
                        el.ricerca = s;
                        el.adminChecked = true;
                        db.EmergenzeLog.Add(el);
                        db.SaveChanges();
                        //estrae codice
                        foreach (var fr in anagrafica) {
                            Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == fr.idPaziente);

                            var randomizzazione = new SqlParameter("@randomizzazione", SqlDbType.VarChar, 50)
                            {
                                Direction = ParameterDirection.Output
                            };

                            var result = context.Database.ExecuteSqlCommand("sp_EmergenzaRotturaCieco @idPaziente,@randomizzazione out",
                            new SqlParameter("@idPaziente", paziente.idPaziente),
                            randomizzazione);
                            ViewBag.Paziente = paziente.nome + " " + paziente.cognome + " - " + paziente.cfiscale.ToUpper();
                            ViewBag.Indirizzo = paziente.indirizzo + " " + paziente.comune;
                            ViewBag.Riferimenti = paziente.riferimentoNome + " " + paziente.riferimentoCognome + " " + paziente.riferimentoTelefono;
                            ViewBag.Braccio = randomizzazione.SqlValue;
                            //esito
                            ViewBag.SearchResult = "ok";
                            ViewBag.TentativiRimasti = TentativiPerUtente - TentativiRimasti(User.Identity.Name);
                        }
                    }
                }
                //tentativi
                ViewBag.TentativiRimasti = TentativiPerUtente - TentativiRimasti(User.Identity.Name);
                return View();
            }
        }


        private int TentativiRimasti(string utente)
        {
            int nTentativi = db.EmergenzeLog.Where(e => e.userName == utente && e.ricercaEsito == "ok" && e.adminChecked == true).Count();
            return nTentativi;
        }
    }
}
