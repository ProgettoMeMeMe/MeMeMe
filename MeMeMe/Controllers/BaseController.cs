using MeMeMe.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;


namespace MeMeMe.Controllers
{

    public class BaseController : Controller
    {
        private MeMeMeEntities db = new MeMeMeEntities();
        private ApplicationDbContext context = new ApplicationDbContext();
        private Font font = new Font("Trebuchet MS", 14, FontStyle.Bold);
        private Font font2 = new Font("Trebuchet MS", 10, FontStyle.Bold);
        private Color color = Color.FromArgb(26, 59, 105);
        private Color colorBorderPie = Color.FromArgb(180, 26, 59, 105);
        private Color colorPie = Color.FromArgb(220, 65, 140, 240);

        public ViewResult _Scorte()
        {

            var tabScorte = from mF in db.sp_StatisticaMagazzinoFarmaci()
                            orderby mF.scadenzaFarmaco ascending
                            select mF;
            //Scorte g = new Scorte();
            dynamic scorte = new List<Scorte>();
            foreach (var r in tabScorte)
            {
                dynamic s = new Scorte();
                s.lotto = r.lotto;
                s.totale = r.totale;
                s.resi = r.resi;
                s.assegnati = r.assegnati;
                s.disponibili = r.disponibili;
                s.dataConsegna = (DateTime)r.dataConsegna;
                s.scadenzaFarmaco = (DateTime)r.scadenzaFarmaco.Value;
                scorte.Add(s);
            }
            return View(scorte);
        }

        [SessionExpireFilter]
        [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
        public FileResult AndamentoScorte()
        {

            //Carica dati
            StringBuilder strSQL = new StringBuilder();
            //query andamento reclutamenti
            strSQL.Append("SELECT");
            strSQL.Append(" cast(Convert(date, t1.dataAssegnazione, 105) as char(7)) as data");
            strSQL.Append(" ,count(*) as assegnazioni");
            strSQL.Append(" ,(SELECT count(*) FROM KitRandomizzazione as t2 WHERE Lotto is not null and Reso = 0 )+1 - (select count(*) FROM KitFlaconiAssegnazione t3 WHERE cast(Convert(date, t3.dataAssegnazione, 105) as char(7)) <= cast(Convert(date, t1.dataAssegnazione, 105) as char(7))) AS scorte");
            strSQL.Append(" FROM KitFlaconiAssegnazione as t1");
            strSQL.Append(" GROUP BY cast(Convert(date, t1.dataAssegnazione, 105) as char(7))");
            strSQL.Append(" ORDER BY data ASC");
            // Define the Chart
            Chart chartAndamentoScorte = new Chart()
            {
                Width = 512,
                Height = 368,
                RenderType = RenderType.BinaryStreaming,
                Palette = ChartColorPalette.BrightPastel,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderWidth = 2,
                BorderColor = color
            };
            
            chartAndamentoScorte.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            ChartArea area = chartAndamentoScorte.ChartAreas.Add("area");
            Legend l = chartAndamentoScorte.Legends.Add("legend");
            Series series1 = chartAndamentoScorte.Series.Add("assegnazioni");
            Series series2 = chartAndamentoScorte.Series.Add("scorte");

            area.AxisX.IsLabelAutoFit = false;
            area.AxisY.IsLabelAutoFit = false;

            l.Docking = Docking.Bottom;
            l.LegendStyle = LegendStyle.Row;
            l.Alignment = StringAlignment.Center;

            area.AxisY.Title = "flaconi";
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular);
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            area.AxisX.LabelStyle.Format = "MM/yyyy";
            area.AxisX.IsLabelAutoFit = true;
            area.AxisX.LabelStyle.Angle = 45;

            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;

            series1.XValueMember = "mese";
            series1.YValueMembers = "flaconi";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL.ToString(), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    series1.Points.AddXY(rdr["data"], rdr["assegnazioni"]);
                    series2.Points.AddXY(rdr["data"], rdr["scorte"]);
                }
                rdr.Close();
                conn.Close();
            }

            //trende semestre regressione lineare
            Series series3 = chartAndamentoScorte.Series.Add("trend a 6 mesi*");
            series3.ChartType = SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Orange;
            series3.BorderDashStyle = ChartDashStyle.Dash;
            chartAndamentoScorte.DataManipulator.IsStartFromFirst = true;
            //chartAndamentoScorte.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear, 6, false, false", series2, series3);

            using (var ms = new MemoryStream())
            {
                chartAndamentoScorte.SaveImage(ms, ChartImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms.ToArray(), "image/png", "mychart.png");
            }
        }

    }
}
