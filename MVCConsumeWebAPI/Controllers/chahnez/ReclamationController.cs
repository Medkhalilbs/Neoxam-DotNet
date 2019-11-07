

using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.Services.ReclamationService;
using PI_Neoxam_GRH.Services.TopicService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers.chahnez
{
    public class ReclamationController : Controller
    {
        public DateTime Local = DateTime.Now;
        IReclamationService reclamationservice = new ReclamationService();
        ITopicService topicservice = new TopicService();
        // GET: Reclamation
        public ActionResult Index()
        {
            topic t = new topic();
            List<MVCConsumeWebAPI.Models.reclamation> listR = new List<MVCConsumeWebAPI.Models.reclamation>();
            foreach (var item in reclamationservice.GetAll())
            {   MVCConsumeWebAPI.Models.reclamation Rc = new MVCConsumeWebAPI.Models.reclamation();
                Rc.id = item.id;
                Rc.image = item.image;
                Rc.etat = item.etat;
                Rc.description = item.description;
                Rc.objet = item.objet;
                Rc.date_creation = item.date_creation;
                //t = topicservice.GetById(item.topic.id);
                //Rc.topic_id = t.id;
                listR.Add(Rc);
            }

            return View(listR);

        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(MVCConsumeWebAPI.Models.reclamation r, int id, HttpPostedFileBase files)
        {
            reclamation reclamation = new reclamation();
            reclamation.description = r.description;
            reclamation.etat = "En attente";
            reclamation.objet = r.objet;
            reclamation.image = r.image;
            reclamation.date_creation = Local;
            reclamation.date_traitement = null;

           // HttpPostedFileBase files

            string fileName = "";
            if (files != null)
            {

                fileName = Path.GetFileName(files.FileName);
                var physicalPath = Path.Combine(Server.MapPath("~/Content/chahnez"), fileName);
                var fileExtension = Path.GetExtension(files.FileName);
                files.SaveAs(physicalPath);

            }


            reclamation.image = fileName;
            reclamation.topic_id = id;
            reclamationservice.addrec(reclamation);
            return RedirectToAction("Index");

        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            var p = reclamationservice.GetById(id);
            MVCConsumeWebAPI.Models.reclamation pvm = new MVCConsumeWebAPI.Models.reclamation();
            pvm.id = p.id;
            pvm.objet = p.objet;
            pvm.image = p.image;
            pvm.description = p.description;
            return View(pvm);
        }
     
        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MVCConsumeWebAPI.Models.reclamation recla)
        {
        reclamation p = reclamationservice.GetById(id);
            DateTime date2 = DateTime.Now;
            DateTime date1 = (DateTime)p.date_creation;
            date1 = date1.AddDays(+1);
            DateTime res;
            res = date1;
            if (p.date_traitement == null && date2<res  )
            {
                p.objet = recla.objet;
                p.description = recla.description;
                p.image = recla.image;
                reclamationservice.Update(p);
                reclamationservice.Commit();
                       return RedirectToAction("Index");
            
            }
           
            else
            {
                RedirectToAction("Index");

            }
            return RedirectToAction("Index");




        }
     
        public ActionResult Accepter(int id, MVCConsumeWebAPI.Models.reclamation recla)
        {
            
            reclamation p = reclamationservice.GetById(id);
            p.etat = "Traitée";
            DateTime date2 = DateTime.Now;
            p.date_traitement = date2;
                reclamationservice.Update(p);
                reclamationservice.Commit();
                return RedirectToAction("Index");

        }
     
        public ActionResult Refuser(int id, MVCConsumeWebAPI.Models.reclamation recla)
        {
            reclamation p = reclamationservice.GetById(id);
            p.etat = "Non traitée";
            DateTime date2 = DateTime.Now;
            p.date_traitement = date2;
            reclamationservice.Update(p);
            reclamationservice.Commit();
            return RedirectToAction("Index");

        }




        // POST: Request/Delete/5
        public ActionResult Delete(int id)
        {
            var reclamation = reclamationservice.GetMany().Where(c => c.id.Equals(id)).FirstOrDefault();
            reclamationservice.Delete(reclamation);
            reclamationservice.Commit();
            return RedirectToAction("Index");
        }

        // POST: Conge/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var reclamation = reclamationservice.GetMany().Where(c => c.id.Equals(id)).FirstOrDefault();
                reclamationservice.Delete(reclamation);
                reclamationservice.Commit();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Request/AddRequiredSkills
        public ActionResult AddRequiredSkills()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Traitement(int id, MVCConsumeWebAPI.Models.reclamation recla)
        {
            reclamation p = reclamationservice.GetById(id);
            if (p.date_traitement == null)
            {
                p.etat = "Traité";
                p.date_traitement = Local;

                reclamationservice.Update(p);
                reclamationservice.Commit();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Listwaiting()
        {
            topic t = new topic();
            List<MVCConsumeWebAPI.Models.reclamation> listR = new List<MVCConsumeWebAPI.Models.reclamation>();
            foreach (var item in reclamationservice.GetAll())
            {
                MVCConsumeWebAPI.Models.reclamation Rc = new MVCConsumeWebAPI.Models.reclamation();
                Rc.etat = item.etat;
                if (Rc.etat.Equals("En attente"))
                {
                    Rc.id = item.id;
                    Rc.image = item.image;
                    Rc.etat = item.etat;
                    Rc.description = item.description;
                    Rc.objet = item.objet;
                    Rc.date_creation = item.date_creation;
                    //t = topicservice.GetById(item.topic.id);
                    //Rc.topic_id = t.id;
                    listR.Add(Rc);

                }
                
            }

            return View(listR);

        }

        public JsonResult GetSearch(string s)
        {
            List<reclamation> listereclamation = reclamationservice.GetMany(c => c.objet.Contains(s)).ToList<reclamation>();

            return new JsonResult { Data = listereclamation, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public ActionResult statistic()
        {
            return View();
        }
        public ActionResult statisticWeb()
        {
            return View();
        }




        [HttpPost]
        public JsonResult GetStat()
        {
            var dt = reclamationservice.GetMany().GroupBy(a => a.etat)
                        .Select(g => new { g.Key, Count = g.Count() });
            return new JsonResult { Data = dt };


        }
        public ActionResult Gestion()
        {
            return View();
        }

        public ActionResult AccepterRefuser()
        {
            topic t = new topic();
            List<MVCConsumeWebAPI.Models.reclamation> listR = new List<MVCConsumeWebAPI.Models.reclamation>();
            foreach (var item in reclamationservice.GetAll())
            {
                MVCConsumeWebAPI.Models.reclamation Rc = new MVCConsumeWebAPI.Models.reclamation();
                Rc.id = item.id;
                Rc.image = item.image;
                Rc.etat = item.etat;
                Rc.description = item.description;
                Rc.objet = item.objet;
                Rc.date_creation = item.date_creation;
                //t = topicservice.GetById(item.topic.id);
                //Rc.topic_id = t.id;
                listR.Add(Rc);
            }

            return View(listR);
        }

        
        // GET: Reclamation/Edit/5
        public ActionResult Det(int id)
        {
            var p = reclamationservice.GetById(id);
            MVCConsumeWebAPI.Models.reclamation pvm = new MVCConsumeWebAPI.Models.reclamation();
            pvm.id = p.id;
            pvm.objet = p.objet;
            pvm.image = p.image;
            pvm.description = p.description;
            return View(pvm);
        }
        public ActionResult Deta(int id)
        {
            var p = reclamationservice.GetById(id);
            MVCConsumeWebAPI.Models.reclamation pvm = new MVCConsumeWebAPI.Models.reclamation();
            pvm.id = p.id;
            pvm.objet = p.objet;
            pvm.image = p.image;
            pvm.description = p.description;
            ViewBag.id = p.id;
            return View(pvm);
        }

    }
}
