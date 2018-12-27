using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace MeMeMe.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
    public class ReclutamentoController : Controller
    {
        private MeMeMeEntities db = new MeMeMeEntities();

        // GET: /Reclutamento/
        public ActionResult Index(FormCollection collection)
        {
            bool tipoP = Convert.ToBoolean(collection["tipoP"]);
            var anagrafiche = new List<dynamic>();
            IEnumerable<Anagrafica> anagrafica = new List<Anagrafica>();

            if (collection["search"] == null)
            {
                if (tipoP)
                {
                    anagrafica = db.Anagrafica
                        .Include(a => a.LUIParentela)
                        .Include(a => a.LUIstruzione)
                        .Include(a => a.LUProfessione)
                        .Include(a => a.LUStatoCivile);
                }
                else
                {
                    anagrafica = from a in db.Anagrafica
                                 where !(from sr in db.StatiRegistro
                                         join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
                                         select sr.idPaziente).Contains(a.idPaziente)
                                 select a;
                }

                foreach (var fr in anagrafica)
                {
                    Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == fr.idPaziente);
                    dynamic a = new AnagraficheList();
                    a.idPaziente = fr.idPaziente;
                    a.idMeMeMe = "MINT" + String.Format("{0:00000}", fr.idPaziente);
                    a.paziente = fr.cognome + " " + fr.nome;
                    a.cfiscale = fr.cfiscale;
                    if (User.IsInRole("audit"))
                    {
                        a.paziente = "dettaglio scheda";
                        a.cfiscale = System.Text.RegularExpressions.Regex.Replace(fr.cfiscale, ".", "*");
                    }
                    
                    if (fr.famiglia == 0)
                    {
                        a.tipoPaziente = "Probando/a";
                    }
                    else
                    {
                        //verifico ORFANO (cancellazione probanda)
                        var probanda = (from p in db.Anagrafica
                                        where p.idPaziente == paziente.famiglia
                                        select p).FirstOrDefault();

                        if (probanda != null)
                        {
                            Anagrafica famiglia = db.Anagrafica.Single(fam => fam.idPaziente == paziente.famiglia);
                            a.tipoPaziente = paziente.LUIParentela.parentela + " " + famiglia.cognome.ToLower() + " " + famiglia.nome.ToLower();
                            if (User.IsInRole("audit"))
                            {
                                a.tipoPaziente = paziente.LUIParentela.parentela;
                            }
                        }
                        else
                        {
                            a.tipoPaziente = paziente.LUIParentela.parentela + " - ORFANO di ID " + paziente.idPaziente + " - ritirata.";
                        }
                    }
                    a.randomizzazioneDieta = fr.randomizzazioneDieta;
                    anagrafiche.Add(a);
                }
            }
            else
            {
                string s = collection["search"];
                if (tipoP)
                {
                    if (!User.IsInRole("audit"))
                    {
                        anagrafica = (from a in db.Anagrafica.Include(a => a.LUIParentela).Include(a => a.LUIstruzione).Include(a => a.LUProfessione).Include(a => a.LUStatoCivile)
                                      where (a.cognome.Contains(s) || a.nome.Contains(s) || a.cfiscale == s || a.codPaziente.Contains(s))
                                      select a);
                    }
                    else
                    {
                        anagrafica = (from a in db.Anagrafica.Include(a => a.LUIParentela).Include(a => a.LUIstruzione).Include(a => a.LUProfessione).Include(a => a.LUStatoCivile)
                                      where (a.codPaziente.Contains(s))
                                      select a);
                    }
                }
                else
                {
                    if (!User.IsInRole("audit"))
                    {
                        anagrafica = from a in db.Anagrafica
                                     where !(from sr in db.StatiRegistro
                                             join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
                                             select sr.idPaziente).Contains(a.idPaziente)
                                             && (a.cognome.Contains(s) || a.nome.Contains(s) || a.cfiscale == s || a.codPaziente.Contains(s))
                                     select a;
                    }
                    else
                    {
                        anagrafica = from a in db.Anagrafica
                                     where !(from sr in db.StatiRegistro
                                             join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
                                             select sr.idPaziente).Contains(a.idPaziente)
                                             && (a.codPaziente.Contains(s))
                                     select a;
                    }
                }

                foreach (var fr in anagrafica)
                {
                    Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == fr.idPaziente);
                    dynamic a = new AnagraficheList();
                    a.idPaziente = fr.idPaziente;
                    a.idMeMeMe = "MINT" + String.Format("{0:00000}", fr.idPaziente);
                    a.paziente = fr.cognome + " " + fr.nome;
                    a.cfiscale = fr.cfiscale;
                    if (User.IsInRole("audit"))
                    {
                        a.paziente = "dettaglio scheda";
                        a.cfiscale = System.Text.RegularExpressions.Regex.Replace(fr.cfiscale, ".", "*");
                    }
                    
                    if (fr.famiglia == 0)
                    {
                        a.tipoPaziente = "Probando/a";
                    }
                    else
                    {
                        //verifico ORFANO (cancellazione probanda)
                        var probanda = (from p in db.Anagrafica
                                        where p.idPaziente == paziente.famiglia
                                        select p).FirstOrDefault();

                        if (probanda != null)
                        {
                            Anagrafica famiglia = db.Anagrafica.Single(fam => fam.idPaziente == paziente.famiglia);
                            a.tipoPaziente = paziente.LUIParentela.parentela + " " + famiglia.cognome.ToLower() + " " + famiglia.nome.ToLower();
                            if (User.IsInRole("audit"))
                            {
                                a.tipoPaziente = paziente.LUIParentela.parentela;
                            }
                        }
                        else
                        {
                            a.tipoPaziente = paziente.LUIParentela.parentela + " - ORFANO di ID " + paziente.idPaziente + " - ritirata.";
                        }
                    }
                    a.randomizzazioneDieta = fr.randomizzazioneDieta;
                    anagrafiche.Add(a);
                }
            }
            ViewBag.casi = anagrafica.Count();
            ViewBag.search = collection["search"];
            ViewBag.tipoP = collection["tipoP"];
            if (String.IsNullOrEmpty(collection["tipoP"]))
            {
                ViewBag.tipoP = "false";
            }
            return View(anagrafiche);
        }

        // GET: /Reclutamento/Create
        public ActionResult AnagraficaCreate()
        {
            var famiglie = new List<dynamic>();
            var fam = (from an in db.Anagrafica
                       where an.famiglia == 0
                       select new
                       {
                           idPaziente = an.idPaziente
                           ,
                           paziente = an.cognome.ToLower() + " " + an.nome.ToLower() + " (" + an.cfiscale.ToUpper() + ")"
                       });

            FamiglieList f0 = new FamiglieList { famiglia = 0, famigliaDescrizione = "Probando/a" };
            famiglie.Add(f0);
            foreach (var fr in fam)
            {
                dynamic f = new FamiglieList();
                f.famiglia = fr.idPaziente;
                f.famigliaDescrizione = fr.paziente;
                famiglie.Add(f);
            }
            ViewBag.parentela = new SelectList(db.LUIParentela, "idParentela", "parentela");
            ViewBag.istruzione = new SelectList(db.LUIstruzione, "idIstruzione", "istruzione");
            ViewBag.professione = new SelectList(db.LUProfessione, "idProfessione", "professione");
            ViewBag.statocivile = new SelectList(db.LUStatoCivile, "idStatoCivile", "statocivile");
            ViewBag.famiglia = new SelectList(famiglie.ToList(), "famiglia", "famigliaDescrizione");
            var model = new Anagrafica();
            return View(model);
        }

        // POST: /Reclutamento/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnagraficaCreate(Anagrafica anagrafica)
        {
            //genera combo famiglia
            var famiglie = new List<dynamic>();
            var fam = (from an in db.Anagrafica
                       where an.famiglia == 0
                       select new
                       {
                           idPaziente = an.idPaziente
                           ,
                           paziente = an.cognome.ToLower() + " " + an.nome.ToLower() + " (" + an.cfiscale.ToUpper() + ")"
                       });
            FamiglieList f0 = new FamiglieList { famiglia = 0, famigliaDescrizione = "Probando/a" };
            famiglie.Add(f0);
            foreach (var fr in fam)
            {
                dynamic f = new FamiglieList();
                f.famiglia = fr.idPaziente;
                f.famigliaDescrizione = fr.paziente;
                famiglie.Add(f);
            }
            //valida e registra
            if (ModelState.IsValid)
            {
                try
                {
                    anagrafica.userName = User.Identity.Name;
                    anagrafica.data = DateTime.Now;
                    anagrafica.sesso = SessoPaziente(anagrafica.cfiscale);
                    db.Anagrafica.Add(anagrafica);
                    db.SaveChanges();
                    //Avvia studio
                    AvvioStudio(anagrafica.idPaziente);
                    return RedirectToAction("Index");
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
                        return View(EFex);
                    }
                }
                catch (Exception aex)
                {
                    System.Diagnostics.Debug.WriteLine("errore nell acreazione anagrafica: " + aex.Message);
                    ModelState.AddModelError("", aex.GetBaseException().Message);
                    //ripristina combo
                    ViewBag.parentela = new SelectList(db.LUIParentela, "idParentela", "parentela", anagrafica.parentela);
                    ViewBag.istruzione = new SelectList(db.LUIstruzione, "idIstruzione", "istruzione", anagrafica.istruzione);
                    ViewBag.professione = new SelectList(db.LUProfessione, "idProfessione", "professione", anagrafica.professione);
                    ViewBag.statocivile = new SelectList(db.LUStatoCivile, "idStatoCivile", "statocivile", anagrafica.statocivile);
                    ViewBag.famiglia = new SelectList(famiglie.ToList(), "famiglia", "famigliaDescrizione");
                    return View(anagrafica);
                }
            }
            ViewBag.parentela = new SelectList(db.LUIParentela, "idParentela", "parentela", anagrafica.parentela);
            ViewBag.istruzione = new SelectList(db.LUIstruzione, "idIstruzione", "istruzione", anagrafica.istruzione);
            ViewBag.professione = new SelectList(db.LUProfessione, "idProfessione", "professione", anagrafica.professione);
            ViewBag.statocivile = new SelectList(db.LUStatoCivile, "idStatoCivile", "statocivile", anagrafica.statocivile);
            ViewBag.famiglia = new SelectList(famiglie.ToList(), "famiglia", "famigliaDescrizione");
            return View(anagrafica);
        }

        // GET: /Reclutamento/Edit/5
        public ActionResult AnagraficaEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Anagrafica anagrafica = db.Anagrafica.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }


            // INTESTAZIONE PAZIENTE
            string tipoPaziente = "";
            if (anagrafica.famiglia == 0)
            {
                tipoPaziente = "Probanda";
            }
            else
            {
                Anagrafica famiglia = db.Anagrafica.Single(fam => fam.idPaziente == anagrafica.famiglia);
                LUIParentela parentela = db.LUIParentela.Single(fam => fam.idParentela == anagrafica.parentela);
                tipoPaziente = parentela.parentela + " " + famiglia.cognome.ToLower() + " " + famiglia.nome.ToLower();
            }
            var c = (from comuni in db.Comuni
                     where comuni.ProvinciaSigla == anagrafica.provincia
                     select comuni).ToList();
            ViewData["comune"] = new SelectList(c, "CodiceComune", "Comune", anagrafica.comune);
            ViewBag.istruzione = new SelectList(db.LUIstruzione, "idIstruzione", "istruzione", anagrafica.istruzione);
            ViewBag.professione = new SelectList(db.LUProfessione, "idProfessione", "professione", anagrafica.professione);
            ViewBag.statocivile = new SelectList(db.LUStatoCivile, "idStatoCivile", "statocivile", anagrafica.statocivile);
            ViewData["R1"] = "id " + anagrafica.idPaziente;
            ViewData["R2"] = tipoPaziente;

            return View(anagrafica);
        }

        // POST: /Reclutamento/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnagraficaEdit(Anagrafica anagrafica)
        {
            var c = (from comuni in db.Comuni
                     where comuni.ProvinciaSigla == anagrafica.provincia
                     select comuni).ToList();
            // INTESTAZIONE PAZIENTE
            string tipoPaziente = "";
            if (anagrafica.famiglia == 0)
            {
                tipoPaziente = "Probanda";
            }
            else
            {
                Anagrafica famiglia = db.Anagrafica.Single(fam => fam.idPaziente == anagrafica.famiglia);
                LUIParentela parentela = db.LUIParentela.Single(fam => fam.idParentela == anagrafica.parentela);
                tipoPaziente = parentela.parentela + " " + famiglia.cognome.ToLower() + " " + famiglia.nome.ToLower();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(anagrafica).State = EntityState.Modified;
                    anagrafica.sesso = SessoPaziente(anagrafica.cfiscale);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
                        return View(EFex);
                    }
                }

                catch (Exception aex)
                {
                    System.Diagnostics.Debug.WriteLine("errore nell acreazione anagrafica: " + aex.Message);
                    ModelState.AddModelError("", aex.GetBaseException().Message);
                    ViewData["comune"] = new SelectList(c, "CodiceComune", "Comune", anagrafica.comune);
                    ViewBag.istruzione = new SelectList(db.LUIstruzione, "idIstruzione", "istruzione", anagrafica.istruzione);
                    ViewBag.professione = new SelectList(db.LUProfessione, "idProfessione", "professione", anagrafica.professione);
                    ViewBag.statocivile = new SelectList(db.LUStatoCivile, "idStatoCivile", "statocivile", anagrafica.statocivile);
                    ViewData["R1"] = "id " + anagrafica.idPaziente;
                    ViewData["R2"] = tipoPaziente;
                    return View(anagrafica);
                }
            }
            ViewData["comune"] = new SelectList(c, "CodiceComune", "Comune", anagrafica.comune);
            ViewBag.istruzione = new SelectList(db.LUIstruzione, "idIstruzione", "istruzione", anagrafica.istruzione);
            ViewBag.professione = new SelectList(db.LUProfessione, "idProfessione", "professione", anagrafica.professione);
            ViewBag.statocivile = new SelectList(db.LUStatoCivile, "idStatoCivile", "statocivile", anagrafica.statocivile);
            ViewData["R1"] = "id " + anagrafica.idPaziente;
            ViewData["R2"] = tipoPaziente;
            return View(anagrafica);
        }

        // GET: /Reclutamento/Delete/5
        public ActionResult AnagraficaDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagrafica anagrafica = db.Anagrafica.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica);
        }

        // POST: /Reclutamento/Delete/5
        [HttpPost, ActionName("AnagraficaDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AnagraficaDeleteConfirmed(int id)
        {
            Anagrafica anagrafica = db.Anagrafica.Find(id);
            db.Anagrafica.Remove(anagrafica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Comuni(string provincia)
        {
            if (provincia != "")
            {
                var query = (from comunui in db.Comuni
                             where comunui.ProvinciaSigla == provincia
                             select new { value = comunui.CodiceComune, text = comunui.Comune }
                                );
                return Json(query, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var query = (from comunui in db.Comuni
                             select new { value = comunui.CodiceComune, text = comunui.Comune }
                                );
                return Json(query, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult cfUnivoco(string cfiscale)
        {
            //SOLO SU CREATE
            HttpContextBase x = this.HttpContext;
            var anagrafica = from a in db.Anagrafica
                             where a.cfiscale == cfiscale
                             select a;
            if (x.Request.UrlReferrer.AbsoluteUri.Contains("Create"))
            {
                if (anagrafica.Count() != 0)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public void AvvioStudio(int idPaziente)
        {
            //aggiungo nuovo stato
            StatiRegistro avvio = new StatiRegistro();
            avvio.idPaziente = idPaziente;
            avvio.idStato = 1;
            avvio.Completamento = false;
            avvio.DataApertura = DateTime.Now;
            db.StatiRegistro.Add(avvio);
            db.SaveChanges();
        }

        public ActionResult _Paziente(int idPaziente)
        {
            var model = new Anagrafica();
            model.idPaziente = idPaziente;
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string SessoPaziente(string CF)
        {
            int sessoCF = Convert.ToInt16(CF.Substring(9, 2));
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
    }
}
