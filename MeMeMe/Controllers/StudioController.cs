using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.SqlClient;
using System.Text;
using System.Data.Entity.Validation;
using System.Configuration;
using System.Data;

namespace MeMeMe.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
    public class StudioController : BaseController
    {
        private MeMeMeEntities db = new MeMeMeEntities();
        private ApplicationDbContext context = new ApplicationDbContext();
        private MeMeMeEntities contextEF = new MeMeMeEntities();

        public ActionResult Index(FormCollection collection)
        {
            bool tipoP = Convert.ToBoolean(collection["tipoP"]);
            string stato = collection["ElencoStati"];
            var anagrafiche = new List<dynamic>();
            int casi = 0;

            StringBuilder strSQL = new StringBuilder();
            //strSQL.Append(" SELECT");
            //strSQL.Append(" idPaziente");
            //strSQL.Append(" ,codPaziente as idMememe");
            //strSQL.Append(" ,randomizzazioneDieta");
            //strSQL.Append(" ,cognome + ' ' + nome as Paziente");
            //strSQL.Append(" ,cfiscale");
            //strSQL.Append(" ,(SELECT Count(*) FROM KitFlaconiAssegnazione WHERE idPaziente=Anagrafica.idPaziente) as flaconiRicevuti");
            //strSQL.Append(" ,StatiElenco.fase  as statoFase");
            //strSQL.Append(" ,StatiElenco.descrizione as statoPaziente");
            //strSQL.Append(" ,StatiElenco.descrizioneForm as descrizioneForm");
            //strSQL.Append(" ,dbo.motivazioneDROP(Anagrafica.idPaziente) as motivazione");
            //strSQL.Append(" ,(SELECT Count(*) FROM SAE WHERE idPaziente=Anagrafica.idPaziente) as SAE");
            //strSQL.Append(" ,(SELECT Count(*) FROM AE WHERE idPaziente=Anagrafica.idPaziente) as AE");
            //strSQL.Append(" ,CASE WHEN fromTevere is null THEN 0 else 1 END as fromTevere");
            //strSQL.Append(" FROM Anagrafica");
            //strSQL.Append(" INNER JOIN StatiElenco ON dbo.idStatoCorrente(Anagrafica.idPaziente)=StatiElenco.idStato");
            //strSQL.Append(" WHERE 1 = 1");

            strSQL.Append("SELECT anagrafica.idPaziente");
            strSQL.Append(" ,codPaziente as idMememe");
            strSQL.Append(" ,randomizzazioneDieta");
            strSQL.Append(" ,cognome + ' ' + nome as Paziente");
            strSQL.Append(" ,cfiscale");
            strSQL.Append(" ,(SELECT Count(*) FROM KitFlaconiAssegnazione WHERE idPaziente = Anagrafica.idPaziente) as flaconiRicevuti");
            strSQL.Append(" ,StatiElenco.fase as statoFase");
            strSQL.Append(" ,StatiElenco.descrizione as statoPaziente");
            strSQL.Append(" ,StatiElenco.descrizioneForm as descrizioneForm");
            strSQL.Append(" ,dbo.motivazioneDROP(Anagrafica.idPaziente) as motivazione");
            strSQL.Append(" ,(SELECT Count(*) FROM SAE WHERE idPaziente = Anagrafica.idPaziente) as SAE");
            strSQL.Append(" ,(SELECT Count(*) FROM AE WHERE idPaziente = Anagrafica.idPaziente) as AE ,CASE WHEN fromTevere is null THEN 0 else 1 END as fromTevere");
            strSQL.Append(" FROM Anagrafica");
            strSQL.Append(" INNER JOIN v_StatoCorrente ON Anagrafica.idPaziente = v_StatoCorrente.idPaziente");
            strSQL.Append(" INNER JOIN StatiElenco ON v_StatoCorrente.statocorrente = StatiElenco.idStato");
            strSQL.Append(" WHERE 1 = 1");
            //nome e cognome
            if (String.IsNullOrEmpty(collection["search"])==false)
            {
                strSQL.Append(" AND Cognome like '%" + collection["search"].Replace("'", "''") + "%' OR  Nome like '%" + collection["search"].Replace("'", "''") + "%'");
            }
            //stato
            if (String.IsNullOrEmpty(stato)==false)
            {
                //strSQL.Append(" AND dbo.idStatoCorrente(Anagrafica.idPaziente)=" + stato);
                strSQL.Append(" AND v_StatoCorrente.statoCorrente=" + stato);
            }
            //tipo elenco
            if (tipoP == false)
            {
                //strSQL.Append(" AND dbo.idStatoCorrente(Anagrafica.idPaziente)<99");
                strSQL.Append(" AND v_StatoCorrente.statoCorrente<99");
            }
            strSQL.Append(" ORDER BY Anagrafica.idPaziente");

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlDataReader rdr1 = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL.ToString(), conn);
                rdr1 = cmd.ExecuteReader();

                while (rdr1.Read())
                {
                    dynamic a = new InserimentiList();
                    a.idPaziente = (Int32)rdr1["idPaziente"];
                    a.idMeMeMe = rdr1["idMeMeMe"].ToString();
                    a.randomizzazioneDieta = (Int32)rdr1["randomizzazioneDieta"];
                    a.paziente = rdr1["Paziente"].ToString();
                    a.cfiscale = rdr1["cfiscale"].ToString();
                    a.flaconiRicevuti = (Int32)rdr1["flaconiRicevuti"];
                    a.statoFase = rdr1["statoFase"].ToString();
                    a.statoPaziente = rdr1["statoPaziente"].ToString();
                    a.descrizioneForm = rdr1["descrizioneForm"].ToString();
                    a.motivazione = rdr1["motivazione"].ToString();
                    a.SAE = (Int32)rdr1["SAE"];
                    a.AE = (Int32)rdr1["AE"];
                    a.fromTevere = (Int32)rdr1["fromTevere"];
                    anagrafiche.Add(a);
                    casi++;
                }
                rdr1.Close();
                conn.Close();

            }

            ViewBag.casi = casi;
            ViewBag.search = collection["search"];
            ViewBag.tipoP = collection["tipoP"];
            if (String.IsNullOrEmpty(collection["tipoP"]))
            {
                ViewBag.tipoP = "false";
            }
            //stati
            ViewBag.stato = stato;
            List<SelectListItem> items = new SelectList(db.StatiElenco, "idStato", "descrizione", stato).ToList();
            items.Insert(0, (new SelectListItem { Text = "-- tutti gli stati ---", Value = "" }));
            ViewBag.ElencoStati = items;


            return View(anagrafiche);














            //var lista = db.sp_Inserimenti("a");
            //IEnumerable<Anagrafica> anagrafica = new List<Anagrafica>();
            //foreach (var fr in lista) { 
            //    dynamic a = new InserimentiList();
            //    a.idPaziente = fr.idPaziente;
            //    a.idMeMeMe = fr.idMememe;
            //    a.randomizzazioneDieta = fr.randomizzazioneDieta;
            //    a.paziente = fr.Paziente;
            //    a.cfiscale = fr.cfiscale;
            //    a.flaconiRicevuti = (Int32)fr.flaconiRicevuti;
            //    a.statoFase = fr.statoFase;
            //    a.statoPaziente = fr.statoPaziente;
            //    a.descrizioneForm = fr.descrizioneForm;
            //    a.motivazione = fr.motivazione;
            //    //a.eventiAvversi = fr.eventiAvversi;
            //    a.SAE = (Int32)fr.SAE;
            //    a.AE = (Int32)fr.AE;
            //    anagrafiche.Add(a);
            //}

            //if (String.IsNullOrEmpty(collection["search"]))
            //{
            //    if (tipoP)
            //    {
            //        anagrafica = db.Anagrafica
            //                .Include(a => a.LUIParentela)
            //                .Include(a => a.LUIstruzione)
            //                .Include(a => a.LUProfessione)
            //                .Include(a => a.LUStatoCivile);
            //    }
            //    else
            //    {
            //        anagrafica = from a in db.Anagrafica
            //                     where !(from sr in db.StatiRegistro
            //                             join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                             select sr.idPaziente).Contains(a.idPaziente)

            //                     select a;
            //    }
            //    foreach (var fr in anagrafica)
            //    {
            //        Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == fr.idPaziente);
            //        var sc = StatoCorrente(fr.idPaziente);
            //        dynamic a = new InserimentiList();

            //        int nSAE = (from sr in db.SAE
            //                    where sr.idPaziente == fr.idPaziente
            //                    select sr).Count();
            //        int nAE = (from sr in db.AE
            //                   where sr.idPaziente == fr.idPaziente
            //                   select sr).Count();
            //        string numeroEventi = "";
            //        numeroEventi = nSAE == 0 ? numeroEventi : "SAE(" + nSAE.ToString() + ") ";
            //        numeroEventi = nAE == 0 ? numeroEventi : numeroEventi + "AE(" + nAE.ToString() + ") ";
            //        a.idPaziente = fr.idPaziente;
            //        a.idMeMeMe = "MINT" + String.Format("{0:00000}", fr.idPaziente);
            //        a.paziente = fr.cognome + " " + fr.nome;
            //        if (User.IsInRole("audit"))
            //        {
            //            a.paziente = fr.codPaziente;
            //        }
            //        a.cfiscale = fr.cfiscale;
            //        a.randomizzazioneDieta = fr.randomizzazioneDieta;
            //        a.fromTevere = fr.fromTevere;
            //        //Conteggio flaconi
            //        int totFlaconi = (from d in db.KitFlaconiAssegnazione
            //                          where d.idPaziente == fr.idPaziente
            //                          select d).Count();
            //        a.flaconiRicevuti = totFlaconi;
            //        a.statoFase = sc.StatiElenco.fase;
            //        a.descrizioneForm = sc.StatiElenco.descrizioneForm;
            //        a.statoPaziente = sc.StatiElenco.descrizione;
            //        //a.eventiAvversi = numeroEventi;
            //        int dr = (from sr in db.StatiRegistro
            //                  join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                  where sr.idPaziente == fr.idPaziente
            //                  select d).Count();
            //        if (dr == 1)
            //        {
            //            var i = (from sr in db.StatiRegistro
            //                     join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                     where sr.idPaziente == fr.idPaziente
            //                     select sr.idStatoRegistro).Single();

            //            Drop drop = db.Drop.Where(d => d.idStatoRegistro == i).Single();
            //            //string motivazione = string.IsNullOrEmpty(a.motivazione) == true ? "SAE(" + nSAE.ToString() + ") " : "";
            //            string motivazione = string.IsNullOrEmpty(drop.motivazione) == true ? drop.LUDropMotivazioni.motivazione.ToUpper() : drop.LUDropMotivazioni.motivazione.ToUpper() + " - " + drop.motivazione;
            //            a.motivazione = motivazione.ToLower();
            //        }
            //        //stato corrente
            //        if (String.IsNullOrEmpty(stato))
            //        {
            //            anagrafiche.Add(a);
            //            casi++;
            //        }
            //        else
            //        {
            //            if (stato == sc.idStato.ToString())
            //            {
            //                anagrafiche.Add(a);
            //                casi++;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    string s = collection["search"];

            //    if (tipoP)
            //    {
            //        if (!User.IsInRole("audit"))
            //        {
            //            anagrafica = (from a in db.Anagrafica.Include(a => a.LUIParentela).Include(a => a.LUIstruzione).Include(a => a.LUProfessione).Include(a => a.LUStatoCivile)
            //                          where (a.cognome.Contains(s) || a.nome.Contains(s) || a.cfiscale == s || a.codPaziente == s)
            //                          select a);
            //        }
            //        else
            //        {
            //            anagrafica = (from a in db.Anagrafica.Include(a => a.LUIParentela).Include(a => a.LUIstruzione).Include(a => a.LUProfessione).Include(a => a.LUStatoCivile)
            //                          where (a.codPaziente == s)
            //                          select a);
            //        }
            //    }
            //    else
            //    {
            //        if (!User.IsInRole("audit"))
            //        {
            //            anagrafica = from a in db.Anagrafica
            //                         where !(from sr in db.StatiRegistro
            //                                 join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                                 select sr.idPaziente).Contains(a.idPaziente)
            //                                 && (a.cognome.Contains(s) || a.nome.Contains(s) || a.cfiscale == s || a.codPaziente == s)
            //                         select a;
            //        }
            //        else
            //        {
            //            anagrafica = from a in db.Anagrafica
            //                         where !(from sr in db.StatiRegistro
            //                                 join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                                 select sr.idPaziente).Contains(a.idPaziente)
            //                                 && (a.codPaziente == s)
            //                         select a;
            //        }
            //    }

            //    foreach (var fr in anagrafica)
            //    {
            //        Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == fr.idPaziente);
            //        var sc = StatoCorrente(fr.idPaziente);
            //        dynamic a = new InserimentiList();

            //        int nSAE = (from sr in db.SAE
            //                    where sr.idPaziente == fr.idPaziente
            //                    select sr).Count();
            //        int nAE = (from sr in db.AE
            //                   where sr.idPaziente == fr.idPaziente
            //                   select sr).Count();
            //        string numeroEventi = "";
            //        numeroEventi = nSAE == 0 ? numeroEventi : "SAE(" + nSAE.ToString() + ") ";
            //        numeroEventi = nAE == 0 ? numeroEventi : numeroEventi + "AE(" + nAE.ToString() + ") ";

            //        a.idPaziente = fr.idPaziente;
            //        a.idMeMeMe = "MINT" + String.Format("{0:00000}", fr.idPaziente);
            //        a.paziente = fr.cognome + " " + fr.nome;
            //        if (User.IsInRole("audit"))
            //        {
            //            a.paziente = fr.codPaziente;
            //        }
            //        a.cfiscale = fr.cfiscale;
            //        a.randomizzazioneDieta = fr.randomizzazioneDieta;
            //        //da implementare
            //        a.flaconiRicevuti = 0;
            //        a.statoFase = sc.StatiElenco.fase;
            //        a.descrizioneForm = sc.StatiElenco.descrizioneForm;
            //        a.statoPaziente = sc.StatiElenco.descrizione;
            //        a.eventiAvversi = numeroEventi;
            //        a.fromTevere = fr.fromTevere;
            //        int dr = (from sr in db.StatiRegistro
            //                  join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                  where sr.idPaziente == fr.idPaziente
            //                  select d).Count();
            //        if (dr == 1)
            //        {
            //            var i = (from sr in db.StatiRegistro
            //                     join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
            //                     where sr.idPaziente == fr.idPaziente
            //                     select sr.idStatoRegistro).Single();

            //            Drop drop = db.Drop.Where(d => d.idStatoRegistro == i).Single();
            //            //string motivazione = string.IsNullOrEmpty(a.motivazione) == true ? "SAE(" + nSAE.ToString() + ") " : "";
            //            string motivazione = string.IsNullOrEmpty(drop.motivazione) == true ? drop.LUDropMotivazioni.motivazione.ToUpper() : drop.LUDropMotivazioni.motivazione.ToUpper() + " - " + drop.motivazione;
            //            a.motivazione = motivazione.ToLower();
            //        }

            //        //stato corrente
            //        if (String.IsNullOrEmpty(stato))
            //        {
            //            anagrafiche.Add(a);
            //            casi++;
            //        }
            //        else
            //        {
            //            if (stato == sc.idStato.ToString())
            //            {
            //                anagrafiche.Add(a);
            //                casi++;
            //            }
            //        }
            //    }
            //}

        }

        public ActionResult RicercaFlaconi(FormCollection collection)
        {
            var ricercaFlaconi = new List<dynamic>();
            IEnumerable<KitFlaconiAssegnazione> af = new List<KitFlaconiAssegnazione>();

            if (String.IsNullOrEmpty(collection["search"]))
            {
                //af = db.KitFlaconiAssegnazione;
                return View(ricercaFlaconi);
            }
            else
            {
                string s = collection["search"];
                af = (from kfa in db.KitFlaconiAssegnazione
                              where (kfa.Kit.Contains(s))
                              select kfa);

            }
            foreach (var fr in af)
            {
                //Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == fr.idPaziente);
                dynamic a = new flaconiList();
                AssegnazioniRegistro assegnazioneRegistro = db.AssegnazioniRegistro.SingleOrDefault(u => u.idPaziente == fr.idPaziente && u.idAssegnazioneElenco == fr.idAssegnazioneElenco);
                AssegnazioneFarmaco assegnazioneFarmaco = db.AssegnazioneFarmaco.SingleOrDefault(u => u.idAssegnazioneRegistro == assegnazioneRegistro.idAssegnazioneRegistro);
                string dosaggio = "pieno";
                if (assegnazioneFarmaco!=null && assegnazioneFarmaco.dosaggioPieno==0) {
                    dosaggio = "mezzo";
                }
                a.idAssegnazione = fr.idAssegnazione;
                a.kit = fr.Kit;
                a.idPaziente = fr.idPaziente;
                a.idMeMeMe = "MINT" + String.Format("{0:00000}", fr.idPaziente);
                a.paziente = fr.Anagrafica.cognome + " " + fr.Anagrafica.nome;
                a.dataAssegnazione = fr.dataAssegnazione;
                a.utente = fr.utente;
                a.faseAssegnazione = fr.AssegnazioniElenco.descrizione;
                a.dosaggio = dosaggio;
                ricercaFlaconi.Add(a);
            }
            ViewBag.search = collection["search"];
            return View(ricercaFlaconi);
        }

        // GET: /Studio/
        public ActionResult Paziente(int idPaziente)
        {
            var statiregistro = db.StatiRegistro
                                .Include(s => s.Anagrafica)
                                .Include(s => s.AttivitaFisica)
                                .Include(s => s.DiarioDieta24)
                                .Include(s => s.StatiElenco)
                                .Include(s => s.StileDiVita)
                                .Include(s => s.Prelievo)
                                .Where(u => u.idPaziente == idPaziente && u.Completamento == true);
            
            var sc = StatoCorrente(idPaziente);
            var scf = StatoCorrenteFarmaco(idPaziente);
            int rDieta = sc.Anagrafica.randomizzazioneDieta;
            //info paziente
            if (rDieta == 1)
            {
                ViewBag.dietaStyle = "randomizzazioneDietaBlu";
            }
            if (rDieta == 2)
            {
                ViewBag.dietaStyle = "randomizzazioneDietaGreen";
            }
            //avanzamento schede
            ViewBag.description = sc.StatiElenco.descrizione;
            ViewBag.ultimaAttività = sc.DataApertura;
            ViewBag.id = sc.idStatoRegistro;
            ViewBag.idStatoElenco = sc.StatiElenco.idStato;
            ViewBag.view = sc.StatiElenco.descrizioneForm;
            DateTime today = DateTime.Today;
            var dateSpan = DateTimeSpan.CompareDates(sc.DataApertura, today);
            ViewBag.AnniDaUltimaScheda = dateSpan.Years;
            ViewBag.MesiDaUltimaScheda = dateSpan.Months;
            ViewBag.GiorniDaUltimaScheda = dateSpan.Days;
            //avanzamento farmaco
            if (scf.idPaziente > 0) { 
                ViewBag.descriptionFarmaci = scf.AssegnazioniElenco.descrizione;
                ViewBag.ultimaAttivitàFarmaci = scf.DataApertura;
                ViewBag.idFarmaci = scf.idAssegnazioneRegistro;
                ViewBag.idStatoElencoFarmaci = scf.AssegnazioniElenco.idAssegnazioneElenco;
                ViewBag.viewFarmaci = scf.AssegnazioniElenco.descrizioneForm;
                ViewBag.attivitaFarmaci = scf.AssegnazioniElenco.istruzioni;
                var dateSpanFarmaco = DateTimeSpan.CompareDates(sc.DataApertura, today);
                ViewBag.AnniDaUltimaAssegnazione = dateSpanFarmaco.Years;
                ViewBag.MesiDaUltimaAssegnazione = dateSpanFarmaco.Months;
                ViewBag.GiorniDaUltimaAssegnazione = dateSpanFarmaco.Days;
            }
            //paziente
            ViewBag.paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome + " MINT" + String.Format("{0:00000}", sc.Anagrafica.idPaziente);
            if (User.IsInRole("audit"))
            {
                ViewBag.paziente =  sc.Anagrafica.codPaziente;
            }
            ViewBag.statoAttivita = sc.StatiElenco.istruzioni;
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(idPaziente);
            ViewBag.idPaziente = idPaziente;
            //verifica eventi avversi
            ViewBag.numeroSAE = SAECount(idPaziente);
            ViewBag.numeroAE = AECount(idPaziente);
            /*recupera stato avanzamento*/
            Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == idPaziente);
            return View(statiregistro.ToList());

        }

        /*IN LAVORAZIONE*/
        public ActionResult qCreate()
        {
            return View();
        }

        /*STILE DI VITA OK*/
        public ActionResult StileVitaCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.idPaziente = idPaziente;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.sesso=SessoPaziente(idPaziente);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StileVitaCreate(StileDiVita stilevita)
        {

            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce prelievo
                        stilevita.userName = User.Identity.Name;
                        stilevita.dataInserimento = DateTime.Now;
                        contextEF.StileDiVita.Add(stilevita);
                        contextEF.SaveChanges();

                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == stilevita.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(stilevita);
                    }
                }
            }
            ViewBag.sesso = SessoPaziente(Convert.ToInt32(Request.QueryString["idPaziente"]));
            ViewBag.idStatoRegistro = stilevita.idStatoRegistro;
            return View(stilevita);
        }

        public ActionResult StileVitaEdit(int? id)
        {
            StileDiVita stilevita = db.StileDiVita.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            ViewBag.sesso = SessoPaziente(stilevita.StatiRegistro.Anagrafica.idPaziente);
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(stilevita);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StileVitaEdit(StileDiVita stilevita)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == stilevita.idStatoRegistro);
                    db.Entry(stilevita).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = stilevita.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(stilevita);
                }
            }
            ViewBag.idStatoRegistro = stilevita.idStatoRegistro;
            return View(stilevita);
        }

        /*DIARIO 24 OK */
        public ActionResult Diario24Create(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Diario24Create(DiarioDieta24 diario24)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce prelievo
                        diario24.userName = User.Identity.Name;
                        diario24.dataInserimento = DateTime.Now;
                        contextEF.DiarioDieta24.Add(diario24);
                        contextEF.SaveChanges();

                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == diario24.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(diario24);
                    }
                }
            }
            ViewBag.idStatoRegistro = diario24.idStatoRegistro;
            return View(diario24);
        }

        public ActionResult Diario24Edit(int? id)
        {
            DiarioDieta24 diario24 = db.DiarioDieta24.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(diario24);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Diario24Edit(DiarioDieta24 diario24)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == diario24.idStatoRegistro);
                    db.Entry(diario24).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = diario24.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(diario24);
                }
            }
            return View(diario24);
        }


        /*ATTIVITA' FISICA */
        public ActionResult AttivitaFisicaCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttivitaFisicaCreate(AttivitaFisica attivitafisica)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce prelievo
                        attivitafisica.userName = User.Identity.Name;
                        attivitafisica.dataInserimento = DateTime.Now;
                        contextEF.AttivitaFisica.Add(attivitafisica);
                        contextEF.SaveChanges();

                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == attivitafisica.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(attivitafisica);
                    }
                }
            }
            ViewBag.idStatoRegistro = attivitafisica.idStatoRegistro;
            return View(attivitafisica);
        }

        public ActionResult AttivitaFisicaEdit(int? id)
        {
            AttivitaFisica attivitafisica = db.AttivitaFisica.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(attivitafisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttivitaFisicaEdit(AttivitaFisica attivitafisica)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == attivitafisica.idStatoRegistro);
                    db.Entry(attivitafisica).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = attivitafisica.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(attivitafisica);
                }
            }
            ViewBag.idStatoRegistro = attivitafisica.idStatoRegistro;
            return View(attivitafisica);
        }


        /*ANTROPOMETRIA*/
        public ActionResult AntropometriaCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AntropometriaCreate(Antropometria antropometria)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce prelievo
                        antropometria.userName = User.Identity.Name;
                        antropometria.dataInserimento = DateTime.Now;
                        contextEF.Antropometria.Add(antropometria);
                        contextEF.SaveChanges();

                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == antropometria.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(antropometria);
                    }
                }
            }
            ViewBag.idStatoRegistro = antropometria.idStatoRegistro;
            return View(antropometria);
        }

        public ActionResult AntropometriaEdit(int? id)
        {
            Antropometria antropometria = db.Antropometria.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(antropometria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AntropometriaEdit(Antropometria antropometria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == antropometria.idStatoRegistro);
                    db.Entry(antropometria).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = antropometria.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    ViewBag.idStatoRegistro = antropometria.idStatoRegistro;
                    return View(antropometria);
                }
            }
            ViewBag.idStatoRegistro = antropometria.idStatoRegistro;
            return View(antropometria);
        }

        /*TRATTAMENTI*/
        public ActionResult TrattamentiCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrattamentiCreate(Trattamenti trattamenti)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Se esiste già una scheda registrata 
                    //recupero dettaglio trattamenti ultima scheda
                    StatiRegistro sr = db.StatiRegistro.Find(trattamenti.idStatoRegistro);
                    var trattamentiFatti = (from t in db.Trattamenti
                                            join s in db.StatiRegistro on t.idStatoRegistro equals s.idStatoRegistro
                                            where t.StatiRegistro.idPaziente == sr.idPaziente
                                            orderby s.idStatoRegistro
                                            select t).ToList();
                    trattamenti.userName = User.Identity.Name;
                    trattamenti.dataInserimento = DateTime.Now;
                    db.Trattamenti.Add(trattamenti);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception se)
                    {
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        ViewBag.idStatoRegistro = trattamenti.idStatoRegistro;
                        return View(trattamenti);
                    }

                    //Avanza stato
                    AvanzamentoStato(trattamenti.idStatoRegistro);
                    db.SaveChanges();

                    if (trattamentiFatti.Count()>0){
                        int idSr = trattamentiFatti.Last().idStatoRegistro;
                        var ultimiTrattamentiDettaglio = (from td in db.TrattamentiDettaglio
                                                          where td.idStatoRegistro == idSr
                                                          select td).ToList();
                        foreach (var d in ultimiTrattamentiDettaglio)
                        {
                            TrattamentiDettaglio c = new TrattamentiDettaglio();
                            c.idStatoRegistro = trattamenti.idStatoRegistro;
                            c.tipoTrattamento = d.tipoTrattamento;
                            c.doseGiornaliera = d.doseGiornaliera;
                            c.tipoTrattamentoAltro = d.tipoTrattamentoAltro;
                            c.trattamento        =   d.trattamento;
                            c.motivo             =   d.motivo;
                            c.durata = d.durata;
                            db.TrattamentiDettaglio.Add(c);
                            try {                     
                                db.SaveChanges();
                            }
                            catch (Exception se)
                            {
                                ModelState.AddModelError("", se.GetBaseException().Message);
                                ViewBag.idStatoRegistro = trattamenti.idStatoRegistro;
                                return View(trattamenti);
                            }
                        }
                    }
                    return RedirectToAction("TrattamentiEdit", "Studio", new { id = trattamenti.StatiRegistro.idStatoRegistro });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    ViewBag.idStatoRegistro = trattamenti.idStatoRegistro;
                    return View(trattamenti);
                }
            }
            ViewBag.idStatoRegistro = trattamenti.idStatoRegistro;
            return View(trattamenti);
        }

        public ActionResult TrattamentiEdit(int? id)
        {
            Trattamenti trattamenti = db.Trattamenti.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(trattamenti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrattamentiEdit(Trattamenti trattamenti)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == trattamenti.idStatoRegistro);
                    db.Entry(trattamenti).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = trattamenti.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    ViewBag.idStatoRegistro = trattamenti.idStatoRegistro;
                    return View(trattamenti);
                }
            }
            ViewBag.idStatoRegistro = trattamenti.idStatoRegistro;
            return View(trattamenti);
        }

        [ChildActionOnly]
        public ActionResult TrattamentiPartial(int id)
        {
            Trattamenti t = db.Trattamenti.Single(p => p.idStatoRegistro == id);
            var elencoTrattamenti = new List<dynamic>();
            var sel = (from p in db.TrattamentiDettaglio
                       join ft in db.LUTipoTrattamento on p.tipoTrattamento equals ft.idTipoTrattamento into ft
                       from t2 in ft.DefaultIfEmpty()
                       where p.idStatoRegistro == id
                       select new
                       {
                           idTrattamentoDettaglio = p.idTrattamentoDettaglio,
                           descrizioneTipoTrattamento = p.tipoTrattamentoAltro == null ? t2.tipoTrattamento  : t2.tipoTrattamento + " - " + p.tipoTrattamentoAltro,
                           trattamento = p.trattamento,
                           doseGiornaliera = p.doseGiornaliera,
                           motivo=p.motivo,
                           durata = p.durata
                       });
             
             foreach (var fr in sel)
             {
                 dynamic lt = new ListaTrattamenti();
                 lt.idTrattamentoDettaglio = fr.idTrattamentoDettaglio;
                 lt.descrizioneTipoTrattamento = fr.descrizioneTipoTrattamento;
                 lt.trattamento = fr.trattamento;
                 lt.doseGiornaliera = fr.doseGiornaliera;
                 lt.motivo=fr.motivo;
                 lt.durata = fr.durata;
                 elencoTrattamenti.Add(lt);
             }
             ViewBag.idStatoRegistro = id;
             return PartialView("TrattamentiPartial", elencoTrattamenti);
        }

        public ActionResult TrattamentiDettaglioCreate(int idStatoRegistro)
        {
            Trattamenti t = db.Trattamenti.Single(a => a.idStatoRegistro == idStatoRegistro);
            ViewBag.tipoTrattamento = new SelectList(db.LUTipoTrattamento, "idTipoTrattamento", "tipoTrattamento");
            var model = new TrattamentiDettaglio();
            model.idStatoRegistro = t.idStatoRegistro;
            ViewBag.Paziente = t.StatiRegistro.Anagrafica.cognome + " " + t.StatiRegistro.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = t.StatiRegistro.Anagrafica.codPaziente;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrattamentiDettaglioCreate(TrattamentiDettaglio td)
        {
            if (ModelState.IsValid)
            {
                db.TrattamentiDettaglio.Add(td);
                db.SaveChanges();
                return RedirectToAction("TrattamentiEdit", "Studio", new { id = td.idStatoRegistro });
            }
            ViewBag.tipoTrattamento = new SelectList(db.LUTipoTrattamento, "idTipoTrattamento", "tipoTrattamento", td.idTrattamentoDettaglio);
            ViewBag.idStatoRegistro = td.idStatoRegistro;
            return View(td);
        }


        public ActionResult TrattamentiDettaglioEdit(int idTrattamentoDettaglio)
        {
            TrattamentiDettaglio td = db.TrattamentiDettaglio.Single(s => s.idTrattamentoDettaglio == idTrattamentoDettaglio);
            ViewBag.Paziente = td.Trattamenti.StatiRegistro.Anagrafica.cognome + " " + td.Trattamenti.StatiRegistro.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = td.Trattamenti.StatiRegistro.Anagrafica.codPaziente;
            }
            ViewBag.tipoTrattamento = new SelectList(db.LUTipoTrattamento, "idTipoTrattamento", "tipoTrattamento", td.tipoTrattamento);
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(td.Trattamenti.StatiRegistro.idPaziente);
            return View(td);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrattamentiDettaglioEdit(TrattamentiDettaglio td)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("TrattamentiEdit", "Studio", new { id = td.idStatoRegistro });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    ViewBag.idStatoRegistro = td.idStatoRegistro;
                    return View(td);
                }
            }
            ViewBag.idStatoRegistro = td.idStatoRegistro;
            return View(td);
        }




        public ActionResult TrattamentiDettaglioDelete(int idTrattamentoDettaglio)
        {
            TrattamentiDettaglio td = db.TrattamentiDettaglio.Single(s => s.idTrattamentoDettaglio == idTrattamentoDettaglio);
            db.TrattamentiDettaglio.Remove(td);
            db.SaveChanges();
            return RedirectToAction("TrattamentiEdit", "Studio", new { id = td.idStatoRegistro });
        }

        /*VALUTAZIONE METFORMINA*/
        public ActionResult ValutazioneCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValutazioneCreate(ValutazioneMetformina valutazione)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce prelievo
                        valutazione.userName = User.Identity.Name;
                        valutazione.dataInserimento = DateTime.Now;
                        contextEF.ValutazioneMetformina.Add(valutazione);
                        contextEF.SaveChanges();

                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == valutazione.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(valutazione);
                    }
                }
            }
            ViewBag.idStatoRegistro = valutazione.idStatoRegistro;
            return View(valutazione);
        }

        public ActionResult ValutazioneEdit(int? id)
        {
            ValutazioneMetformina valutazione = db.ValutazioneMetformina.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(valutazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValutazioneEdit(ValutazioneMetformina valutazione)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == valutazione.idStatoRegistro);
                    db.Entry(valutazione).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = valutazione.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(valutazione);
                }
            }
            return View(valutazione);
        }

        /*PRELIEVO*/
        public ActionResult PrelievoCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrelievoCreate(Prelievo prelievo)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce prelievo
                        prelievo.userName = User.Identity.Name;
                        prelievo.dataInserimento = DateTime.Now;
                        contextEF.Prelievo.Add(prelievo);
                        contextEF.SaveChanges();
                        
                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == prelievo.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(prelievo);
                    }
                }
            }
            ViewBag.idStatoRegistro = prelievo.idStatoRegistro;
            return View(prelievo);
        }

        public ActionResult PrelievoEdit(int? id)
        {
            ViewBag.Disable = false;
            Prelievo prelievo = db.Prelievo.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //Disabilita aggiornamento se randomizzato e 
            if (sr.StatiElenco.descrizione == "prelievo" && sr.Anagrafica.dataRandomizzazioneTrattamento != null)
            {
                ViewBag.Disable = true;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(prelievo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrelievoEdit(Prelievo prelievo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == prelievo.idStatoRegistro);
                    db.Entry(prelievo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = prelievo.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(prelievo);
                }
            }
            return View(prelievo);
        }



        /*MEDAS*/
        public ActionResult MedasCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = sc.Anagrafica.cognome + " " + sc.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MedasCreate(MEDAS medas)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = contextEF.Database.BeginTransaction())
                {
                    try
                    {
                        //Inserisce medas
                        medas.userName = User.Identity.Name;
                        medas.dataInserimento = DateTime.Now;
                        contextEF.MEDAS.Add(medas);
                        contextEF.SaveChanges();

                        //Avanza stato
                        // 1 aggiorno stato corrente - chiudo
                        StatiRegistro statoCorrente = contextEF.StatiRegistro.Single(s => s.idStatoRegistro == medas.idStatoRegistro);
                        statoCorrente.DataChiusura = DateTime.Now;
                        statoCorrente.Completamento = true;
                        // 2 aggiungo nuovo stato
                        StatiRegistro next = new StatiRegistro();
                        next.idPaziente = statoCorrente.idPaziente;
                        next.idStato = statoCorrente.idStato + 1;
                        next.Completamento = false;
                        next.DataApertura = DateTime.Now;
                        contextEF.StatiRegistro.Add(next);
                        contextEF.SaveChanges();

                        transaction.Commit();

                        return RedirectToAction("Paziente", "Studio", new { idPaziente = statoCorrente.idPaziente });
                    }
                    catch (Exception se)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", se.GetBaseException().Message);
                        return View(medas);
                    }
                }
            }
            ViewBag.idStatoRegistro = medas.idStatoRegistro;
            return View(medas);
        }

        public ActionResult MEDASEdit(int? id)
        {
            ViewBag.Disable = false;
            MEDAS medas = db.MEDAS.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //Disabilita aggiornamento se randomizzato e 
            if (sr.StatiElenco.descrizione == "medas" && sr.Anagrafica.dataRandomizzazioneTrattamento != null)
            {
                ViewBag.Disable = true;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(medas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MEDASEdit(MEDAS medas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == medas.idStatoRegistro);
                    db.Entry(medas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = medas.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(medas);
                }
            }
            return View(medas);
        }




        /*DROP*/
        public ActionResult DropCreate(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            ViewBag.idStatoRegistro = sc.idStatoRegistro;
            ViewBag.Paziente = "paziente " + "MINT" + String.Format("{0:00000}", sc.Anagrafica.idPaziente); ;
            if (!User.IsInRole("audit"))
            {
                ViewBag.Paziente = sc.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            List<SelectListItem> items = new SelectList(db.LUDropMotivazioni, "idMotivazione", "Motivazione").ToList();
            items.Insert(0, (new SelectListItem { Text = "-- seleziona motivazione --", Value = null }));
            ViewBag.idMotivazione = items;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropCreate(Drop drop)
        {
            List<SelectListItem> items = new SelectList(db.LUDropMotivazioni, "idMotivazione", "Motivazione").ToList();
            items.Insert(0, (new SelectListItem { Text = "-- seleziona motivazione --", Value = null }));
            ViewBag.idMotivazione = items;

            if (drop.outcomePrimario == 2)
            {
                //drop.tumore = 0;
                //drop.cardiovascolare = 0;
                //drop.diabeteTipo2 = 0;
                //drop.altre = 0;

                //ModelState.Remove("tumore");
                //ModelState.Remove("cardiovascolare");
                //ModelState.Remove("diabeteTipo2");
                //ModelState.Remove("altre");

                //ModelState.Remove("dataDiagnosiPrincipale");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //REGISTRAZIONE  stato drop
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = ChiusuraPerDrop(drop.idStatoRegistro, drop) });
                }

                catch (DbEntityValidationException EFex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in EFex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
                    ViewBag.idPaziente = drop.StatiRegistro.idPaziente;
                    return View(drop);
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    ViewBag.idPaziente = drop.StatiRegistro.idPaziente;
                    return View(drop);
                }
            }
            ViewBag.idStatoRegistro = drop.idStatoRegistro;
            var p = db.StatiRegistro.Single(u => u.idStatoRegistro == drop.idStatoRegistro);
            ViewBag.idPaziente = p.idPaziente;
            return View(drop);
        }
        
        public ActionResult DropEdit(int id)
        {
            ViewBag.Disable = false;
            StatiRegistro sr = db.StatiRegistro.Find(id);
            Drop drop = db.Drop.Single(x=>x.idStatoRegistro==id);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = sr.Anagrafica.idPaziente;

            List<SelectListItem> items = new SelectList(db.LUDropMotivazioni, "idMotivazione", "motivazione", drop.idMotivazione).ToList();
            items.Insert(0, (new SelectListItem { Text = "-- seleziona motivazione --", Value = null }));
            ViewBag.idMotivazione = items;
            return View(drop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropEdit(Drop drop)
        {
            List<SelectListItem> items = new SelectList(db.LUDropMotivazioni, "idMotivazione", "motivazione", drop.idMotivazione).ToList();
            items.Insert(0, (new SelectListItem { Text = "-- seleziona motivazione --", Value = null }));
            ViewBag.iDdMotivazione = items;

            if (ModelState.IsValid)
            {
                try
                {
                    var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == drop.idStatoRegistro);
                    db.Entry(drop).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Paziente", "Studio", new { idPaziente = drop.StatiRegistro.idPaziente });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(drop);
                }
            }
            ViewBag.idPaziente = drop.StatiRegistro.idPaziente;
            return View(drop);
        }

        /*RANDOMIZZAZIONE*/
        public ActionResult RandomizzazioneCreate(int idPaziente)
        {
            Eleggibilità m = new Eleggibilità();
            Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == idPaziente);
            m.idPaziente = idPaziente;
            m.sesso = SessoPaziente(idPaziente);
            //Antropometria PER ELEGIBILTA'  idStato=4 
            //da 2017/12/14
            //Antropometria PER ELEGIBILTA'  idStato=5
            StatiRegistro sa = db.StatiRegistro.Single(ant => ant.idStato == 5 && ant.idPaziente == idPaziente);
            Antropometria antropometria = db.Antropometria.Single(x => x.idStatoRegistro == sa.idStatoRegistro);
            //Prelievo PER ELEGIBILTA'  idStato=5
            //da 2017/12/14
            //Prelievo PER ELEGIBILTA'  idStato=6
            StatiRegistro sp = db.StatiRegistro.Single(ant => ant.idStato == 6 && ant.idPaziente == idPaziente);
            Prelievo prelievo = db.Prelievo.Single(x => x.idStatoRegistro == sp.idStatoRegistro);
            //Prelievo VALUTAZIONE METFORMINA  idStato=7
            //da 2017/12/14
            //Prelievo VALUTAZIONE METFORMINA'  idStato=8
            StatiRegistro sv = db.StatiRegistro.Single(ant => ant.idStato == 8 && ant.idPaziente == idPaziente);
            ValutazioneMetformina valutazione = db.ValutazioneMetformina.Single(x => x.idStatoRegistro == sv.idStatoRegistro);

            //FATTORI INCLUSIONE
            //1 ETA'
            int age = DateTime.Today.Year - Convert.ToDateTime(paziente.datanascita).Year;
            m.eta = age;
            //Correzione dopo emendamento del 28/02/2017
            //m.etaCheck = age >= 55 && age <= 80;
            //m.etaCheck = age >= 50 && age <= 79;
            //Correzione del 23/06/2017
            m.etaCheck = age >= 50 && age <= 80;
            //2 CIRCONFERENZA VITA
            m.circonferenzaVita = antropometria.circonferenzaVita;
            m.circonferenzaVitaCheck = false;
            if (SessoPaziente(idPaziente) == "F")
            {
                if (Convert.ToInt32(antropometria.circonferenzaVita) >= 85)
                {
                    m.circonferenzaVitaCheck = true;
                }
            }
            if (SessoPaziente(idPaziente) == "M")
            {
                if (Convert.ToInt32(antropometria.circonferenzaVita) >= 100)
                {
                    m.circonferenzaVitaCheck = true;
                }
            }
            //3 PRESSIONE arteriosa O terapiaIpertensione
            m.pressione = antropometria.pressioneMin.ToString() + "/" + antropometria.pressioneMax.ToString();
            m.pressioneCheck = false;
            m.ipertensioneCheck = antropometria.terapiaIpertensione;
            if ((antropometria.pressioneMin >= 85 && antropometria.pressioneMax >= 130) || antropometria.terapiaIpertensione)
            {
                m.pressioneCheck = true;
            }
            //4 GLICEMIA
            m.glicemia = prelievo.glicemia;
            m.glicemiaCheck = false;
            if (prelievo.glicemia >= 100 && prelievo.glicemia <= 126)
            {
                m.glicemiaCheck = true;
            }
            //5 TRIGLICERIDI O terapia Ipertrigliceridemia
            m.trigliceridi = prelievo.trigliceridi;
            m.trigliceridiCheck = false;
            m.ipertrigliceridemiaCheck = antropometria.terapiaIpertrigliceridemia;
            if (prelievo.trigliceridi >= 150 || antropometria.terapiaIpertrigliceridemia)
            {
                m.trigliceridiCheck = true;
            }
            //6 COLESTEROLO  o terapia Ipercolesterolemia
            //modifica del 3/6/2015
            m.colesteroloHDL = prelievo.HDL;
            m.colesterolemia = prelievo.colesterolemia;
            m.colesteroloHDLCheck = false;
            m.ipercolesterolemiaCheck = antropometria.terapiaIpercolesterolemia;
            if (SessoPaziente(idPaziente) == "F")
            {
                if (prelievo.HDL < 50 || antropometria.terapiaIpercolesterolemia || prelievo.colesterolemia>200)
                {
                    m.colesteroloHDLCheck = true;
                }
            }
            if (SessoPaziente(idPaziente) == "M")
            {
                if (prelievo.HDL < 40 || antropometria.terapiaIpercolesterolemia || prelievo.colesterolemia > 200)
                {
                    m.colesteroloHDLCheck = true;
                }
            }

            //FATTORI ESCLUSIONE
            //1 Effetti collaterali alla metformina
            m.effettiCollateraliCheck = valutazione.effettiCollaterali;
            //2 creatinine sierica >1,4 MG/DL
            m.creatininemia = prelievo.creatininemia;
            m.creatininemiaCheck = false;
            if (prelievo.creatininemia > 1.4M)
            {
                m.creatininemiaCheck = true;
            }

            //verifica disponibilità minima
            var flaconiIdParameter = new SqlParameter();
            flaconiIdParameter.ParameterName = "@flaconi";
            flaconiIdParameter.Direction = ParameterDirection.Output;
            flaconiIdParameter.SqlDbType = SqlDbType.Int;
            var disponibili = context.Database.ExecuteSqlCommand("sp_disponibilitaMinima @flaconi OUT",
            flaconiIdParameter);

            //se inferiore a 2 blocca
            ViewBag.AssegnazioneBloccata = false;
            if ((int)flaconiIdParameter.Value < 2)
            {
                ViewBag.AssegnazioneBloccata = true;
            }

            return View(m);
        }

        public ActionResult Randomizza(int idPaziente)
        {
            //verifica che non sia stato randomizzato
            Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == idPaziente);
            if (paziente.randomizzazioneTrattamento == null) { 

                //1 aggiungo PRIMA fase assegnazione
                AssegnazioniRegistro randomizzazione = new AssegnazioniRegistro();
                randomizzazione.idPaziente = idPaziente;
                randomizzazione.idAssegnazioneElenco = 1;
                randomizzazione.Completamento = true;
                randomizzazione.DataApertura = DateTime.Now;
                randomizzazione.DataChiusura = DateTime.Now;
                db.AssegnazioniRegistro.Add(randomizzazione);
                db.SaveChanges();

                //2 randomizzazione tremite StoreProcedure SQL
                StatiRegistro sc = StatoCorrente(idPaziente);
                AssegnazioniRegistro sr = StatoRandomizzazione(idPaziente);
                var randomizza = context.Database.ExecuteSqlCommand("sp_RandomizzazioneFarmaco @idPaziente, @idAssegnazioneElenco, @utente",
                new SqlParameter("@idPaziente", idPaziente),
                new SqlParameter("@idAssegnazioneElenco", sr.idAssegnazioneElenco),
                new SqlParameter("@utente", User.Identity.Name));
            
                //3 aggiorno stato corrente e avanzo di uno step
                sc.DataChiusura = DateTime.Now;
                sc.Completamento = true;
                //Avanza stato
                StatiRegistro next = new StatiRegistro();
                next.idPaziente = idPaziente;
                next.idStato = sc.idStato + 1;
                next.Completamento = false;
                next.DataApertura = DateTime.Now;
                db.StatiRegistro.Add(next);

                //4 REGISTRO ASSEGNAZIONI avanzamento
                AssegnazioniRegistro nextFarmaco = new AssegnazioniRegistro();
                nextFarmaco.idPaziente = idPaziente;
                nextFarmaco.idAssegnazioneElenco = sr.idAssegnazioneElenco + 1;
                nextFarmaco.Completamento = false;
                nextFarmaco.DataApertura = DateTime.Now;
                db.AssegnazioniRegistro.Add(nextFarmaco);

                db.SaveChanges();
            }
            return RedirectToAction("Paziente", "Studio", new { idPaziente = idPaziente });
        }

        public ActionResult RandomizzazioneEdit(int? id)
        {
            StatiRegistro s = db.StatiRegistro.Find(id);

            Eleggibilità m = new Eleggibilità();
            Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == s.idPaziente);
            m.idPaziente = s.idPaziente;
            m.sesso = SessoPaziente(s.idPaziente);
            //Antropometria PER ELEGIBILTA'  idStato=4
            StatiRegistro sa = db.StatiRegistro.Single(ant => ant.idStato == 5 && ant.idPaziente == s.idPaziente);
            Antropometria antropometria = db.Antropometria.Single(x => x.idStatoRegistro == sa.idStatoRegistro);
            //Prelievo PER ELEGIBILTA'  idStato=5
            StatiRegistro sp = db.StatiRegistro.Single(ant => ant.idStato == 6 && ant.idPaziente == s.idPaziente);
            Prelievo prelievo = db.Prelievo.Single(x => x.idStatoRegistro == sp.idStatoRegistro);
            //Prelievo VALUTAZIONE METFORMINA  idStato=7
            StatiRegistro sv = db.StatiRegistro.Single(ant => ant.idStato == 8 && ant.idPaziente == s.idPaziente);
            ValutazioneMetformina valutazione = db.ValutazioneMetformina.Single(x => x.idStatoRegistro == sv.idStatoRegistro);

            //FATTORI INCLUSIONE
            //1 ETA'
            int age = DateTime.Today.Year - Convert.ToDateTime(paziente.datanascita).Year;
            m.eta = age;
            m.etaCheck = age >= 55 && age <= 80;
            //2 CIRCONFERENZA VITA
            m.circonferenzaVita = antropometria.circonferenzaVita;
            m.circonferenzaVitaCheck = false;
            if (SessoPaziente(s.idPaziente) == "F")
            {
                if (Convert.ToInt32(antropometria.circonferenzaVita) >= 85)
                {
                    m.circonferenzaVitaCheck = true;
                }
            }
            if (SessoPaziente(s.idPaziente) == "M")
            {
                if (Convert.ToInt32(antropometria.circonferenzaVita) >= 100)
                {
                    m.circonferenzaVitaCheck = true;
                }
            }
            //3 PRESSIONE arteriosa O terapiaIpertensione
            m.pressione = antropometria.pressioneMin.ToString() + "/" + antropometria.pressioneMax.ToString();
            m.pressioneCheck = false;
            m.ipertensioneCheck = antropometria.terapiaIpertensione;
            if ((antropometria.pressioneMin >= 85 && antropometria.pressioneMax >= 130) || antropometria.terapiaIpertensione)
            {
                m.pressioneCheck = true;
            }
            //4 GLICEMIA
            m.glicemia = prelievo.glicemia;
            m.glicemiaCheck = false;
            if (prelievo.glicemia >= 100 && prelievo.glicemia <= 126)
            {
                m.glicemiaCheck = true;
            }
            //5 TRIGLICERIDI O terapia Ipertrigliceridemia
            m.trigliceridi = prelievo.trigliceridi;
            m.trigliceridiCheck = false;
            m.ipertrigliceridemiaCheck = antropometria.terapiaIpertrigliceridemia;
            if (prelievo.trigliceridi >= 150 || antropometria.terapiaIpertrigliceridemia)
            {
                m.trigliceridiCheck = true;
            }
            //6 COLESTEROLO  o terapia Ipercolesterolemia
            //modifica del 3/6/2015
            m.colesteroloHDL = prelievo.HDL;
            m.colesterolemia = prelievo.colesterolemia;
            m.colesteroloHDLCheck = false;
            m.ipercolesterolemiaCheck = antropometria.terapiaIpercolesterolemia;
            if (SessoPaziente(s.idPaziente) == "F")
            {
                if (prelievo.HDL < 50 || antropometria.terapiaIpercolesterolemia || prelievo.colesterolemia > 200)
                {
                    m.colesteroloHDLCheck = true;
                }
            }
            if (SessoPaziente(s.idPaziente) == "M")
            {
                if (prelievo.HDL < 40 || antropometria.terapiaIpercolesterolemia || prelievo.colesterolemia > 200)
                {
                    m.colesteroloHDLCheck = true;
                }
            }

            //FATTORI ESCLUSIONE
            //1 Effetti collaterali alla metformina
            m.effettiCollateraliCheck = valutazione.effettiCollaterali;
            //2 creatinine sierica >1,4 MG/DL
            m.creatininemia = prelievo.creatininemia;
            m.creatininemiaCheck = false;
            if (prelievo.creatininemia > 1.4M)
            {
                m.creatininemiaCheck = true;
            }
            return View(m);

        }

        /*POSTRandomizzazione SCHEDE */
        public ActionResult AssegnazioneFarmacoCreate(int idPaziente)
        {
            var scf = StatoCorrenteFarmaco(idPaziente);
            ViewBag.idAssegnazioneRegistro = scf.idAssegnazioneRegistro;
            ViewBag.Paziente = scf.Anagrafica.cognome + " " + scf.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = scf.Anagrafica.codPaziente;
            }
            ViewBag.idPaziente = idPaziente;
            ViewBag.Fase = scf.AssegnazioniElenco.descrizione;
            ViewBag.Posologia = scf.AssegnazioniElenco.mezzoDosaggio == true ? scf.AssegnazioniElenco.posologiaFlaconi : scf.AssegnazioniElenco.posologiaFlaconi + " - SOLO DOSAGGIO PIENO";
            ViewBag.FlaconiDosaggioPieno = scf.AssegnazioniElenco.dosaggioPieno;
            ViewBag.FlaconiMezzoDosaggio = scf.AssegnazioniElenco.mezzoDosaggio == true ? Convert.ToInt32(scf.AssegnazioniElenco.dosaggioPieno/2) : scf.AssegnazioniElenco.dosaggioPieno;
            ViewBag.ConsenteMezzoDosaggio = scf.AssegnazioniElenco.mezzoDosaggio;
            ViewBag.ProssimoRitiro = DateTime.Today.AddMonths(scf.AssegnazioniElenco.dosaggioPieno);

            //verifica disponibilità minima
            var flaconiIdParameter = new SqlParameter();
            flaconiIdParameter.ParameterName = "@flaconi";
            flaconiIdParameter.Direction = ParameterDirection.Output;
            flaconiIdParameter.SqlDbType = SqlDbType.Int;
            var disponibili = context.Database.ExecuteSqlCommand("sp_disponibilitaMinima @flaconi OUT",
            flaconiIdParameter);
            
            //se inferiore a 6 blocca
            ViewBag.AssegnazioneBloccata = false;
            if ((int)flaconiIdParameter.Value < 6) {
                ViewBag.AssegnazioneBloccata =true;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssegnazioneFarmacoCreate(AssegnazioneFarmaco assegnazione)
        {
            try
            {
                AssegnazioniRegistro a = db.AssegnazioniRegistro.Single(ar => ar.idAssegnazioneRegistro == assegnazione.idAssegnazioneRegistro);
                //1 Registra dati assegnazione

                assegnazione.userName = User.Identity.Name;
                assegnazione.dataInserimento = DateTime.Now;
                db.AssegnazioneFarmaco.Add(assegnazione);

                ////2 assegnazione flaconi postrandomizzazione tramite StoreProcedure SQL
                //AssegnazioniRegistro scf = StatoCorrenteFarmaco(assegnazione.AssegnazioniRegistro.idPaziente);
                var assegna = context.Database.ExecuteSqlCommand("sp_AssegnazioniPostRandomizzazione @idPaziente, @utente, @idAssegnazioneElenco,@numFlaconi,@dataConsegna,@dosaggio",
                new SqlParameter("@idPaziente", a.idPaziente),
                new SqlParameter("@idAssegnazioneElenco", assegnazione.AssegnazioniRegistro.AssegnazioniElenco.idAssegnazioneElenco),
                new SqlParameter("@utente", User.Identity.Name),
                new SqlParameter("@numFlaconi", assegnazione.flaconiAssegnati),
                new SqlParameter("@dataConsegna", assegnazione.dataConsegna),
                new SqlParameter("@dosaggio", assegnazione.dosaggioPieno));

                //3 Chiusura Stato corrente
                assegnazione.AssegnazioniRegistro.DataChiusura = DateTime.Now;
                assegnazione.AssegnazioniRegistro.Completamento = true;
                //
                ////4 REGISTRO ASSEGNAZIONI avanzo 
                AssegnazioniRegistro nextFarmaco = new AssegnazioniRegistro();
                nextFarmaco.idPaziente = assegnazione.AssegnazioniRegistro.idPaziente;
                nextFarmaco.idAssegnazioneElenco = assegnazione.AssegnazioniRegistro.idAssegnazioneElenco + 1;
                nextFarmaco.Completamento = false;
                nextFarmaco.DataApertura = DateTime.Now;
                db.AssegnazioniRegistro.Add(nextFarmaco);
                db.SaveChanges();

                return RedirectToAction("Paziente", "Studio", new { idPaziente = a.idPaziente });
            }

            catch (DbEntityValidationException EFex)
            {
                StringBuilder sb = new StringBuilder();


                foreach (var failure in EFex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                ViewBag.idPaziente = assegnazione.AssegnazioniRegistro.idPaziente;
                ViewBag.FlaconiDosaggioPieno = assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno;
                ViewBag.FlaconiMezzoDosaggio = assegnazione.AssegnazioniRegistro.AssegnazioniElenco.mezzoDosaggio == true ? Convert.ToInt32(assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno / 2) : assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno;
                ViewBag.ConsenteMezzoDosaggio = assegnazione.AssegnazioniRegistro.AssegnazioniElenco.mezzoDosaggio;
                ViewBag.ProssimoRitiro = DateTime.Today.AddMonths(assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno);
                return View(assegnazione);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.GetBaseException().Message);
                ViewBag.idPaziente = assegnazione.AssegnazioniRegistro.idPaziente;
                ViewBag.FlaconiDosaggioPieno = assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno;
                ViewBag.FlaconiMezzoDosaggio = assegnazione.AssegnazioniRegistro.AssegnazioniElenco.mezzoDosaggio == true ? Convert.ToInt32(assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno / 2) : assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno;
                ViewBag.ConsenteMezzoDosaggio = assegnazione.AssegnazioniRegistro.AssegnazioniElenco.mezzoDosaggio;
                ViewBag.ProssimoRitiro = DateTime.Today.AddMonths(assegnazione.AssegnazioniRegistro.AssegnazioniElenco.dosaggioPieno);
                return View(assegnazione);
            }


        }

        public ActionResult AssegnazioneFarmacoEdit(int? id)
        {
            AssegnazioneFarmaco assegnazionefarmaco = db.AssegnazioneFarmaco.Find(id);
            StatiRegistro sr = db.StatiRegistro.Find(id + 1);
            ViewBag.Paziente = sr.Anagrafica.cognome + " " + sr.Anagrafica.nome;
            if (User.IsInRole("audit"))
            {
                ViewBag.Paziente = sr.Anagrafica.codPaziente;
            }
            //verifica DROP
            ViewBag.idDrop = IsPazienteDrop(sr.idPaziente);
            return View(assegnazionefarmaco);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AttivitaFisicaEdit(AttivitaFisica attivitafisica)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var idPaziente = db.StatiRegistro.Single(u => u.idStatoRegistro == attivitafisica.idStatoRegistro);
        //            db.Entry(attivitafisica).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Paziente", "Studio", new { idPaziente = attivitafisica.StatiRegistro.idPaziente });
        //        }
        //        catch (Exception se)
        //        {
        //            ModelState.AddModelError("", se.GetBaseException().Message);
        //            return View(attivitafisica);
        //        }
        //    }
        //    ViewBag.idStatoRegistro = attivitafisica.idStatoRegistro;
        //    return View(attivitafisica);
        //}





        public ActionResult DateFlaconi(int idPaziente, int nFlaconi, string pc, string dc, int dp)
        {
            var lista = db.sp_AssegnazioniPostRandomizzazioneDateScadenza(idPaziente, nFlaconi, Convert.ToDateTime(dc), dp);
            StringBuilder sb = new StringBuilder();
            DateTime prossimaConsegna = Convert.ToDateTime(pc);
            DateTime dataConsegna = Convert.ToDateTime(dc);
            DateTime copertura = dataConsegna;
            int c = 1;

            foreach (var f in lista)
            {
                if (dp == 1)
                {
                    copertura = copertura.AddMonths(1);
                }
                else
                {
                    //doppio dosaggio
                    copertura = copertura.AddMonths(2);
                }

                sb.Append("kit: " + f.kit.ToString());
                sb.Append(", copertura fino: " + copertura.ToShortDateString());
                if (f.ScadenzaFarmaco.Value > copertura)
                {
                    sb.Append(" - scadenza: " + f.ScadenzaFarmaco.Value.ToShortDateString());
                }
                else
                {
                    sb.Append(" - scadenza: <span style='color:red;'>" + f.ScadenzaFarmaco.Value.ToShortDateString() + "</span>");
                }

                sb.Append("</br>");
                c++;
            }
            //string scadenze = System.Web.HttpUtility.HtmlEncode(sb);
            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);
            
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public ActionResult _HistorySchede(int id)
        {
            var elencoStati = from s in db.StatiRegistro
                              where s.idPaziente == id && s.Completamento == true
                              orderby s.idStato
                              select s;
            dynamic ListaStati = new List<StatiListato>();

            foreach (var ec in elencoStati)
            {
                dynamic c = new StatiListato();

                c.idStatoRegistro = ec.idStatoRegistro;
                c.registrazione = (DateTime)ec.DataChiusura;
                switch (ec.StatiElenco.descrizioneForm)
                {
                    case "Antropometria":
                        c.compilazione = ec.Antropometria.data;
                        break;
                    case "AttivitaFisica":
                        c.compilazione = ec.AttivitaFisica.data;
                        break;
                    //case "Chiusura studio":
                    //    c.compilazione = ec.DataChiusura;
                    //    break;
                    case "Diario24":
                        c.compilazione = ec.DiarioDieta24.data;
                        break;
                    //case "Drop":
                    //    c.compilazione = ec.DataChiusura;
                    //    break;
                    case "Prelievo":
                        c.compilazione = ec.Prelievo.data;
                        break;
                    //case "Randomizzazione":
                    //    c.compilazione = null;
                    //    break;
                    case "StileVita":
                        c.compilazione = ec.StileDiVita.data;
                        break;
                    case "Trattamenti":
                        c.compilazione = ec.Trattamenti.data;
                        break;
                    case "Valutazione":
                        c.compilazione = ec.ValutazioneMetformina.dataConsegna;
                        break;
                    default:
                        c.compilazione = (DateTime)ec.DataChiusura;
                        break;
                }

                c.descrizioneFase = ec.StatiElenco.descrizione;
                c.descrizioneForm = ec.StatiElenco.descrizioneForm;
                ListaStati.Add(c);

            }

            return View(ListaStati);
        }

        /*GESTIONE STATI*/
        public StatiRegistro StatoCorrente(int idPaziente)
        {
            StatiRegistro sc = new StatiRegistro();
            var statoCorrente = from s in db.StatiRegistro
                                where s.idPaziente == idPaziente && s.Completamento == false
                                select s;
            if(statoCorrente.Count()==1){
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


        public int FlaconiAssegnati(int idPaziente, string tipo)
        {
            int fa = 0;
            int c = 1;
            var elencoConsegne = db.AssegnazioniRegistro
                                .Include(s => s.AssegnazioniElenco)
                                .Include(f => f.AssegnazioneFarmaco)
                                .Where(u => u.idPaziente == idPaziente && u.Completamento == true);
            var numeroConsegne = elencoConsegne.Count();
            foreach (var ec in elencoConsegne)
            {
                if (ec.idAssegnazioneElenco == 1)
                {
                    fa = 1; //randomizzazione dosaggio PIENO
                }
                else
                {
                    fa += ec.AssegnazioneFarmaco.flaconiAssegnati;
                }

                if (numeroConsegne==c && tipo=="inCarico")
                {
                    if (ec.idAssegnazioneElenco == 1)
                    {
                        fa = 1; //randomizzazione dosaggio PIENO
                    }
                    else
                    {
                        fa = ec.AssegnazioneFarmaco.flaconiAssegnati;
                    }
                }
                c++;
            }
            return fa;
        }

        public AssegnazioniRegistro StatoRandomizzazione(int idPaziente)
        {
            AssegnazioniRegistro sr = new AssegnazioniRegistro();
            var statoRandomizzazione = from s in db.AssegnazioniRegistro
                                 where s.idPaziente == idPaziente && s.idAssegnazioneElenco == 1
                                 select s;
            if (statoRandomizzazione.Count() == 1)
            {
                sr = db.AssegnazioniRegistro.Single(u => u.idPaziente == idPaziente && u.idAssegnazioneElenco == 1);
            }
            return sr;
        }

        public void AvanzamentoStato(int idStatoRegistro)
        {

            //aggiorno stato corrente
            StatiRegistro current = db.StatiRegistro.Single(s => s.idStatoRegistro == idStatoRegistro);
            current.DataChiusura = DateTime.Now;
            current.Completamento = true;
            //aggiungo nuovo stato
            StatiRegistro next = new StatiRegistro();
            next.idPaziente = current.idPaziente;
            next.idStato = current.idStato + 1;
            next.Completamento = false;
            next.DataApertura = DateTime.Now;
            db.StatiRegistro.Add(next);
            //2016-19-11: Spostato per gestire transazione
            //db.SaveChanges();
        }

        public int ChiusuraPerDrop(int idStatoRegistro, Drop sd)
        {
            //Chiudo fase corrente
            //StatiRegistro current = db.StatiRegistro.Single(s => s.idStatoRegistro == idStatoRegistro);
            //current.DataChiusura = DateTime.Now;
            //current.Completamento = true;
            //CANCELLO fase corrente
            StatiRegistro current = db.StatiRegistro.Single(s => s.idStatoRegistro == idStatoRegistro);
            db.StatiRegistro.Remove(current);
            db.SaveChanges();
            //aggiungo stato DROP
            StatiRegistro d = new StatiRegistro();
            d.idPaziente = current.idPaziente;
            d.idStato = 99;
            d.Completamento = false;
            d.DataApertura = DateTime.Now;
            d.DataChiusura = DateTime.Now;
            d.Completamento = true;
            db.StatiRegistro.Add(d);
            db.SaveChanges();
            //aggiungo DROP
            sd.userName = User.Identity.Name;
            sd.dataInserimento = DateTime.Now;
            sd.idStatoRegistro = d.idStatoRegistro;
            db.Drop.Add(sd);
            db.SaveChanges();
            //aggiungo CHIUSURA
            StatiRegistro c = new StatiRegistro();
            c.idPaziente = current.idPaziente;
            c.idStato = 100;
            c.Completamento = false;
            c.DataApertura = DateTime.Now;
            c.DataChiusura = DateTime.Now;
            c.Completamento=false; //lascio aperto per far funzionare correttamente statoCompletamento
            db.StatiRegistro.Add(c);
            //Cancello stato corrente
            //db.StatiRegistro.Remove(current);
            db.SaveChanges();
            return c.idPaziente;
        }

        bool IsPazienteDrop(int idPaziente) {
            int regDrop = (from d in db.StatiRegistro
                              where d.idStato == 100 &&d.idPaziente==idPaziente
                              select d).Count();
            if (regDrop==1)
            {
                return true;
            }
            return false;
        }


        public string SessoPaziente(int idPaziente)
        {
            var sc = StatoCorrente(idPaziente);
            int sessoCF = Convert.ToInt16(sc.Anagrafica.cfiscale.Substring(9, 2));
            if (sessoCF > 0 && sessoCF <= 31)
            {
                return "M";
            }
            else if (sessoCF > 40 && sessoCF <= 71)
            {
                return "F";
            }
            else
            {
                return "?";
            }
        }

        public ActionResult _Paziente(int idPaziente)
        {
            var model = new Anagrafica();
            model.idPaziente = idPaziente;
            return View(model);
        }


        //conteggio SAE
        public int SAECount(int idPaziente)
        {
            int nSAE = 0;
            nSAE = (from sr in db.SAE
                    where sr.idPaziente == idPaziente
                    select sr).Count();
            return nSAE;
        }

        //conteggio AE
        public int AECount(int idPaziente)
        {
            int nAE = 0;
            nAE = (from sr in db.AE
                    where sr.idPaziente == idPaziente
                    select sr).Count();
            return nAE;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public struct DateTimeSpan
        {
            private readonly int years;
            private readonly int months;
            private readonly int days;
            private readonly int hours;
            private readonly int minutes;
            private readonly int seconds;
            private readonly int milliseconds;

            public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
            {
                this.years = years;
                this.months = months;
                this.days = days;
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
                this.milliseconds = milliseconds;
            }

            public int Years { get { return years; } }
            public int Months { get { return months; } }
            public int Days { get { return days; } }
            public int Hours { get { return hours; } }
            public int Minutes { get { return minutes; } }
            public int Seconds { get { return seconds; } }
            public int Milliseconds { get { return milliseconds; } }

            enum Phase { Years, Months, Days, Done }

            public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
            {
                if (date2 < date1)
                {
                    var sub = date1;
                    date1 = date2;
                    date2 = sub;
                }

                DateTime current = date1;
                int years = 0;
                int months = 0;
                int days = 0;

                Phase phase = Phase.Years;
                DateTimeSpan span = new DateTimeSpan();

                while (phase != Phase.Done)
                {
                    switch (phase)
                    {
                        case Phase.Years:
                            if (current.AddYears(years + 1) > date2)
                            {
                                phase = Phase.Months;
                                current = current.AddYears(years);
                            }
                            else
                            {
                                years++;
                            }
                            break;
                        case Phase.Months:
                            if (current.AddMonths(months + 1) > date2)
                            {
                                phase = Phase.Days;
                                current = current.AddMonths(months);
                            }
                            else
                            {
                                months++;
                            }
                            break;
                        case Phase.Days:
                            if (current.AddDays(days + 1) > date2)
                            {
                                current = current.AddDays(days);
                                var timespan = date2 - current;
                                span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                                phase = Phase.Done;
                            }
                            else
                            {
                                days++;
                            }
                            break;
                    }
                }

                return span;
            }
        }

    }
}
