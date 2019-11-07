using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers
{
    public class ReponseController : Controller
    {
        // GET: Reponse
        public ActionResult Index(int id)
        {
            HttpClient Client = new System.Net.Http.HttpClient();
            //  Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(" http://localhost:18080/gestion-resources-humaine-web/api/test/question/getlistereponsequestions/" + id).Result;
            if (response.IsSuccessStatusCode)

            {

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable< MVCConsumeWebAPI.Models.answer>>().Result;

                // jsonArray.add(ViewBag.result);

            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }

        // GET: Reponse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reponse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reponse/Create
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

        // GET: Reponse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reponse/Edit/5
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

        // GET: Reponse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reponse/Delete/5
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
    }
}
