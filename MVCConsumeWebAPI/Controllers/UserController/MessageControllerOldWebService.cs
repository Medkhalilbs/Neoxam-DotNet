//using EAGetMail;
//using Kendo.Mvc.UI;
//using MVCConsumeWebAPI.Models;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;
//using Kendo.Mvc.Extensions;
//using PI_Neoxam_GRH.Domain.Enities;
//using PI_Neoxam_GRH.Services.UserServices;


//namespace MVCConsumeWebAPI.Controllers.UserController
//{
//    public class MessageControllerOldWebService : Controller
//    {

//        IMessageService messageService = new MessageService();
//        // GET: Message
//        public ActionResult Index()
//        {


//            HttpClient Client = new HttpClient();
//            // Client.BaseAddress = new Uri("http://localhost:18080");
//            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/message/getMessages").Result;
//            if (response.IsSuccessStatusCode)
//            {
//                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Models.Message>>().Result;

//            }

//            else
//            {
//                ViewBag.result = "error";
//            }

//            return View(ViewBag.result);
//        }

//        // GET: Message/Details/5
//        public ActionResult Details(int id)
//        {
//            Models.Message message = null;

//            HttpClient Client = new HttpClient();
//            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/message/getMessage/" + id).Result;
//            if (response.IsSuccessStatusCode)
//            {
//                message = response.Content.ReadAsAsync<Models.Message>().Result;

//            }

//            else
//            {
//                ViewBag.result = "error";
//            }



//            return View(message);
//        }

//        // GET: Message/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Message/Create
//        [HttpPost]
//        public ActionResult Create(Message message)
//        {
//            // try
//            {




//                ApplicationUser user = (ApplicationUser)Session["dotNetUserWithJeeUserID"];

//                UserId userMessage = new UserId();
//                userMessage.id = user.Id;
//                message.user = userMessage;
//                //message.user.id = 1;
//                HttpClient Client = new HttpClient();
//                HttpResponseMessage response = Client.PostAsJsonAsync<Message>("http://localhost:18080/gestion-resources-humaine-web/api/adnene/message/addMessage", message).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

//                if (response.IsSuccessStatusCode)
//                    return RedirectToAction("Index");
//                else
//                    return View();
//            }
//            // catch
//            {
//                return View();
//            }
//        }

//        // GET: Message/Edit/5
//        public ActionResult Edit(int id)
//        {
//            Models.Message message = null;

//            HttpClient Client = new HttpClient();
//            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/message/getMessage/" + id).Result;
//            if (response.IsSuccessStatusCode)
//            {
//                message = response.Content.ReadAsAsync<Models.Message>().Result;

//            }

//            else
//            {
//                ViewBag.result = "error";
//            }



//            return View(message);
//        }

//        // POST: Message/Edit/5
//        [HttpPost]
//        public ActionResult Edit(Message message)
//        {
//            try
//            {
//                //User user = new Models.User();
//                //user.id = 1;
//                //message.user = user;
//                HttpClient Client = new HttpClient();
//                HttpResponseMessage response = Client.PutAsJsonAsync<Message>("http://localhost:18080/gestion-resources-humaine-web/api/adnene/message/updateMessage", message).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

//                if (response.IsSuccessStatusCode)
//                    return RedirectToAction("Index");
//                else
//                    return View();
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Message/Delete/5
//        [HttpDelete]
//        public void Delete(int id)
//        {

//            //void car vu on a async et ajax meme avec return to action ou view la page ne s'actualise pas  ViewData["Success"] = true;
//            HttpClient Client = new HttpClient();
//            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//            HttpResponseMessage response = Client.DeleteAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/message/deleteMessage/" + id).Result;
//            //if (response.IsSuccessStatusCode)
//            //{
//            //    return RedirectToAction("Index");

//            //}
//            //return RedirectToAction("Index");


//        }

//        // POST: Message/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }


//        public ActionResult FirstAjax(string emailsNumber)
//        {
//            return Json(emailsNumber, JsonRequestBehavior.AllowGet);
//        }



//        //GET
//        public ActionResult CreateMessage()
//        {

//            return View();
//        }
//        //POST
//        [HttpPost]
//        public ActionResult CreateMessage(Message m)
//        {
//            message msg = new message();
//            msg.sujet = m.sujet;
//            msg.contenu = m.contenu;
//            msg.dateEnvoie = m.dateEnvoie;

//            messageService.Add(msg);
//            messageService.Commit();

//            return View();
//        }



//    }
//}
