
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVCConsumeWebAPI.Extensions;
using Newtonsoft.Json;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.Services.ResultService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVCConsumeWebApi.Controllers
{
    public class TopicController : Controller
    {
        public static int v;
        IResultService resultservice = new ResultService();
        IAnswerService answerService = new AnswerService();
        public static double score = 0;
        public static MVCConsumeWebAPI.Models.topic topicResult2;

        public string JsonStr { get; private set; }
        public static IEnumerable <MVCConsumeWebAPI.Models.question> jsonq;
        public static IEnumerable<MVCConsumeWebAPI.Models.topic> topicsList;
        public static string testjson;
        public static string[] testjson2;
        // GET: Topic

        public ActionResult Index()
        {
           
            HttpClient Client = new System.Net.Http.HttpClient();
         //  Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/afficher").Result;
            if (response.IsSuccessStatusCode)

            {
                
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable< MVCConsumeWebAPI.Models.topic>>().Result;
                topicsList = ViewBag.result;
                // jsonArray.add(ViewBag.result);

            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            // topic t = new topic();
            //v = t.id;
            // gestion_resources_humaine_Domain.Entities.result result = new gestion_resources_humaine_Domain.Entities.result();
            MVCConsumeWebAPI.Models.topic topicRecu = null;
            //result res = null;
            //double scor = 0;
            HttpClient Client = new System.Net.Http.HttpClient();
            //    Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/topicid/"+id).Result;

            HttpClient Client2 = new System.Net.Http.HttpClient();
            //    Client.BaseAddress = new Uri("http://localhost:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client2.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/question/afficherquestion/" + id).Result;

            if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)

            {
                topicRecu = response.Content.ReadAsAsync< MVCConsumeWebAPI.Models.topic>().Result;
                topicRecu.questions = response2.Content.ReadAsAsync<IEnumerable< MVCConsumeWebAPI.Models.question>>().Result;
                foreach (MVCConsumeWebAPI.Models.question q in topicRecu.questions)

                {
                    HttpResponseMessage response3 = Client2.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/question/getlistereponsequestions/" + q.id).Result;
                    if (response3.IsSuccessStatusCode)
                    {
                        q.answers = response3.Content.ReadAsAsync<IEnumerable< MVCConsumeWebAPI.Models.answer>>().Result;
                    }

                jsonq = topicRecu.questions;
            
        }
            }

            else
            {
                ViewBag.result = "error";
            }
            topicResult2 = topicRecu;
            return View(topicRecu);
        }


        // POST: Topic/Details/
        [HttpPost]
        public ActionResult Details(MVCConsumeWebAPI.Models.result r)
        {
            var resolveRequest = HttpContext.Request;
            resolveRequest.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonString = new StreamReader(resolveRequest.InputStream).ReadToEnd();
            score = 0;
            List<PI_Neoxam_GRH.Domain.Enities.answer> listeResponses = new List<PI_Neoxam_GRH.Domain.Enities.answer>();

            if (jsonString != null)
            {
                testjson = jsonString;
                string[] testing = Regex.Matches(jsonString, @"&answer.id=(?<Identifier>[0-9]*)") .Cast<Match>().Select(s => s.Groups["Identifier"].Value).ToArray();

                testjson2 = testing;

                int countvide = 0;
                for (int i = 0; i < testing.Length; i++)
                {
                    if (testing[i] == "")
                        countvide++;
                }
                if (! (countvide== testing.Length) )
                {
                    for (int i = 0; i < testing.Length; i++)
                    {if (!(testing[i]==""))
                        {
                            int b = Int32.Parse(testing[i]);
                            PI_Neoxam_GRH.Domain.Enities.answer answerTemp = answerService.GetById(b);
                            listeResponses.Add(answerTemp);
                        }
                    }

                    foreach (PI_Neoxam_GRH.Domain.Enities.answer a in listeResponses)
                    {
                        if (a.juste)
                            score++;
                    }

                }

                String resultat="";
                foreach (var item in listeResponses)
                    resultat= resultat+item;
                      // return Json("Success and score="+score +" /liste Reponse="+ resultat);
                result res = new result();
                String etat = "";
                DateTime localDate = DateTime.Now;

                res.score = score; 
                if(score < 2)
                {
                    res.statut = "Refusé";
                    etat = res.statut;
                }
                else
                {
                    res.statut = "Admis";
                    etat = res.statut;
                    
                }
                res.date = localDate;
                res.idtopic = topicResult2.id;

                res.idcandidate = User.Identity.GetJeeUserId();
                resultservice.addrec(res);


                ViewBag.Toutou = topicResult2.id;
                ViewBag.Date = localDate;
                ViewBag.Etat = etat;
                ViewBag.Number = score;
                ViewBag.Resultat = resultat;
                return View("~/Views/TopicClien/Resultat.cshtml");
            }

            else
            {
                return Json("An Error Has occoured");
            }

           


        }

        // GET: Topic/Create


        public ActionResult Create()
        {

            HttpClient Client = new System.Net.Http.HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/domain/afficher").Result;
            if (response.IsSuccessStatusCode)

            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MVCConsumeWebAPI.Models.Domain>>().Result.OrderBy(t => t.name);


            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(MVCConsumeWebAPI.Models.topic t, HttpPostedFileBase files)
        {
            topic topic = new topic();
            // try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PostAsJsonAsync<MVCConsumeWebAPI.Models.topic>(" http://localhost:18080/gestion-resources-humaine-web/api/test/topic/ajouter", t).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;


                if (response.IsSuccessStatusCode)
                {
                    // 

                    string fileName = "";
                    if (files != null)
                    {

                        fileName = Path.GetFileName(files.FileName);
                        var physicalPath = Path.Combine(Server.MapPath("~/Content/chahnez"), fileName);
                        var fileExtension = Path.GetExtension(files.FileName);
                        files.SaveAs(physicalPath);

                    }


                    topic.image = fileName;
                    return RedirectToAction("Index");
                }
            }
          //  catch
            {
                return View();
            }
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            MVCConsumeWebAPI.Models.topic topic = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/topicid/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                topic = response.Content.ReadAsAsync<MVCConsumeWebAPI.Models.topic>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }

            return View(topic);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(MVCConsumeWebAPI.Models.topic t)
        {
            try
            {
                
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PutAsJsonAsync<MVCConsumeWebAPI.Models.topic>("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/updateTopic", t).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MVCConsumeWebAPI.Models.topic d)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Client.DeleteAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/supprimer/" + id).Result;
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

        public ActionResult question()

        { return Json(jsonq, JsonRequestBehavior.AllowGet); }


        
        public ActionResult topicResultat()

        { return Json(topicResult2, JsonRequestBehavior.AllowGet); }

        public ActionResult testDejson()

        { return Json(testjson, JsonRequestBehavior.AllowGet); }
        
         public ActionResult testDejson2()

        { return Json(testjson2, JsonRequestBehavior.AllowGet); }

        private static IEnumerable<MVCConsumeWebAPI.Models.topic> GetMails()
        {

            return topicsList;
        }

        public ActionResult AllTopics([DataSourceRequest]DataSourceRequest request)
        {
            var result = topicsList.ToTreeDataSourceResult(request,
                e => e.id,
                e => e.domain.id,
                e => e
            );
            return Json(result, JsonRequestBehavior.AllowGet);
        }



       public ActionResult Valider()
        {
            return View();
        }



        [HttpPost]
        public JsonResult GetSearch(String search)
        {
            HttpClient Client = new HttpClient();
            IEnumerable<MVCConsumeWebAPI.Models.topic> result;
            // Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/test/topic/getTopicbyname/" + search).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<MVCConsumeWebAPI.Models.topic>>().Result;

            }

            else
            {
                result = null;
            }

            return new JsonResult { Data = result };

            // return "getsearch";

        }

    }
}
