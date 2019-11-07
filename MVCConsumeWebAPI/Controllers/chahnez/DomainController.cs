
using Kendo.Mvc.UI;
using MVCConsumeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers
{
    public class DomainController : Controller
    {
        // GET: Domain
        public static int id;

        //public ActionResult Remote_Binding_Orders_Read([DataSourceRequest]DataSourceRequest request)
        //{
        //   // return Json(GetOrders().ToDataSourceResult(request));
        //}
        public ActionResult Index()
        {
            HttpClient Client = new System.Net.Http.HttpClient();
        //    Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue ("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/domain/afficher").Result;
            if(response.IsSuccessStatusCode)
           
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MVCConsumeWebAPI.Models.Domain>>().Result;


            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

      

        // GET: Domain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Domain/Create

        public ActionResult Create()
        {
           
            {
                return View();
            }
        }

        // POST: Domain/Create
        [HttpPost]
        public ActionResult Create(Domain domain)
        {
          //  try
            {

                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PostAsJsonAsync<Domain>(" http://localhost:18080/gestion-resources-humaine-web/api/test/domain/ajouter", domain).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
         //   catch
            {
                return View();
            }

            
         
        }

        // GET: Domain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Domain/Edit/5
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

        // GET: Domain/Delete/5
        public ActionResult Delete(int id)
        {
           
 
            return View();
        }

        // POST: Domain/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, Domain d)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Client.DeleteAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/domain/supprimer/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult statisticWeb()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetStatWeb()
        {
            HttpClient Client = new HttpClient();
            String result;
            // Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/getstat").Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;

            }

            else
            {
                result = null;
            }

            return new JsonResult { Data = result };


        }
    }
}
