using System;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.SqlClient;
using System.Dynamic;
using System.Data;

namespace MeMeMe.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
    public class MagazzinoController : BaseController
    {
        private MeMeMeEntities db = new MeMeMeEntities();
        private ApplicationDbContext context = new ApplicationDbContext();

        [SessionExpireFilter]
        [Authorize(Roles = "operatore, supervisore, amministratore, audit")]
        public ActionResult Index(FormCollection collection)
        {
            dynamic mymodel = new ExpandoObject();
            FabbisognioFlaconi p = new FabbisognioFlaconi();
            string m = "";
            string s = "";

            if (String.IsNullOrEmpty(collection["f.dataConsegna"]) == false && String.IsNullOrEmpty(collection["f.dataScadenza"]) == false)
            {
                if (Convert.ToDateTime(collection["f.dataConsegna"]) < Convert.ToDateTime(collection["f.dataScadenza"]))
                {
                    p.dataConsegna = Convert.ToDateTime(collection["f.dataConsegna"]);
                    p.dataScadenza = Convert.ToDateTime(collection["f.dataScadenza"]);
                    var msg = new SqlParameter("@msg", SqlDbType.VarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };

                    var result = context.Database.ExecuteSqlCommand("sp_StimaFabbisognioFlaconi @dataConsegna,@dataScadenza,@msg out",
                    new SqlParameter("@dataConsegna", p.dataConsegna),
                    new SqlParameter("@dataScadenza", p.dataScadenza),
                    msg);
                    m = msg.SqlValue.ToString();
                    s = "infoPanel";
                }
                else
                {
                    m = "da data di consegna deve essere inferiore alla data scadenza";
                    s = "infoPanelAlert";
                }
            }
            else
            {
                m = "Per simulare i fabbisogni inserire data di scadenza data di consegna da concordare con il fornitore.</p>";
                s = "infoPanelBlank";
            }

            mymodel.f = p;
            ViewBag.style = s;
            ViewBag.msg = m;

            return View(mymodel);
        }
    }
}
