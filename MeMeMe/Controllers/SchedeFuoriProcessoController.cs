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
using System.Data.Entity.Infrastructure;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;

namespace MeMeMe.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
    public class SchedeFuoriProcessoController : Controller
    {
        private MeMeMeEntities db = new MeMeMeEntities();

        // GET: /Reclutamento/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _SAE()
        {
            var sae = db.SAE.ToList();
            dynamic ListaSAE = new List<SAEListato>();
            List<string> listaGravità = new List<string>();
            listaGravità.Add("1 Mild");
            listaGravità.Add("2 Moderate");
            listaGravità.Add("3 Severe");
            listaGravità.Add("4 Life-threatening");
            listaGravità.Add("5 Fatal");
            foreach (var ec in sae)
            {
                dynamic c = new SAEListato();
                c.trialCode = "MINT" + String.Format("{0:00000}", ec.idPaziente);
                c.idSAE = ec.idSAE;
                c.idPaziente = ec.idPaziente;
                c.dataSAE = (DateTime)ec.dataSAE;
                c.gravita = listaGravità[ec.gravita-1];
                ListaSAE.Add(c);
            }
            return View(ListaSAE);
        }

        public ActionResult _AE()
        {
            var ae = db.AE.ToList();
            dynamic ListaAE = new List<AEListato>();
            foreach (var ec in ae)
            {
                dynamic c = new AEListato();
                c.trialCode = "MINT" + String.Format("{0:00000}", ec.idPaziente);
                c.idAE = ec.idAE;
                c.idPaziente = ec.idPaziente;
                c.dataAE = (DateTime)ec.dataAE;
                c.nEventi = db.AEDettaglio.Count(a=>a.idAE == ec.idAE);
                ListaAE.Add(c);
            }
            return View(ListaAE);
        }


        // GET: /Reclutamento/Create
        public ActionResult SAECreate()
        {
            var trialCodeList = new List<dynamic>();
            //var anagrafica = db.Anagrafica.ToList();
            var anagrafica = from a in db.Anagrafica
                         //where !(from sr in db.StatiRegistro
                         //        join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
                         //        select sr.idPaziente).Contains(a.idPaziente)
                         select a;
            TrailCodeList f0 = new TrailCodeList { idPaziente = 0, trialCode = "selezionare trial code" };
            trialCodeList.Add(f0);
            foreach (var tc in anagrafica)
            {
                dynamic t = new TrailCodeList();
                t.idPaziente = tc.idPaziente;
                t.trialCode = "MINT" + String.Format("{0:00000}", tc.idPaziente);
                trialCodeList.Add(t);
            }
            ViewBag.trialCode = new SelectList(trialCodeList.ToList(), "idPaziente", "trialCode");
            var model = new SAE();
            return View(model);
        }

        // POST: /Reclutamento/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SAECreate(SAE sae)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    sae.userName = User.Identity.Name;
                    sae.dataInserimento = DateTime.Now;
                    db.SAE.Add(sae);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(sae);
                }
            }
            return View(sae);
        }

        // GET: /Reclutamento/Edit/5
        public ActionResult SAEEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SAE sae = db.SAE.Find(id);
            if (sae == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPaziente = sae.idPaziente;
            var trialCodeList = new List<dynamic>();
            TrailCodeList f0 = new TrailCodeList { idPaziente = sae.idPaziente, trialCode = "MINT" + String.Format("{0:00000}", sae.idPaziente)};
            trialCodeList.Add(f0);
            ViewBag.trialCode = new SelectList(trialCodeList, "idPaziente", "trialCode", sae.idPaziente);
            return View(sae);
        }

        // POST: /Reclutamento/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SAEEdit(SAE sae)
        {
            var trialCodeList = new List<dynamic>();
            TrailCodeList f0 = new TrailCodeList { idPaziente = sae.idPaziente, trialCode = "MINT" + String.Format("{0:00000}", sae.idPaziente) };
            trialCodeList.Add(f0);

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(sae).State = EntityState.Modified;
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
                    }
                    ViewBag.trialCode = new SelectList(trialCodeList, "idPaziente", "trialCode", sae.idPaziente);
                    return View(sae);
                }
                catch (DbUpdateConcurrencyException DCE)
                {
                    System.Diagnostics.Debug.WriteLine("errore: " + DCE.Message);
                    ModelState.AddModelError("", DCE.GetBaseException().Message);
                    ViewBag.trialCode = new SelectList(trialCodeList, "idPaziente", "trialCode", sae.idPaziente);
                    return View(sae);
                }

                catch (Exception aex)
                {
                    System.Diagnostics.Debug.WriteLine("errore: " + aex.Message);
                    ModelState.AddModelError("", aex.GetBaseException().Message);
                    ViewBag.trialCode = new SelectList(trialCodeList, "idPaziente", "trialCode", sae.idPaziente);
                    return View(sae);
                }
            }

            ViewBag.trialCode = new SelectList(trialCodeList, "idPaziente", "trialCode", sae.idPaziente);
            return View(sae);
        }

        // GET: /Reclutamento/Delete/5
        public ActionResult SAEDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAE sae = db.SAE.Find(id);
            if (sae == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrialCode = "MINT" + String.Format("{0:00000}", sae.idPaziente);
            dynamic ListaSAE = new List<SAEListato>();
            List<string> listaGravità = new List<string>();
            listaGravità.Add("1 Mild");
            listaGravità.Add("2 Moderate");
            listaGravità.Add("3 Severe");
            listaGravità.Add("4 Life-threatening");
            listaGravità.Add("5 Fatal");
            ViewBag.DataSae = sae.dataSAE.ToShortDateString();
            ViewBag.Gravita = listaGravità[sae.gravita];
            return View(sae);
        }

        // POST: /Reclutamento/Delete/5
        [HttpPost, ActionName("SAEDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SAEDeleteConfirmed(int id)
        {
            SAE sae = db.SAE.Find(id);
            db.SAE.Remove(sae);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /Reclutamento/Create
        public ActionResult AECreate()
        {
            var trialCodeList = new List<dynamic>();
            //var anagrafica = db.Anagrafica.ToList();
            var anagrafica = from a in db.Anagrafica
                             //where !(from sr in db.StatiRegistro
                             //        join d in db.Drop on sr.idStatoRegistro equals d.idStatoRegistro
                             //        select sr.idPaziente).Contains(a.idPaziente)
                             select a;
            TrailCodeList f0 = new TrailCodeList { idPaziente = 0, trialCode = "selezionare trial code" };
            trialCodeList.Add(f0);
            foreach (var tc in anagrafica)
            {
                dynamic t = new TrailCodeList();
                t.idPaziente = tc.idPaziente;
                t.trialCode = "MINT" + String.Format("{0:00000}", tc.idPaziente);
                trialCodeList.Add(t);
            }
            ViewBag.trialCode = new SelectList(trialCodeList.ToList(), "idPaziente", "trialCode");
            var model = new AE();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AECreate(AE ae)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ae.userName = User.Identity.Name;
                    ae.dataInserimento = DateTime.Now;
                    db.AE.Add(ae);
                    db.SaveChanges();
                    return RedirectToAction("AEEdit", "SchedeFuoriProcesso", new { id = ae.idAE });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    return View(ae);
                }
            }
            return View(ae);
        }

        public ActionResult AEEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AE ae = db.AE.Find(id);
            if (ae == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPaziente = ae.idPaziente;
            var trialCodeList = new List<dynamic>();
            TrailCodeList f0 = new TrailCodeList { idPaziente = ae.idPaziente, trialCode = "MINT" + String.Format("{0:00000}", ae.idPaziente) };
            trialCodeList.Add(f0);
            ViewBag.trialCode = new SelectList(trialCodeList, "idPaziente", "trialCode", ae.idPaziente);
            return View(ae);
        }

        [ChildActionOnly]
        public ActionResult AEPartial(int id)
        {
            AE ae = db.AE.Single(p => p.idAE == id);
            var elencoAE = new List<dynamic>();
            var sel = (from p in db.AEDettaglio
                       join lu1 in db.LUAE_TipoEvento on p.tipoEvento equals lu1.idAETipoEvento into lu1
                       from tlu1 in lu1.DefaultIfEmpty()
                       join lu2 in db.LUAE_Grado on p.serietaGrado equals lu2.idAEGrado into lu2
                       from tlu2 in lu2.DefaultIfEmpty()
                       join lu3 in db.LUAE_Outcome on p.outcome equals lu3.idAEOutcome into lu3
                       from tlu3 in lu3.DefaultIfEmpty()
                       where p.idAE == id
                       select new
                       {
                           idAEDettaglio = p.idAEDettaglio,
                           descrizioneTipoEvento = p.tipoEventoAltro == null ? tlu1.TipoEvento : tlu1.TipoEvento + " - " + p.tipoEventoAltro,
                           serietaEvento = p.serietaEvento == 1 ? "si" :  "no",
                           reazioneFarmaco = p.reazioneFarmaco == 1 ? "si" :  "no",
                           serietaGrado = tlu2.grado,
                           dataInizio = p.dataInizio,
                           dataFine = p.dataFine,
                           outcome = tlu3.outcome
                       });
        
            foreach (var x in sel)
            {
                dynamic lt = new AEDettaglioListato();
                lt.idAEDettaglio = x.idAEDettaglio;
                lt.tipoEvento = x.descrizioneTipoEvento;
                lt.serietaEvento = x.serietaEvento;
                lt.reazioneFarmaco = x.reazioneFarmaco;
                lt.serietaGrado = x.serietaGrado;
                lt.dataInizio = x.dataInizio.ToShortDateString();
                lt.dataFine = x.dataFine == null ? "" : x.dataFine.Value.ToShortDateString();
                lt.outcome = x.outcome;
                elencoAE.Add(lt);
            }
            ViewBag.idAE = id;
            return PartialView("AEPartial", elencoAE);
        }

        public ActionResult AEDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AE ae = db.AE.Find(id);
            if (ae == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrialCode = "MINT" + String.Format("{0:00000}", ae.idPaziente);
            dynamic ListaAE = new List<AEListato>();
            return View(ae);
        }

        // POST: /Reclutamento/Delete/5
        [HttpPost, ActionName("AEDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AEDeleteConfirmed(int id)
        {
            AE sae = db.AE.Find(id);
            db.AE.Remove(sae);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AEDettaglioCreate(int idAE)
        {
            AE t = db.AE.Single(a => a.idAE == idAE);
            List<SelectListItem> itemsTipoEvento = new SelectList(db.LUAE_TipoEvento, "idAETipoEvento", "TipoEvento").ToList();
            itemsTipoEvento.Insert(0, (new SelectListItem { Text = "-- selezione tipo --", Value = "" }));
            ViewBag.tipoEvento = itemsTipoEvento;

            List<SelectListItem> itemsSerietaGrado = new SelectList(db.LUAE_Grado, "idAEGrado", "grado").ToList();
            itemsSerietaGrado.Insert(0, (new SelectListItem { Text = "-- selezione grado --", Value = "" }));
            ViewBag.serietaGrado = itemsSerietaGrado;


            List<SelectListItem> itemsOutcome = new SelectList(db.LUAE_Outcome, "idAEOutcome", "outcome").ToList();
            itemsOutcome.Insert(0, (new SelectListItem { Text = "-- selezione outcome --", Value = "" }));
            ViewBag.outcome = itemsOutcome;

            string cognomeAnonimo = new String('*',  t.Anagrafica.cognome.Length - 1);
            string nomeAnonimo = new String('*', t.Anagrafica.nome.Length - 1);
            ViewBag.Paziente = t.Anagrafica.cognome.Substring(0, 1) + cognomeAnonimo + " " + t.Anagrafica.nome.Substring(0, 1) + nomeAnonimo;
            var model = new AEDettaglio();
            model.idAE = t.idAE;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AEDettaglioCreate(AEDettaglio aed)
        {
            List<SelectListItem> itemsTipoEvento = new SelectList(db.LUAE_TipoEvento, "idAETipoEvento", "TipoEvento").ToList();
            itemsTipoEvento.Insert(0, (new SelectListItem { Text = "-- selezione tipo --", Value = "" }));
            ViewBag.tipoEvento = itemsTipoEvento;

            List<SelectListItem> itemsSerietaGrado = new SelectList(db.LUAE_Grado, "idAEGrado", "grado").ToList();
            itemsSerietaGrado.Insert(0, (new SelectListItem { Text = "-- selezione grado --", Value = "" }));
            ViewBag.serietaGrado = itemsSerietaGrado;


            List<SelectListItem> itemsOutcome = new SelectList(db.LUAE_Outcome, "idAEOutcome", "outcome").ToList();
            itemsOutcome.Insert(0, (new SelectListItem { Text = "-- selezione outcome --", Value = "" }));
            ViewBag.outcome = itemsOutcome;

            if (ModelState.IsValid)
            {
                try { 
                    db.AEDettaglio.Add(aed);
                    db.SaveChanges();
                    return RedirectToAction("AEEdit", "SchedeFuoriProcesso", new { id = aed.idAE });
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
                    ViewBag.idAEDettaglio = aed.idAEDettaglio;
                    return View(aed);
                }
            }
            ViewBag.idAEDettaglio = aed.idAEDettaglio;
            return View(aed);
        }


        public ActionResult AEDettaglioEdit(int idAEDettaglio)
        {
            AEDettaglio aed = db.AEDettaglio.Single(s => s.idAEDettaglio == idAEDettaglio);
            string cognomeAnonimo = new String('*', aed.AE.Anagrafica.cognome.Length - 1);
            string nomeAnonimo = new String('*', aed.AE.Anagrafica.nome.Length - 1);
            ViewBag.Paziente = aed.AE.Anagrafica.cognome.Substring(0, 1) + cognomeAnonimo + " " + aed.AE.Anagrafica.nome.Substring(0, 1) + nomeAnonimo;

            List<SelectListItem> itemsTipoEvento = new SelectList(db.LUAE_TipoEvento, "idAETipoEvento", "TipoEvento", aed.tipoEvento).ToList();
            itemsTipoEvento.Insert(0, (new SelectListItem { Text = "-- selezione tipo --", Value = "" }));
            ViewBag.tipoEvento = itemsTipoEvento;

            List<SelectListItem> itemsSerietaGrado = new SelectList(db.LUAE_Grado, "idAEGrado", "grado", aed.serietaGrado).ToList();
            itemsSerietaGrado.Insert(0, (new SelectListItem { Text = "-- selezione grado --", Value = "" }));
            ViewBag.serietaGrado = itemsSerietaGrado;

            List<SelectListItem> itemsOutcome = new SelectList(db.LUAE_Outcome, "idAEOutcome", "outcome", aed.outcome).ToList();
            itemsOutcome.Insert(0, (new SelectListItem { Text = "-- selezione outcome --", Value = "" }));
            ViewBag.outcome = itemsOutcome;            

            return View(aed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AEDettaglioEdit(AEDettaglio aed)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(aed).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AEEdit", "SchedeFuoriProcesso", new { id = aed.idAE });
                }
                catch (Exception se)
                {
                    ModelState.AddModelError("", se.GetBaseException().Message);
                    ViewBag.idAEDettaglio = aed.idAEDettaglio;
                    return View(aed);
                }
            }
            ViewBag.idAEDettaglio = aed.idAEDettaglio;
            return View(aed);
        }


        public ActionResult AEDettaglioDelete(int idAEDettaglio)
        {
            AEDettaglio aed = db.AEDettaglio.Single(s => s.idAEDettaglio == idAEDettaglio);
            db.AEDettaglio.Remove(aed);
            db.SaveChanges();
            return RedirectToAction("AEEdit", "SchedeFuoriProcesso", new { id = aed.idAE });
        }

        public ActionResult SAEPrint(int? id)
        {

            SAE sae = db.SAE.Find(id);

            string pdfTemplate = Server.MapPath("~/Content/files/SAE_Initial_def.pdf");
            string newFile = Server.MapPath("~/Content/files/PrintSAE_Initial_def.pdf");

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;

            Anagrafica paziente = db.Anagrafica.Single(p => p.idPaziente == sae.idPaziente);
            //da antropometria
            string pesoPrimaAntropometria = "n.d.";
            string altezzaPrimaAntropometria = "n.d.";
            if (db.StatiRegistro.Where(ant => ant.idStato == 5 && ant.idPaziente == sae.idPaziente).Count() == 1)
            {
                StatiRegistro sa = db.StatiRegistro.Single(ant => ant.idStato == 5 && ant.idPaziente == sae.idPaziente); //PRIMA ANTROPOMETRIA
                Antropometria antropometria = db.Antropometria.Single(x => x.idStatoRegistro == sa.idStatoRegistro);
                pesoPrimaAntropometria = antropometria.peso.ToString();
                altezzaPrimaAntropometria = antropometria.altezza.ToString();
            }
            //da assegnazioni
            string dataAssegnazionePeriodoProva = "n.d.";
            if (db.AssegnazioniRegistro.Where(ar => ar.idAssegnazioneElenco == 2 && ar.idPaziente == sae.idPaziente).Count() == 1)
            {
                AssegnazioniRegistro r = db.AssegnazioniRegistro.Single(ar => ar.idAssegnazioneElenco == 2 && ar.idPaziente == sae.idPaziente);
                AssegnazioneFarmaco af = db.AssegnazioneFarmaco.Single(y => y.idAssegnazioneRegistro == r.idAssegnazioneRegistro);
                dataAssegnazionePeriodoProva = af.dataConsegna.ToShortDateString();
            }
            string cognomeAnonimo = new String('*', paziente.cognome.Length - 1);
            string nomeAnonimo = new String('*', paziente.nome.Length - 1);
            
            pdfFormFields.SetField("TrialCode",  "MINT" + String.Format("{0:00000}", sae.idPaziente));
            pdfFormFields.SetField("Age", (DateTime.Today.Year - Convert.ToDateTime(paziente.datanascita).Year).ToString());
            pdfFormFields.SetField("Weight", pesoPrimaAntropometria.ToString());
            pdfFormFields.SetField("Height", altezzaPrimaAntropometria.ToString());
            pdfFormFields.SetField("Gender", paziente.sesso);

            //1
            pdfFormFields.SetField("studyDrug", sae.studyDrug.ToString());
            pdfFormFields.SetField("dosaggio_1", sae.dosaggio==1 ? "Yes" : "No");
            pdfFormFields.SetField("dosaggio_2", sae.dosaggio==2 ? "Yes" : "No");
            pdfFormFields.SetField("assunzioneSAE",sae.assunzioneSAE.ToString());
            pdfFormFields.SetField("dataAssegnazionePeriodoProva",sae.dataAssegnazionePeriodoProva.ToShortDateString());
            pdfFormFields.SetField("dataUltimaAssunzione",sae.dataUltimaAssunzione.ToShortDateString());
            pdfFormFields.SetField("dataSAE",sae.dataSAE.ToShortDateString());
            pdfFormFields.SetField("diagnosi",sae.diagnosi.ToString());
            pdfFormFields.SetField("gravita_1",sae.gravita==1 ? "Yes" : "No");
            pdfFormFields.SetField("gravita_2",sae.gravita==2 ? "Yes" : "No");
            pdfFormFields.SetField("gravita_3",sae.gravita==3 ? "Yes" : "No");
            pdfFormFields.SetField("gravita_4",sae.gravita==4 ? "Yes" : "No");
            pdfFormFields.SetField("gravita_5",sae.gravita==5 ? "Yes" : "No");
            pdfFormFields.SetField("relazioneCausale_1", sae.relazioneCausale == 1 ? "Yes" : "No");
            pdfFormFields.SetField("relazioneCausale_2", sae.relazioneCausale == 2 ? "Yes" : "No");
            pdfFormFields.SetField("relazioneCausale_3", sae.relazioneCausale == 3 ? "Yes" : "No");
            pdfFormFields.SetField("relazioneCausale_4", sae.relazioneCausale == 4 ? "Yes" : "No");
            pdfFormFields.SetField("relazioneCausale_5", sae.relazioneCausale == 5 ? "Yes" : "No");
            pdfFormFields.SetField("azioneIntrapresa", sae.azioneIntrapresa.ToString());
            pdfFormFields.SetField("inizioSAE", sae.inizioSAE.ToShortDateString());
            pdfFormFields.SetField("fineSAE", sae.fineSAE==null ? "" : sae.fineSAE.Value.ToShortDateString());
            pdfFormFields.SetField("reazioneArresto_1", sae.reazioneArresto == 1 ? "Yes" : "No");
            pdfFormFields.SetField("reazioneArresto_2", sae.reazioneArresto == 2 ? "Yes" : "No");
            pdfFormFields.SetField("reazioneArresto_3", sae.reazioneArresto == 3 ? "Yes" : "No");
            pdfFormFields.SetField("risomministrazioneFarmaco_1", sae.risomministrazioneFarmaco == 1 ? "Yes" : "No");
            pdfFormFields.SetField("risomministrazioneFarmaco_2", sae.risomministrazioneFarmaco == 2 ? "Yes" : "No");
            pdfFormFields.SetField("dataRisomministrazioneFarmaco", sae.dataRisomministrazioneFarmaco == null ? "" : sae.dataRisomministrazioneFarmaco.Value.ToShortDateString());
            pdfFormFields.SetField("ripetizioneDopoRiassunzione_1", sae.ripetizioneDopoRiassunzione == 1 ? "Yes" : "No");
            pdfFormFields.SetField("ripetizioneDopoRiassunzione_2", sae.ripetizioneDopoRiassunzione == 2 ? "Yes" : "No");
            pdfFormFields.SetField("ripetizioneDopoRiassunzione_3", sae.ripetizioneDopoRiassunzione == 3 ? "Yes" : "No");
            pdfFormFields.SetField("risultato_1", sae.risultato == 1 ? "Yes" : "No");
            pdfFormFields.SetField("risultato_2", sae.risultato == 2 ? "Yes" : "No");
            pdfFormFields.SetField("risultato_3", sae.risultato == 3 ? "Yes" : "No");
            pdfFormFields.SetField("risultato_4", sae.risultato == 4 ? "Yes" : "No");
            pdfFormFields.SetField("eventoFatale_1", sae.eventoFatale == 1 ? "Yes" : "No");
            pdfFormFields.SetField("eventoFatale_2", sae.eventoFatale == 2 ? "Yes" : "No");
            pdfFormFields.SetField("eventoFatale_3", sae.eventoFatale == 3 ? "Yes" : "No");
            pdfFormFields.SetField("dataMorte", sae.dataMorte == null ? "" : sae.dataMorte.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaCausaSAE_1", sae.malattiaCausaSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaCausaSAE_2", sae.malattiaCausaSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaCausaSAE_3", sae.malattiaCausaSAE == 3 ? "Yes" : "No");

            pdfFormFields.SetField("concomitante1", sae.concomitante1 == null ? "" : sae.concomitante1.ToString());
            pdfFormFields.SetField("concomitante1Diagnosi", sae.concomitante1Diagnosi == null ? "" : sae.concomitante1Diagnosi.ToString());
            pdfFormFields.SetField("concomitante1DoseGG", sae.concomitante1DoseGG == null ? "" : sae.concomitante1DoseGG.ToString());
            pdfFormFields.SetField("concomitante1DaQuanto", sae.concomitante1DaQuanto == null ? "" : sae.concomitante1DaQuanto.ToString());
            pdfFormFields.SetField("concomitante1DataInzio", sae.concomitante1DataInzio == null ? "" : sae.concomitante1DataInzio.Value.ToShortDateString());
            pdfFormFields.SetField("concomitante1DataFine", sae.concomitante1DataFine == null ? "" : sae.concomitante1DataFine.Value.ToShortDateString());
            pdfFormFields.SetField("concomitante1InCorso_1", sae.concomitante1InCorso == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1InCorso_2", sae.concomitante1InCorso == 2 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1InCorso_3", sae.concomitante1InCorso == 3 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1CauseSAE_1",sae.concomitante1CauseSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1CauseSAE_2",sae.concomitante1CauseSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1CauseSAE_3",sae.concomitante1CauseSAE == 3 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1modificaConduzioneTrial_1", sae.concomitante1modificaConduzioneTrial == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante1modificaConduzioneTrial_2", sae.concomitante1modificaConduzioneTrial == 2 ? "Yes" : "No");

            pdfFormFields.SetField("concomitante2", sae.concomitante2 == null ? "" : sae.concomitante2.ToString());
            pdfFormFields.SetField("concomitante2Diagnosi", sae.concomitante2Diagnosi == null ? "" : sae.concomitante2Diagnosi.ToString());
            pdfFormFields.SetField("concomitante2DoseGG", sae.concomitante2DoseGG == null ? "" : sae.concomitante2DoseGG.ToString());
            pdfFormFields.SetField("concomitante2DaQuanto", sae.concomitante2DaQuanto == null ? "" : sae.concomitante2DaQuanto.ToString());
            pdfFormFields.SetField("concomitante2DataInzio", sae.concomitante2DataInzio == null ? "" : sae.concomitante2DataInzio.Value.ToShortDateString());
            pdfFormFields.SetField("concomitante2DataFine", sae.concomitante2DataFine == null ? "" : sae.concomitante2DataFine.Value.ToShortDateString());
            pdfFormFields.SetField("concomitante2InCorso_1", sae.concomitante2InCorso == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2InCorso_2", sae.concomitante2InCorso == 2 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2InCorso_3", sae.concomitante2InCorso == 3 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2CauseSAE_1", sae.concomitante2CauseSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2CauseSAE_2", sae.concomitante2CauseSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2CauseSAE_3", sae.concomitante2CauseSAE == 3 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2modificaConduzioneTrial_1", sae.concomitante2modificaConduzioneTrial == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante2modificaConduzioneTrial_2", sae.concomitante2modificaConduzioneTrial == 2 ? "Yes" : "No");

            pdfFormFields.SetField("concomitante3", sae.concomitante3 == null ? "" : sae.concomitante3.ToString());
            pdfFormFields.SetField("concomitante3Diagnosi", sae.concomitante3Diagnosi == null ? "" : sae.concomitante3Diagnosi.ToString());
            pdfFormFields.SetField("concomitante3DoseGG", sae.concomitante3DoseGG == null ? "" : sae.concomitante3DoseGG.ToString());
            pdfFormFields.SetField("concomitante3DaQuanto", sae.concomitante3DaQuanto == null ? "" : sae.concomitante3DaQuanto.ToString());
            pdfFormFields.SetField("concomitante3DataInzio", sae.concomitante3DataInzio == null ? "" : sae.concomitante3DataInzio.Value.ToShortDateString());
            pdfFormFields.SetField("concomitante3DataFine", sae.concomitante3DataFine == null ? "" : sae.concomitante3DataFine.Value.ToShortDateString());
            pdfFormFields.SetField("concomitante3InCorso_1", sae.concomitante3InCorso == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3InCorso_2", sae.concomitante3InCorso == 2 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3InCorso_3", sae.concomitante3InCorso == 3 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3CauseSAE_1", sae.concomitante3CauseSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3CauseSAE_2", sae.concomitante3CauseSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3CauseSAE_3", sae.concomitante3CauseSAE == 3 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3modificaConduzioneTrial_1", sae.concomitante3modificaConduzioneTrial == 1 ? "Yes" : "No");
            pdfFormFields.SetField("concomitante3modificaConduzioneTrial_2", sae.concomitante3modificaConduzioneTrial == 2 ? "Yes" : "No");

            pdfFormFields.SetField("malattiaAllergiaRischio1", sae.malattiaAllergiaRischio1 == null ? "" : sae.malattiaAllergiaRischio1.ToString());
            pdfFormFields.SetField("malattiaAllergiaRischio1DataInizio", sae.malattiaAllergiaRischio1DataInizio == null ? "" : sae.malattiaAllergiaRischio1DataInizio.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaAllergiaRischio1DataFine", sae.malattiaAllergiaRischio1DataFine == null ? "" : sae.malattiaAllergiaRischio1DataFine.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaAllergiaRischio1InCorso_1", sae.malattiaAllergiaRischio1InCorso == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio1InCorso_2", sae.malattiaAllergiaRischio1InCorso == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio1InCorso_3", sae.malattiaAllergiaRischio1InCorso == 3 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio1CausaPrimariaSAE_1", sae.malattiaAllergiaRischio1CausaPrimariaSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio1CausaPrimariaSAE_2", sae.malattiaAllergiaRischio1CausaPrimariaSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio1CausaPrimariaSAE_3", sae.malattiaAllergiaRischio1CausaPrimariaSAE == 3 ? "Yes" : "No");

            pdfFormFields.SetField("malattiaAllergiaRischio2", sae.malattiaAllergiaRischio2 == null ? "" : sae.malattiaAllergiaRischio2.ToString());
            pdfFormFields.SetField("malattiaAllergiaRischio2DataInizio", sae.malattiaAllergiaRischio2DataInizio == null ? "" : sae.malattiaAllergiaRischio2DataInizio.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaAllergiaRischio2DataFine", sae.malattiaAllergiaRischio2DataFine == null ? "" : sae.malattiaAllergiaRischio2DataFine.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaAllergiaRischio2InCorso_1", sae.malattiaAllergiaRischio2InCorso == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio2InCorso_2", sae.malattiaAllergiaRischio2InCorso == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio2InCorso_3", sae.malattiaAllergiaRischio2InCorso == 3 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio2CausaPrimariaSAE_1", sae.malattiaAllergiaRischio2CausaPrimariaSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio2CausaPrimariaSAE_2", sae.malattiaAllergiaRischio2CausaPrimariaSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio2CausaPrimariaSAE_3", sae.malattiaAllergiaRischio2CausaPrimariaSAE == 3 ? "Yes" : "No");

            pdfFormFields.SetField("malattiaAllergiaRischio3", sae.malattiaAllergiaRischio3 == null ? "" : sae.malattiaAllergiaRischio3.ToString());
            pdfFormFields.SetField("malattiaAllergiaRischio3DataInizio", sae.malattiaAllergiaRischio3DataInizio == null ? "" : sae.malattiaAllergiaRischio3DataInizio.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaAllergiaRischio3DataFine", sae.malattiaAllergiaRischio3DataFine == null ? "" : sae.malattiaAllergiaRischio3DataFine.Value.ToShortDateString());
            pdfFormFields.SetField("malattiaAllergiaRischio3InCorso_1", sae.malattiaAllergiaRischio3InCorso == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio3InCorso_2", sae.malattiaAllergiaRischio3InCorso == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio3InCorso_3", sae.malattiaAllergiaRischio3InCorso == 3 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio3CausaPrimariaSAE_1", sae.malattiaAllergiaRischio3CausaPrimariaSAE == 1 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio3CausaPrimariaSAE_2", sae.malattiaAllergiaRischio3CausaPrimariaSAE == 2 ? "Yes" : "No");
            pdfFormFields.SetField("malattiaAllergiaRischio3CausaPrimariaSAE_3", sae.malattiaAllergiaRischio3CausaPrimariaSAE == 3 ? "Yes" : "No");

            pdfFormFields.SetField("osservazioni", sae.osservazioni.ToString());

            //pdfStamper.FormFlattening = true;
            pdfStamper.FormFlattening = true;
            pdfStamper.AcroFields.GenerateAppearances = true;

            // close the pdf
            pdfStamper.Close();

            var fileStream = new FileStream(newFile,
                                 FileMode.Open,
                                 FileAccess.Read
                               );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }

        public ActionResult InfoPaziente(int idPaziente)
        {
            var result = new
            {
                iniziali = "",
                eta = "<b>Age:</b> ",
                sesso = "<b>Gender:</b> ",
                peso = "<b>Weight (Kg):</b> ",
                altezza = "<b>Height (cm):</b> ",
                dataAssegnazionePeriodoProva = ""
            };
            if (idPaziente != 0) { 
                Anagrafica paziente = db.Anagrafica.Single(p => p.idPaziente == idPaziente);
                //da antropometria
                string pesoPrimaAntropometria = "n.d.";
                string altezzaPrimaAntropometria = "n.d.";
                if (db.StatiRegistro.Where(ant => ant.idStato == 5 && ant.idPaziente == idPaziente).Count() == 1)
                {
                    StatiRegistro sa = db.StatiRegistro.Single(ant => ant.idStato == 5 && ant.idPaziente == idPaziente); //PRIMA ANTROPOMETRIA
                    Antropometria antropometria = db.Antropometria.Single(x => x.idStatoRegistro == sa.idStatoRegistro);
                    pesoPrimaAntropometria = antropometria.peso.ToString();
                    altezzaPrimaAntropometria = antropometria.altezza.ToString();
                }
                //da assegnazioni
                string dataAssegnazionePeriodoProva = "n.d.";
                if (db.AssegnazioniRegistro.Where(ar => ar.idAssegnazioneElenco == 2 && ar.idPaziente == idPaziente && ar.Completamento == true).Count() == 1)
                {
                    AssegnazioniRegistro r = db.AssegnazioniRegistro.Single(ar => ar.idAssegnazioneElenco == 2 && ar.idPaziente == idPaziente);
                    AssegnazioneFarmaco af = db.AssegnazioneFarmaco.Single(y => y.idAssegnazioneRegistro == r.idAssegnazioneRegistro);
                    dataAssegnazionePeriodoProva = af.dataConsegna.ToShortDateString();
                }
                string cognomeAnonimo = new String('*', paziente.cognome.Length - 1);
                string nomeAnonimo = new String('*', paziente.nome.Length - 1);
                result = new { 
                    iniziali = paziente.cognome.Substring(0, 1)+cognomeAnonimo + " " + paziente.nome.Substring(0, 1)+nomeAnonimo,
                    eta = "<b>Age:</b> " + (DateTime.Today.Year - Convert.ToDateTime(paziente.datanascita).Year).ToString(),
                    sesso = "<b>Gender:</b> " + paziente.sesso,
                    peso = "<b>Weight (Kg):</b> " + pesoPrimaAntropometria.ToString(),
                    altezza = "<b>Height (cm):</b> " + altezzaPrimaAntropometria.ToString(),
                    dataAssegnazionePeriodoProva = dataAssegnazionePeriodoProva
                };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
