using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers
{
    public class TopicClienController : Controller
    {
        // GET: TopicClien
        public ActionResult Index()
        {
            HttpClient Client = new System.Net.Http.HttpClient();
            //  Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/afficher").Result;
            if (response.IsSuccessStatusCode)

            {

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable< MVCConsumeWebAPI.Models.topic>>().Result;

                // jsonArray.add(ViewBag.result);

            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: TopicClien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TopicClien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopicClien/Create
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

        // GET: TopicClien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TopicClien/Edit/5
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

        // GET: TopicClien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TopicClien/Delete/5
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
