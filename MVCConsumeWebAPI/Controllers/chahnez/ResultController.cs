
using PI_Neoxam_GRH.Services.ResultService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers
{
    public class ResultController : Controller
    {
        IResultService resultservice = new ResultService();
        // GET: Result
        public ActionResult Index()
        {
          
            //List<MVCConsumeWebAPI.Models.result> listR = new List<MVCConsumeWebAPI.Models.result>();
            //foreach (var item in resultservice.GetMany())
            //{
            //    MVCConsumeWebAPI.Models.result Rc = new MVCConsumeWebAPI.Models.result();
            //    Rc.id = item.id;
            //    Rc.date = item.date;
               

            //    //topic c = topicservice.GetById(item.topic.id);
            //    //Rc.topic.nom = c.nom;
            //    listR.Add(Rc);
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        // GET: Result/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Result/Create
        [HttpPost]
        public ActionResult Create(MVCConsumeWebAPI.Models.topic t)
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

        // GET: Result/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Result/Edit/5
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

        // GET: Result/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Result/Delete/5
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
