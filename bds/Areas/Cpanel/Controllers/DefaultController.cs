using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;
using System.Net;

namespace bds.Areas.Cpanel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Cpanel/Default
        public ActionResult Index()
        {
            return View();
        }
       
    }
}