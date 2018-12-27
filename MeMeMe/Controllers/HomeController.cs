using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Text;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace MeMeMe.Controllers
{
    public class HomeController : BaseController
    {
        private MeMeMeEntities db = new MeMeMeEntities();
        StringBuilder note = new StringBuilder();
        private Font font = new Font("Trebuchet MS", 14, FontStyle.Bold);
        private Font font2 = new Font("Trebuchet MS", 10, FontStyle.Bold);
        private Color color = Color.FromArgb(26, 59, 105);
        private Color colorBorderPie = Color.FromArgb(180, 26, 59, 105);
        private Color colorPie = Color.FromArgb(220, 65, 140, 240);

        public ActionResult Index()
        {
            //EMERGENZA
            if (User.IsInRole("emergenza"))
            {
                Response.Redirect(Url.Action("Index", "Emergenza"));
            }
            //Altri ruoli NON emergenza  
            //TABELLA randomizzazione dieta
            var tab = from t in db.sp_StatisticaCampionamento()
                      select t;
            int PtotBraccio1M = 0;
            int PtotBraccio1F = 0;
            int PtotBraccio2M = 0;
            int PtotBraccio2F = 0;
            int FtotBraccio1M = 0;
            int FtotBraccio1F = 0;
            int FtotBraccio2M = 0;
            int FtotBraccio2F = 0;
            int totProbanda = 0;
            int totFamiliare = 0;

            foreach (var r in tab)
            {
                if (r.tipo == "probanda")
                {
                    ViewData["ProbandaBraccio1M"] = r.B1M ?? 0;
                    ViewData["ProbandaBraccio1F"] = r.B1F ?? 0;
                    ViewData["ProbandaBraccio2M"] = r.B2M ?? 0;
                    ViewData["ProbandaBraccio2F"] = r.B2F ?? 0;
                    PtotBraccio1M += (int?)r.B1M ?? 0;
                    PtotBraccio1F += (int?)r.B1F ?? 0;
                    PtotBraccio2M += (int?)r.B2M ?? 0;
                    PtotBraccio2F += (int?)r.B2F ?? 0;
                    //totProbanda  += (int?)r.B1M ?? 0 + (int?)r.B1F ?? 0 + (int?)r.B2M ?? 0 + (int?)r.B2F ?? 0;
                    totProbanda += PtotBraccio1M + PtotBraccio1F + PtotBraccio2M + PtotBraccio2F;
                }
                if (r.tipo == "familiare")
                {
                    ViewData["FamiliareBraccio1M"] = r.B1M ?? 0;
                    ViewData["FamiliareBraccio1F"] = r.B1F ?? 0;
                    ViewData["FamiliareBraccio2M"] = r.B2M ?? 0;
                    ViewData["FamiliareBraccio2F"] = r.B2F ?? 0;
                    FtotBraccio1M += (int?)r.B1M ?? 0;
                    FtotBraccio1F += (int?)r.B1F ?? 0;
                    FtotBraccio2M += (int?)r.B2M ?? 0;
                    FtotBraccio2F += (int?)r.B2F ?? 0;
                    //totFamiliare += (int?)r.B1M ?? 0 + (int?)r.B1F ?? 0 + (int?)r.B2M ?? 0 + (int?)r.B2F ?? 0;
                    totFamiliare += FtotBraccio1M + FtotBraccio1F + FtotBraccio2M + FtotBraccio2F;
                }
            }
            ViewData["TotBraccio1M"] = PtotBraccio1M + FtotBraccio1M;
            ViewData["TotBraccio1F"] = PtotBraccio1F + FtotBraccio1F;
            ViewData["TotBraccio2M"] = PtotBraccio2M + FtotBraccio2M;
            ViewData["TotBraccio2F"] = PtotBraccio2F + FtotBraccio2F;
            ViewData["TotaleProbanda"]=totProbanda;
            ViewData["TotaleFamiliare"] = totFamiliare;
            ViewData["TotaleGenerale"] = PtotBraccio1M + PtotBraccio1F + PtotBraccio2M + PtotBraccio2F + FtotBraccio1M + FtotBraccio1F + FtotBraccio2M + FtotBraccio2F;

            //TABELLA randomizzazione farmaco
            var tabFarmaci = from tF in db.sp_StatisticaRandomizzazione()
                      select tF;

            ViewData["MaschiUnder67_X"] = 0;
            ViewData["MaschiUnder67_Y"] = 0;
            ViewData["FemmineUnder67_X"] = 0;
            ViewData["FemmineUnder67_Y"] = 0;
            ViewData["MaschiOver67_X"] = 0;
            ViewData["MaschiOver67_Y"] = 0;
            ViewData["FemmineOver67_X"] = 0;
            ViewData["FemmineOver67_Y"] = 0;
            int TOTMUnder67 = 0;
            int TOTFUnder67 = 0;
            int TOTMOver67 = 0;
            int TOTFOver67 = 0;
            int TOTX = 0;
            int TOTY = 0;

            foreach (var r in tabFarmaci)
            {
                if (r.sesso == "M" && r.Eta == "<67")
                {
                    ViewData["MaschiUnder67_X"] = r.X ?? 0;
                    ViewData["MaschiUnder67_Y"] = r.Y ?? 0;
                    TOTMUnder67 += (int?)r.X ?? 0;
                    TOTMUnder67 += (int?)r.Y ?? 0;
                    TOTX += (int?)r.X ?? 0;
                    TOTY += (int?)r.Y ?? 0;
                   }
                if (r.sesso == "F" && r.Eta == "<67")
                {
                    ViewData["FemmineUnder67_X"] = r.X ?? 0;
                    ViewData["FemmineUnder67_Y"] = r.Y ?? 0;
                    TOTFUnder67 += (int?)r.X ?? 0;
                    TOTFUnder67 += (int?)r.Y ?? 0;
                    TOTX += (int?)r.X ?? 0;
                    TOTY += (int?)r.Y ?? 0;
                }
                if (r.sesso == "M" && r.Eta == ">=67")
                {
                    ViewData["MaschiOver67_X"] = r.X ?? 0;
                    ViewData["MaschiOver67_Y"] = r.Y ?? 0;
                    TOTMOver67 += (int?)r.X ?? 0;
                    TOTMOver67 += (int?)r.Y ?? 0;
                    TOTX += (int?)r.X ?? 0;
                    TOTY += (int?)r.Y ?? 0;
                }
                if (r.sesso == "F" && r.Eta == ">=67")
                {
                    ViewData["FemmineOver67_X"] = r.X ?? 0;
                    ViewData["FemmineOver67_Y"] = r.Y ?? 0;
                    TOTFOver67 += (int?)r.X ?? 0;
                    TOTFOver67 += (int?)r.Y ?? 0;
                    TOTX += (int?)r.X ?? 0;
                    TOTY += (int?)r.Y ?? 0;
                }
            }
            ViewData["TOTMUnder67"]=TOTMUnder67;
            ViewData["TOTFUnder67"]=TOTFUnder67;
            ViewData["TOTMOver67"]=TOTMOver67;
            ViewData["TOTFOver67"]=TOTFOver67;
            ViewData["TOTX"]=TOTX;
            ViewData["TOTY"]=TOTY;
            ViewData["TOT"] = TOTX + TOTY;
            //Drop e ritirati
            var drop = from d in db.StatiRegistro
                                where d.idStato == 99
                                select d;
            ViewData["Drop"] = drop.Count();
            //In studio
            var instudio = from d in db.StatiRegistro
                       where d.idStato <99
                       select d;
            ViewData["InStudio"] = instudio.Count();
            //Fine studio
            var terminati = from d in db.StatiRegistro
                       where d.idStato == 100
                       select d;
            ViewData["FineStudio"] = terminati.Count();
            //Ivan
            DateTime partenza = new DateTime(2017, 11, 30);
            var anagrafiche = from d in db.Anagrafica
                           where d.data >= partenza
                              select d;
            DateTime oggi = DateTime.Today;
            DateTime fine = new DateTime(2018,3,31);

            ViewData["IvanObietivo"] = "dal 30/11/2017 sono state reclutati/e: " + anagrafiche.Count().ToString() + " pazienti. Per complate entro il 31/3, ne mancano ancora: " + (300- anagrafiche.Count()).ToString() + ". In media, per raggiungere l'obiettivo, ne dovresti reclutare " + ((300 - anagrafiche.Count())/ (fine- oggi).TotalDays).ToString() + " al giorno (compreso i decimali)";

            return View();
        }

        [SessionExpireFilter]
        [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
        public FileResult Monitoraggio()
        {
            //Carica dati
            StringBuilder strSQL = new StringBuilder();
            //query andamento reclutamenti
            strSQL.Append("SELECT Convert(date,t1.Data,105) as data");
            strSQL.Append(" ,count(*) as inserimenti");
            strSQL.Append(" ,(SELECT count(*) FROM Anagrafica as t2 WHERE Convert(date,t2.Data,105) <= Convert(date,t1.Data,105)) AS cumulata");
            strSQL.Append(" FROM Anagrafica as t1");
            strSQL.Append(" GROUP BY Convert(date,t1.Data,105)");
            strSQL.Append(" ORDER BY Convert(date,t1.Data,105) ASC");
            // Define the Chart
            Chart chartMonitoraggio = new Chart()
            {
                Width = 427,
                Height = 307,
                RenderType = RenderType.BinaryStreaming,
                Palette = ChartColorPalette.BrightPastel,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderWidth = 2,
                BorderColor = color
            };

            chartMonitoraggio.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            //chartMonitoraggio.Titles.Add(new Title("monitoraggio reclutamenti", Docking.Top, font, color));
            //chartMonitoraggio.ChartAreas.Add("area").Area3DStyle.Enable3D = false;

            ChartArea area = chartMonitoraggio.ChartAreas.Add("area");
            Legend l = chartMonitoraggio.Legends.Add("legend");
            Series series1 = chartMonitoraggio.Series.Add("arruolamenti");
            Series series2 = chartMonitoraggio.Series.Add("cumulata");

            area.AxisX.IsLabelAutoFit = false;
            area.AxisY.IsLabelAutoFit = false;

            l.Docking = Docking.Bottom;
            l.LegendStyle = LegendStyle.Row;
            l.Alignment = StringAlignment.Center;

            area.AxisY.Title = "pazienti";
            area.AxisY2.Title = "cumulata";
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular);
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            area.AxisX.LabelStyle.Format = "MM/yyyy";
            area.AxisX.IsLabelAutoFit = true;
            area.AxisX.LabelStyle.Angle = 45;

            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;

            series1.XValueMember = "data";
            series2.XValueMember = "data";
            series1.YValueMembers = "arruolamenti";
            series2.YValueMembers = "cumulata";
            series2.YAxisType = AxisType.Secondary;


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL.ToString(), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    series1.Points.AddXY(rdr["data"], rdr["inserimenti"]);
                    series2.Points.AddXY(rdr["data"], rdr["cumulata"]);
                }
                rdr.Close();
                conn.Close();
            }

            using (var ms = new MemoryStream())
            {
                chartMonitoraggio.SaveImage(ms, ChartImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms.ToArray(), "image/png", "mychart.png");
            }
        }


        [SessionExpireFilter]
        [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
        public FileResult Stati()
        {
            //Carica dati
            StringBuilder strSQL = new StringBuilder();
            //query numerosità per stato avanzamento
            strSQL.Append("SELECT Descrizione, count(idPaziente) as casi");
            strSQL.Append(" FROM StatiElenco");
            strSQL.Append(" LEFT OUTER JOIN Anagrafica ON StatiElenco.idStato=dbo.idStatoCorrente(Anagrafica.idPaziente)");
            strSQL.Append(" GROUP BY idStato, Descrizione");
            strSQL.Append(" ORDER BY idStato, Descrizione");
             

            // Define the Chart
            Chart chartStati = new Chart()
            {
                Width = 520,
                Height = 520,
                RenderType = RenderType.BinaryStreaming,
                Palette = ChartColorPalette.BrightPastel,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderWidth = 2,
                BorderColor = color
            };

            chartStati.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            ChartArea area = chartStati.ChartAreas.Add("area");
            Series series1 = chartStati.Series.Add("Descrizione");


            area.AxisY.Title = "pazienti";
            area.AxisX.IsLabelAutoFit = false;
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            area.AxisX.Interval = 1;
            area.AxisX.IsReversed = true;
            area.AxisX.MajorGrid.Enabled = false;

            series1.ChartType = SeriesChartType.Bar;

            series1.XValueMember = "Casi";
            series1.YValueMembers = "Descrizione";
            series1.IsValueShownAsLabel = true;
            series1.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL.ToString(), conn);
                rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    series1.Points.AddXY(rdr["descrizione"], rdr["casi"]);
                }
                rdr.Close();
                conn.Close();

            }

            using (var ms = new MemoryStream())
            {
                chartStati.SaveImage(ms, ChartImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms.ToArray(), "image/png", "mychart.png");
            }
        }


        [SessionExpireFilter]
        [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
        public FileResult Assegnazioni()
        {
            //Carica dati
            StringBuilder strSQL = new StringBuilder();
            //query numerosità per assegnazion farmaci
            strSQL.Append("SELECT idAssegnazioneElenco, Descrizione, count(idPaziente) as casi");
            strSQL.Append(" FROM AssegnazioniElenco");
            strSQL.Append(" LEFT OUTER JOIN Anagrafica ON AssegnazioniElenco.idAssegnazioneElenco=dbo.idAssegnazioneCorrente(Anagrafica.idPaziente)");
            strSQL.Append(" WHERE Anagrafica.idPaziente NOT IN (SELECT idPaziente FROM StatiRegistro INNER JOIN StatiElenco ON StatiRegistro.idStato = StatiElenco.idStato WHERE descrizione = 'drop')");
            strSQL.Append(" GROUP BY idAssegnazioneElenco, Descrizione");
            strSQL.Append(" ORDER BY idAssegnazioneElenco, Descrizione");

            // Define the Chart
            Chart chartStati = new Chart()
            {
                Width = 520,
                Height = 520,
                RenderType = RenderType.BinaryStreaming,
                Palette = ChartColorPalette.BrightPastel,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderWidth = 2,
                BorderColor = color
            };

            chartStati.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            ChartArea area = chartStati.ChartAreas.Add("area");
            Series series1 = chartStati.Series.Add("Descrizione");


            area.AxisY.Title = "pazienti";
            area.AxisX.IsLabelAutoFit = false;
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            area.AxisX.Interval = 1;
            area.AxisX.IsReversed = true;
            area.AxisX.MajorGrid.Enabled = false;

            series1.ChartType = SeriesChartType.Bar;

            series1.XValueMember = "Casi";
            series1.YValueMembers = "Descrizione";
            series1.IsValueShownAsLabel = true;
            series1.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL.ToString(), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    series1.Points.AddXY(rdr["descrizione"], rdr["casi"]);
                }
                rdr.Close();
                conn.Close();

            }

            using (var ms = new MemoryStream())
            {
                chartStati.SaveImage(ms, ChartImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms.ToArray(), "image/png", "mychart.png");
            }
        }


        //[SessionExpireFilter]
        //[Authorize(Roles = "operatore, supervisore, amministratore")]
        //public ViewResult _Scorte(){
        
        //   var tabScorte = from mF in db.sp_StatisticaMagazzinoFarmaci()
        //                   orderby mF.scadenzaFarmaco ascending
        //                   select mF;
        //   //Scorte g = new Scorte();
        //   dynamic scorte = new List<Scorte>();
        //   foreach (var r in tabScorte)
        //   {
        //       dynamic s = new Scorte();
        //       s.lotto = r.lotto;
        //       s.totale = r.totale;
        //       s.resi = r.resi;
        //       s.assegnati = r.assegnati;
        //       s.disponibili = r.disponibili;
        //       s.dataConsegna = (DateTime)r.dataConsegna;
        //       s.scadenzaFarmaco = (DateTime)r.scadenzaFarmaco.Value;
        //       scorte.Add(s);
        //   }
        //   return View(scorte);
        //}

        public ActionResult TestError()
        {
            ViewBag.Message = "Imbambi!";
            throw new Exception("This is not good. Something bad happened.");
        }
    }
}