using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MeMeMe.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
    public class FarmaciController : Controller
    {
        private MeMeMeEntities db = new MeMeMeEntities();
        private ApplicationDbContext context = new ApplicationDbContext();

        //FARMACI
        public ActionResult _HistoryFarmaci(int id)
        {
            var elencoConsegne = db.AssegnazioniRegistro
                                .Include(s => s.AssegnazioniElenco)
                                .Include(f => f.AssegnazioneFarmaco)
                                .Where(u => u.idPaziente == id && u.Completamento == true);

            dynamic ListaConsegne = new List<FarmaciListato>();
            Anagrafica paziente = db.Anagrafica.Single(ana => ana.idPaziente == id);
            DateTime tMeno1 = paziente.data;
            foreach (var ec in elencoConsegne)
            {
                dynamic c = new FarmaciListato();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                IEnumerable<KitFlaconiAssegnazione> flaconi = db.KitFlaconiAssegnazione.Where(f => f.idPaziente == ec.idPaziente && f.idAssegnazioneElenco == ec.idAssegnazioneElenco);
                c.idAssegnazioneRegistro = ec.idAssegnazioneRegistro;
                if (ec.AssegnazioneFarmaco != null)
                {
                    c.dosaggio = ec.AssegnazioneFarmaco.dosaggioPieno == 1 ? "pieno" : "mezzo";
                    c.pilloleFasePrecedente = ec.AssegnazioneFarmaco.pilloleAssunte.ToString();
                }
                c.PeriodoDaTmeno1 = (ec.DataApertura - tMeno1).Days.ToString();
                //flaconi
                foreach (var sf in flaconi)
                {
                    sb.Append(sf.Kit + " ");
                }
                c.consegna = (DateTime)ec.DataChiusura;
                c.flaconi = sb.ToString().Trim();
                c.fase = ec.AssegnazioniElenco.descrizione;
                tMeno1 = (DateTime)ec.DataApertura;
                ListaConsegne.Add(c);
            }
            ViewBag.idPaziente = id;
            return View(ListaConsegne);
        }

        public ActionResult _RiepilogoFarmaci(int idPaziente)
        {

            RiepilogoFarmaci rf = new RiepilogoFarmaci();
            var elencoConsegne = db.AssegnazioniRegistro
                                .Include(f => f.AssegnazioneFarmaco)
                                .Where(u => u.idPaziente == idPaziente && u.DataChiusura != null);
            var countConsegne = elencoConsegne.Count();
            if (countConsegne > 0)
            { 
                int max = elencoConsegne.Max(u => u.idAssegnazioneElenco);
                foreach (var ec in elencoConsegne)
                {
                    //in carico
                    if (ec.idAssegnazioneElenco == max)
                    {
                        if (max == 1)
                        {
                            rf.pilloleMDAssunte = 0;
                            rf.pilloleMDAssunte = 0;
                            rf.pilloleDPAssegnate = 1 * 62; //randomizzazione dosaggio PIENO
                            rf.flaconiDPAssegnati = 1;
                        }
                        else {
                            if (ec.AssegnazioneFarmaco.dosaggioPieno != 1)
                            {
                                rf.pilloleDPInCarico = 0;
                                rf.flaconiDPInCarico = 0;
                                rf.pilloleMDInCarico = ec.AssegnazioneFarmaco.flaconiAssegnati * 62;
                                rf.flaconiMDInCarico = ec.AssegnazioneFarmaco.flaconiAssegnati;

                            }
                            else
                            {
                                rf.pilloleDPInCarico = ec.AssegnazioneFarmaco.flaconiAssegnati * 62;
                                rf.flaconiDPInCarico = ec.AssegnazioneFarmaco.flaconiAssegnati;
                                rf.pilloleMDInCarico = 0;
                                rf.flaconiMDInCarico = 0;
                            }
                        }
                    }
                    else
                    {
                        //assegnazione RANDOMIZZAZIONE 1 FLACONE A DOSAGGIO PIENO
                        if (ec.idAssegnazioneElenco == 1)
                        {
                            rf.pilloleMDAssunte = 0;
                            rf.pilloleMDAssunte = 0;
                            rf.pilloleDPAssegnate = 1 * 62; //randomizzazione dosaggio PIENO
                            rf.flaconiDPAssegnati = 1;
                        }
                        else
                        {
                            if (ec.AssegnazioneFarmaco.dosaggioPieno == 1)
                            {
                                rf.pilloleDPAssegnate += ec.AssegnazioneFarmaco.flaconiAssegnati * 62;
                                rf.pilloleDPAssunte += ec.AssegnazioneFarmaco.pilloleAssunte;
                                rf.flaconiDPAssegnati += ec.AssegnazioneFarmaco.flaconiAssegnati;
                            }
                            else
                            {
                                rf.pilloleMDAssegnate += ec.AssegnazioneFarmaco.flaconiAssegnati * 62;
                                rf.pilloleMDAssunte += ec.AssegnazioneFarmaco.pilloleAssunte;
                                rf.flaconiMDAssegnati += ec.AssegnazioneFarmaco.flaconiAssegnati;
                            }

                        }
                    }
                }
            }
            return View(rf);
        }


        //STAMPA MODULO FARMACIA
        public ActionResult StampaModulo(int? id)
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();

            // Dati da registro
            AssegnazioniRegistro ar = db.AssegnazioniRegistro.Single(a => a.idAssegnazioneRegistro == id);
            // Dati da assegnzzione
            string dosaggio = "dosaggio pieno";
            if (ar.idAssegnazioneElenco != 1)
            {

                AssegnazioneFarmaco af = db.AssegnazioneFarmaco.Single(a => a.idAssegnazioneRegistro == ar.idAssegnazioneRegistro);
                if (af.dosaggioPieno == 0)
                {
                    dosaggio = "mezzo dosaggio";
                }
            }
            string nome = ar.Anagrafica.nome;
            string cognome = ar.Anagrafica.cognome;

            DateTime consegna = ar.Anagrafica.dataRandomizzazioneTrattamento.Value;
            if (ar.AssegnazioneFarmaco != null)
            {
                consegna = ar.AssegnazioneFarmaco.dataConsegna;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            IEnumerable<KitFlaconiAssegnazione> flaconi = db.KitFlaconiAssegnazione.Where(f => f.idPaziente == ar.idPaziente && f.idAssegnazioneElenco == ar.idAssegnazioneElenco);

            string sTitolo = "Progetto MeMeMe - richiesta farmaci";
            Paragraph pTitolo = new Paragraph(new Phrase(sTitolo, FontFactory.GetFont(FontFactory.HELVETICA, 18, iTextSharp.text.Font.BOLD)));
            Paragraph pSpace = new Paragraph(" ");
            document.Add(pTitolo);
            document.Add(pSpace);

            //Phrase phTesto = new Phrase("DATA consegna: " + System.DateTime.Today.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL));
            Phrase phTesto = new Phrase("DATA consegna: " + consegna.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL));
            string cognomeAnonimo = new String('*', cognome.Length - 1);
            string nomeAnonimo = new String('*', nome.Length - 1);
            phTesto.Add(new Phrase("\n\nNome: " + nome.Substring(0, 1) + nomeAnonimo, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("\nCognome: " + cognome.Substring(0, 1) + cognomeAnonimo, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            if (ar.Anagrafica.randomizzazioneDieta == 1)
            {
                phTesto.Add(new Phrase("\n\nN° RANDOM: " + "MINT" + String.Format("{0:00000}", ar.idPaziente), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)));
            }
            if (ar.Anagrafica.randomizzazioneDieta == 2)
            {
                phTesto.Add(new Phrase("\n\nN° RANDOM: " + "MINT" + String.Format("{0:00000}", ar.idPaziente), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GREEN)));
            }
            phTesto.Add(new Phrase("\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("Farmaci: METFORM/PLACEBO 850mg 62 cpr.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("\n\nPosologia: " + flaconi.Count().ToString() + " flacone/i", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("Dosaggio: " + dosaggio, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            //phTesto.Add(new Phrase("DATA stimata prossimo ritiro: " + consegna.AddMonths(ar.AssegnazioniElenco.dosaggioPieno).ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            phTesto.Add(new Phrase("\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));

            phTesto.Add(new Phrase("\nN° confezioni: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
            //flaconi
            DateTime assegnazione = DateTime.Today;
            DateTime scadenza = DateTime.Today;
            DateTime avanzamento = consegna;
            foreach (var sf in flaconi)
            {
                ////aggiungo 1 o 2 mesi da dato consegna in base al dosaggio assegnato 
                //if (ar.AssegnazioneFarmaco==null)
                //{
                //    avanzamento.AddMonths(1);
                //}
                //else
                //{
                //    avanzamento = ar.AssegnazioneFarmaco.flaconiAssegnati == ar.AssegnazioniElenco.dosaggioPieno ? avanzamento.AddMonths(1) : avanzamento.AddMonths(2);
                //}
                //assegnazione = sf.dataAssegnazione;
                scadenza = sf.KitRandomizzazione.ScadenzaFarmaco.Value;
                //if(avanzamento<=scadenza){
                //    phTesto.Add(new Phrase("\n" + sf.Kit, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
                //    phTesto.Add(new Phrase(" scadenza: " + scadenza.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
                //}
                //else
                //{
                //    phTesto.Add(new Phrase("\n" + sf.Kit, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
                //    phTesto.Add(new Phrase(" scadenza: " + scadenza.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
                //    phTesto.Add(new Phrase(" IN SCADENZA NON DISTRIBUIBILE", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL, BaseColor.RED)));
                //}

                phTesto.Add(new Phrase("\n" + sf.Kit, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));
                phTesto.Add(new Phrase(" scadenza: " + scadenza.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL)));

            }

            document.Add(phTesto);
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }
    }
}
