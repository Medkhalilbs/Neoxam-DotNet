using MVCConsumeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers
{
    public class QuestionController : Controller
    {
        static int ids;
       public static question jsonq;
        // GET: Question
        public ActionResult Index(int id)
        {
       
            HttpClient Client = new System.Net.Http.HttpClient();
            //  Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(" http://localhost:18080/gestion-resources-humaine-web/api/test/question/afficherquestion/" + id).Result;
            if (response.IsSuccessStatusCode)

            {

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable< MVCConsumeWebAPI.Models.question>>().Result;

                // jsonArray.add(ViewBag.result);

            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create(int id)
        {
            ids = id;
            ViewBag.id = id;
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(question q)
        {
            q.id = 0;
            topic t = new topic();
            t.id = ids;
            q.topic = t;
            jsonq = q;

           // try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response= Client.PostAsJsonAsync<question>(" http://localhost:18080/gestion-resources-humaine-web/api/test/question/ajouter", q).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                //return RedirectToAction("Index", "Topic");
               

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Topic");
                }

            }
         //   catch
            {
                return RedirectToAction("Index", "Topic");
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
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


        public ActionResult question()

            { return Json(jsonq,JsonRequestBehavior.AllowGet); }
    }
}
