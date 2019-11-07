using EAGetMail;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebAPI.Controllers.UserController
{
    public class EmailController : Controller
    {
        public static List<Mail> liste = new List<Mail>();
        // GET: Email
        public ActionResult Index()
        {
            // Process.Start(@"C:\Users\X\Documents\Visual Studio 2015\Projects\PI-Neoxam-GRH\PI-Neoxam-GRH.Console\bin\Debug\PI-Neoxam-GRH.Console.exe");

            ViewBag.listeEmails = liste;


            //MvcApplication.listMails= new List<Mail>();
            //MvcApplication.ConnectToGmailAccountAndGetOrUpdateMails();

            //ViewBag.test = liste.Last<Mail>().HtmlBody.Remove(0, 25);
            //ViewBag.test = liste.Last<Mail>().HtmlBody.Replace("</body></html>", "");

            //Debug.WriteLine("ViewBag.hello="+ ViewBag.hello);

            return View(ViewBag.listeEmails);
        }

        // GET: Email/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Email/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Email/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Email/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult NewEmailsNumber()
        {
            return Json(liste.Count, JsonRequestBehavior.AllowGet);
        }




        private static IEnumerable<EAGetMail.Mail> GetMails()
        {

            return liste;
        }

        public ActionResult MailsListe([DataSourceRequest]DataSourceRequest request)
        {
            return Json(liste.OrderByDescending(e => e.SentDate).ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }



        public ActionResult AttachmentsListeByEmailID(String id, [DataSourceRequest] DataSourceRequest request)
        {

            return Json(liste.Where(mail => mail.Attachments != null).Single<Mail>().Attachments.ToDataSourceResult(request));
            // return Json(liste.Where(mail => mail.TextBody == id).ToDataSourceResult(request));
        }








    }
}
