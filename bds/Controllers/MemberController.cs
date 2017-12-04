using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;

namespace bds.Controllers
{
    public class MemberController : Controller
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: Member
        public ActionResult Index()
        {
            if(Session["username"] != null)
            {
                int uid = Convert.ToInt32(Session["uid"]);
                var model = db.BDS_MUABAN.Where(q => q.Visible == true && q.CreateBy == uid).OrderBy(o => o.Created);

                return View(model);
            }
            else
            {
                return Redirect("/home/login/2");
            }
        }
    }
}