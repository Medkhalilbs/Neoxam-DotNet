//using EAGetMail;
//using Kendo.Mvc.UI;
//using MVCConsumeWebAPI.Models;
//using System;
//using System.Collections.Generic;
//using MVCConsumeWebAPI.Extensions;
//using System.Diagnostics;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;
//using Kendo.Mvc.Extensions;
//using PI_Neoxam_GRH.Domain.Enities;
//using PI_Neoxam_GRH.Services.UserServices;
//using PI_Neoxam_GRH.Data;

//namespace MVCConsumeWebAPI.Controllers.UserController
//{
//    public class MessageController : Controller
//    {

//        IMessageService messageService = new MessageService();
//        IUserService serviceUser = new UserService();
//        public static Context neoxamdbContext = new Context();
//        // GET: Message
//        public ActionResult Index()
//        {
//            string userLogin = User.Identity.Name;
//            // List<message> listeMessages = messageService.GetMany(myMessage => ((myMessage.destinataire.Equals(userLogin)) || (myMessage.visibiliteMessage.Equals("public")) ) &&(!myMessage.statusMessage.Equals("archived"))).ToList();
//            List<message> listeMessages = neoxamdbContext.messages.Where(myMessage => ((myMessage.destinataire.Equals(userLogin)) || (myMessage.visibiliteMessage.Equals("public"))) && (!myMessage.statusMessage.Equals("archived"))).ToList();
//            List<Message> listeMessagesModel = new List<Message>();

//            foreach (message msg in listeMessages)
//            {
//                Message msgModel = new Message();
//                msgModel.id = msg.id;
//                msgModel.contenu = msg.contenu;
//                msgModel.dateEnvoie = msg.dateEnvoie;
//                msgModel.dateLecture = msg.dateLecture;
//                msgModel.destinataire = msg.statusMessage;
//                msgModel.sujet = msg.sujet;
//                msgModel.visibiliteMessage = msg.visibiliteMessage;
//                msg.user = serviceUser.Get(u => u.id == msg.user_id);

//                if (msg.user != null)
//                {
//                    User userModel = new User();
//                    msgModel.user = userModel;
//                    msgModel.user.id = msg.user.id;
//                    msgModel.user.role = msg.user.role;
//                    msgModel.user.email = msg.user.email;
//                    msgModel.user.login = msg.user.login;
//                    msgModel.user.first_name = msg.user.first_name;
//                    msgModel.user.last_name = msg.user.last_name;
//                    msgModel.user.cin = msg.user.cin;
//                    msgModel.user.street = msg.user.street;
//                    msgModel.user.state = msg.user.state;
//                    msgModel.user.country = msg.user.country;
//                    msgModel.user.city = msg.user.city;
//                    msgModel.user.zipCode = msg.user.zipCode;
//                    msgModel.user.house_number = msg.user.house_number;
//                    msgModel.user.phone_number = msg.user.phone_number;
//                    msgModel.user.status = msg.user.status;
//                }
//                listeMessagesModel.Add(msgModel);

//            }


//            return View(listeMessagesModel);
//        }


//        public ActionResult IndexSent()
//        {
//            string userLogin = User.Identity.Name;
//            user me = neoxamdbContext.users.Where(u => u.login == userLogin).Single();

//            // List<message> listeMessages = messageService.GetMany(myMessage => ((myMessage.destinataire.Equals(userLogin)) || (myMessage.visibiliteMessage.Equals("public")) ) &&(!myMessage.statusMessage.Equals("archived"))).ToList();
//            List<message> listeMessages = neoxamdbContext.messages.Where(myMessage => ((myMessage.user_id == me.id)) && (!myMessage.statusMessage.Equals("archived"))).ToList();
//            List<Message> listeMessagesModel = new List<Message>();

//            foreach (message msg in listeMessages)
//            {
//                Message msgModel = new Message();
//                msgModel.id = msg.id;
//                msgModel.contenu = msg.contenu;
//                msgModel.dateEnvoie = msg.dateEnvoie;
//                msgModel.dateLecture = msg.dateLecture;
//                msgModel.destinataire = msg.statusMessage;
//                msgModel.sujet = msg.sujet;
//                msgModel.visibiliteMessage = msg.visibiliteMessage;
//                msg.user = serviceUser.Get(u => u.id == msg.user_id);

//                if (msg.user != null)
//                {
//                    User userModel = new User();
//                    msgModel.user = userModel;
//                    msgModel.user.id = msg.user.id;
//                    msgModel.user.role = msg.user.role;
//                    msgModel.user.email = msg.user.email;
//                    msgModel.user.login = msg.user.login;
//                    msgModel.user.first_name = msg.user.first_name;
//                    msgModel.user.last_name = msg.user.last_name;
//                    msgModel.user.cin = msg.user.cin;
//                    msgModel.user.street = msg.user.street;
//                    msgModel.user.state = msg.user.state;
//                    msgModel.user.country = msg.user.country;
//                    msgModel.user.city = msg.user.city;
//                    msgModel.user.zipCode = msg.user.zipCode;
//                    msgModel.user.house_number = msg.user.house_number;
//                    msgModel.user.phone_number = msg.user.phone_number;
//                    msgModel.user.status = msg.user.status;
//                }
//                listeMessagesModel.Add(msgModel);

