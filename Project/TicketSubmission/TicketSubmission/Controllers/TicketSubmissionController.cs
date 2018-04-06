using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketSubmission.Controllers
{
    public class TicketSubmissionController : Controller
    {
        public ActionResult TicketSubmissionForm()
        {
            ViewBag.Title = "";

            return View();
        }
    }
}