//            }


//            return View(listeMessagesModel);
//        }

//        // GET: Message/Details/5
//        public ActionResult Details(int id)
//        {

//            //message MessageDetails = messageService.Get(u => u.id == id);
//            message MessageDetails = neoxamdbContext.messages.Find(id);
//            MessageDetails.user = neoxamdbContext.users.Find(MessageDetails.user_id);

//            string login = User.Identity.Name;
//            if (MessageDetails.user.login != login && MessageDetails.dateLecture == null)

//            {

//                MessageDetails.dateLecture = DateTime.Now;
//                //messageService.Update(MessageDetails);
//                //messageService.Commit();
//                neoxamdbContext.SaveChanges();
//            }

//            return View(MessageDetails);
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


//            message msg = new message();
//            msg.sujet = message.sujet;
//            msg.contenu = message.contenu;
//            msg.destinataire = message.destinataire;
//            msg.dateEnvoie = DateTime.Now;
//            msg.statusMessage = "active";
//            msg.visibiliteMessage = message.visibiliteMessage;

//            string userLogin = User.Identity.Name;
//            msg.user_id = serviceUser.Get(u => u.login.Equals(userLogin)).id;
//            msg.user = serviceUser.Get(u => u.login.Equals(userLogin));

//            //neoxamdbContext.messages.Add(msg);
//            //neoxamdbContext.SaveChanges();
//            messageService.Add(msg);
//            messageService.Commit();

//            return RedirectToAction("Index");
//            //return View();

//        }

//        // GET: Message/Edit/5
//        public ActionResult Edit(int id)
//        {
//            Message messageModel = new Message();
//            message MessageDetails = messageService.Get(u => u.id == id);
//            messageModel.id = MessageDetails.id;
//            messageModel.contenu = MessageDetails.contenu;
//            messageModel.sujet = MessageDetails.sujet;
//            messageModel.destinataire = MessageDetails.destinataire;
//            messageModel.visibiliteMessage = MessageDetails.visibiliteMessage;
//            return View(messageModel);
//        }

//        // POST: Message/Edit/5
//        [HttpPost]
//        public ActionResult Edit(Message message)
//        {
//            message MessageDetails = neoxamdbContext.messages.Find(message.id);
//            // message MessageDetails = messageService.Get(u => u.id == message.id);

//            //message msg = new message();
//            MessageDetails.sujet = message.sujet;
//            MessageDetails.contenu = message.contenu;
//            MessageDetails.destinataire = message.destinataire;
//            MessageDetails.visibiliteMessage = message.visibiliteMessage;
//            //string userLogin = User.Identity.Name;
//            //MessageDetails.user_id = serviceUser.Get(u => u.login.Equals(userLogin)).id;
//            neoxamdbContext.SaveChanges();

//            //messageService.Update(MessageDetails);
//            //messageService.Commit();

//            return RedirectToAction("Index");

//            return View();

//        }

//        // GET: Message/Delete/5
//        [HttpDelete]
//        public void Delete(int id)
//        {
//            message updateMessage = neoxamdbContext.messages.Find(id);
//            //message updateMessage = messageService.Get(u => u.id == id);

//            updateMessage.statusMessage = "archived";
//            neoxamdbContext.SaveChanges();

//            //messageService.Update(updateMessage);
//            //messageService.Commit();


//        }

//        // POST: Message/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {

//            return View();
//        }


//        public ActionResult FirstAjax(string emailsNumber)
//        {
//            return Json(emailsNumber, JsonRequestBehavior.AllowGet);
//        }



//        public JsonResult GetAutoCompleteMessages(string text)
//        {
//            if (!string.IsNullOrEmpty(text))
//            {
//                neoxamdbContext.Configuration.ProxyCreationEnabled = false;
//                var users = neoxamdbContext.users.Where(p => (p.login.Contains(text)) || (p.email.Contains(text)));
//                //var users = serviceUser.GetAll().Where(p => (p.login.Contains(text)) || ( p.email.Contains(text))).ToList();
//                users.Select(x => new { email = x.email, login = x.login });

//                return Json(users, JsonRequestBehavior.AllowGet);
//            }
//            return Json(null, JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult doesLoginExist(string destinataire)
//        {

//            var Existeuser = serviceUser.Get(u => u.login.Equals(destinataire));
//            return Json(Existeuser != null, JsonRequestBehavior.AllowGet);

//        }








//    }
//}
