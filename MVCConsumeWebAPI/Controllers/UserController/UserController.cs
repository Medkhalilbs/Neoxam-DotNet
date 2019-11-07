using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVCConsumeWebAPI.Extensions;
using MVCConsumeWebAPI.Models;
using Newtonsoft.Json.Linq;
using PI_Neoxam_GRH.Data;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.Services.UserServices;
using PI_Neoxam_GRH.Services.UsersLogService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebAPI.Controllers.UserController
{
    public class UserController : Controller
    {
        public static List<AdministratorRead> liste = new List<AdministratorRead>();
        public static List<User_log> listeUser_logs = new List<User_log>();
        IUserService serviceUser = new UserService();
        IUserLogService userLogService = new UserLogService();
        public static string fileName;
        public static string loginOfActualUserBeingEdited;
        public static string emailOfActualUserBeingEdited;
        Context neoxamdbContext = new Context();
        // GET: User
        public ActionResult Index()
        {
            Debug.WriteLine("ID=" + User.Identity.GetID());


            IEnumerable<Models.AdministratorRead> result = null;
            List<Models.User_log> listeUserLogs = new List<User_log>();
            HttpClient Client = new HttpClient();
            if (!string.IsNullOrEmpty(Session["JeeToken"] as string))
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["JeeToken"].ToString());

            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/").Result;

            if (response.IsSuccessStatusCode)
            {
                // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
                result = response.Content.ReadAsAsync<IEnumerable<Models.AdministratorRead>>().Result;
                foreach (AdministratorRead user in result)
                {
                    HttpResponseMessage response2 = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user_log/getUser_logsByUserID/" + user.id).Result;
                    if (response2.IsSuccessStatusCode)
                    {
                        IEnumerable<Models.User_log> listeUserLogsOfUser = response2.Content.ReadAsAsync<IEnumerable<Models.User_log>>().Result;
                        user.user_log = listeUserLogsOfUser;
                        foreach (User_log user_log in listeUserLogsOfUser)
                        {
                            listeUserLogs.Add(user_log);
                        }
                    }
                }

            }
            //HttpResponseMessage response3 = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user_log/getUser_Logs/").Result;
            //Debug.WriteLine("response3=" + response3.ToString());
            //Debug.WriteLine("response3=" + response3.Headers);
            //if (response3.IsSuccessStatusCode)
            //{
            //    listeUserLogs = response.Content.ReadAsAsync<IEnumerable<Models.User_log>>().Result;



            //}

            //else
            //{
            //    ViewBag.result = "error";
            //}

            liste = result.ToList<AdministratorRead>();
            listeUser_logs = listeUserLogs;
            return View(result);
        }



        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            Models.AdministratorRead user = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/getUser/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<Models.AdministratorRead>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }



            return View(user);
        }

        // GET: Message/Create
        public ActionResult Create()
        {

           



            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(User user, IEnumerable<HttpPostedFileBase> files , FormCollection form)
        {
            // try
            {

                if (files != null)
                {
                    TempData["UploadedFiles"] = Basic_Usage_Get_File_Info(files);
                }


                address adresseModel = new address();
                HttpResponseMessage response = null;
                JObject jsonObject = new JObject();
                HttpClient Client = new HttpClient();

                if (user.role.Equals("Utilisateur") || user.role.Equals("Administrateur"))
                {

                    jsonObject.Add("email", user.email);
                    jsonObject.Add("login", user.login);
                    jsonObject.Add("password", user.password);
                    //CandidateUser.registration_date = DateTime.Now;
                    //DateTime dt = DateTime.Now.ToString("yyyy - MM - dd'T'HH: mm:ss.SSSZ");
                    string dt1 = DateTime.Now.ToString("yyyy-MM-dd");
                    string dt2 = DateTime.Now.ToString("HH:mm:ss.fff");
                    string dt3 = DateTime.Now.ToString("zzz");
                    dt3 = dt3.Replace(":", "");
                    jsonObject.Add("registration_date", dt1 + "T" + dt2 + dt3);
                    jsonObject.Add("status", user.status);
                    var JsonUser = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                    if (!user.role.Equals("Administrateur"))
                        response = Client.PostAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/addUser", JsonUser).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                }
                if (user.role.Equals("Administrateur"))

                {

                    Administrator admin = new Administrator();
                    admin.email = user.email;
                    admin.login = user.login;
                    admin.password = user.password;
                    /*
                                        jsonObject.Add("phone_number", user.phone_number);
                                        jsonObject.Add("first_name", user.first_name);
                                        jsonObject.Add("last_name", user.last_name);
                     */
                    adresseModel.addressLine1 = user.house_number;
                    adresseModel.addressLine2 = user.street;
                    adresseModel.country = user.country;
                    adresseModel.city = user.city;
                    adresseModel.state = user.state;
                    adresseModel.zipCode = user.zipCode;
                    //Debug.WriteLine("latitude="+form["lat"].ToString()); 
                    adresseModel.lat = Convert.ToDouble(user.lat, new CultureInfo("en-US"));
                    adresseModel.lng = Convert.ToDouble(user.lng, new CultureInfo("en-US")); //"en-US" car '.' ou lieu de ';'
                    /*
                                        var JsonAdresse = new JavaScriptSerializer().Serialize(adresseModel);

                                        //string JsonAdresse = JsonConvert.SerializeObject(adresseModel);
                                        jsonObject.Add("address", JsonAdresse);
                                        //jsonObject.Add("address", JsonAdresse);
                                        //jsonObject.Add("address", JsonAdresse);
                                        var JsonUser = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                                        Debug.WriteLine("JsonUser=" + JsonUser.ReadAsStringAsync());

                    */
                    admin.phone_number = user.phone_number;
                    admin.first_name = user.first_name;
                    admin.last_name = user.last_name;
                    admin.cin = user.cin;
                    admin.picture = user.picture;
                    admin.address = adresseModel;
                    admin.status = user.status;
                    admin.picture = fileName;
                    fileName = "";
                    response = Client.PostAsJsonAsync<Administrator>("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/addAdministrator", admin).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                }




                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            // catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            Models.UserEdit userModel = new Models.UserEdit();

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/getUser/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Models.Administrator admin = response.Content.ReadAsAsync<Models.Administrator>().Result;
                if (admin.address != null)
                {
                    userModel.house_number = admin.address.addressLine1;
                    userModel.street = admin.address.addressLine2;
                    userModel.country = admin.address.country;
                    userModel.city = admin.address.city;
                    userModel.state = admin.address.state;
                    userModel.lat = admin.address.lat;
                    userModel.lng = admin.address.lng;
                }
                userModel.email = admin.email;
                userModel.login = admin.login;
                loginOfActualUserBeingEdited = admin.login;
                emailOfActualUserBeingEdited = admin.email;
                userModel.password = admin.password;
                userModel.first_name = admin.first_name;
                userModel.last_name = admin.last_name;
                userModel.id = admin.id;
                userModel.cin = admin.cin;
                userModel.picture = admin.picture;
                userModel.phone_number = admin.phone_number;


            }

            else
            {
                ViewBag.result = "error";
            }



            return View(userModel);
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(User user, IEnumerable<HttpPostedFileBase> files)
        {
            {
                // try
                {

                    if (files != null)
                    {
                        TempData["UploadedFiles"] = Basic_Usage_Get_File_Info(files);
                    }


                    address adresseModel = new address();
                    HttpResponseMessage response = null;
                    JObject jsonObject = new JObject();
                    HttpClient Client = new HttpClient();

                    if (user.role.Equals("Utilisateur") || user.role.Equals("Administrateur"))
                    {
                        jsonObject.Add("id", user.id);
                        jsonObject.Add("email", user.email);
                        jsonObject.Add("login", user.login);
                        jsonObject.Add("password", user.password);
                        //CandidateUser.registration_date = DateTime.Now;
                        //DateTime dt = DateTime.Now.ToString("yyyy - MM - dd'T'HH: mm:ss.SSSZ");
                        string dt1 = DateTime.Now.ToString("yyyy-MM-dd");
                        string dt2 = DateTime.Now.ToString("HH:mm:ss.fff");
                        string dt3 = DateTime.Now.ToString("zzz");
                        dt3 = dt3.Replace(":", "");
                        jsonObject.Add("registration_date", dt1 + "T" + dt2 + dt3);
                        jsonObject.Add("status", user.status);
                        var JsonUser = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                        if (!user.role.Equals("Administrateur"))
                            response = Client.PutAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/updateUser", JsonUser).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                    }
                    if (user.role.Equals("Administrateur"))

                    {

                        Administrator admin = new Administrator();
                        admin.id = user.id;
                        admin.email = user.email;
                        admin.login = user.login;
                        admin.password = user.password;
                        /*
                                            jsonObject.Add("phone_number", user.phone_number);
                                            jsonObject.Add("first_name", user.first_name);
                                            jsonObject.Add("last_name", user.last_name);
                         */
                        adresseModel.addressLine1 = user.house_number;
                        adresseModel.addressLine2 = user.street;
                        adresseModel.country = user.country;
                        adresseModel.city = user.city;
                        adresseModel.state = user.state;
                        adresseModel.zipCode = user.zipCode;
                        adresseModel.lat = Convert.ToDouble(user.lat, new CultureInfo("en-US"));
                        adresseModel.lng = Convert.ToDouble(user.lng, new CultureInfo("en-US")); //"en-US" car '.' ou lieu de ';'
                        /*
                                            var JsonAdresse = new JavaScriptSerializer().Serialize(adresseModel);

                                            //string JsonAdresse = JsonConvert.SerializeObject(adresseModel);
                                            jsonObject.Add("address", JsonAdresse);
                                            //jsonObject.Add("address", JsonAdresse);
                                            //jsonObject.Add("address", JsonAdresse);
                                            var JsonUser = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                                            Debug.WriteLine("JsonUser=" + JsonUser.ReadAsStringAsync());

                        */
                        admin.phone_number = user.phone_number;
                        admin.first_name = user.first_name;
                        admin.last_name = user.last_name;
                        admin.cin = user.cin;
                        admin.picture = user.picture;
                        admin.address = adresseModel;
                        admin.status = user.status;
                        admin.picture = fileName;
                        fileName = "";
                        response = Client.PutAsJsonAsync<Administrator>("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/updateAdmin", admin).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                    }




                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return View();
                }
                // catch
                {
                    return View();
                }
            }
        }

        // GET: Message/Delete/5
        [HttpDelete]
        public void Delete(int id)
        {

            //void car vu on a async et ajax meme avec return to action ou view la page ne s'actualise pas  ViewData["Success"] = true;
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.DeleteAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/deleteUser/" + id).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");

            //}
            //return RedirectToAction("Index");


        }

        //// POST: Message/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        public class userDrowndown
        {
            public string userRole { get; set; }
            public string userAuthorizations { get; set; }
            public string userPicture { get; set; }


        }
        public JsonResult GetUserDrownDownList()
        {

            List<userDrowndown> liste = new List<userDrowndown>();
            liste.Add(new userDrowndown { userRole = "Utilisateur", userAuthorizations = "Envoie/Lecture messages", userPicture = "userIcon.png" });
            liste.Add(new userDrowndown { userRole = "Administrateur", userAuthorizations = "Gestion des comptes", userPicture = "adminIcon.jpg" });
            liste.Add(new userDrowndown { userRole = "Candidat", userAuthorizations = "Envoie/Lecture message et vue profil", userPicture = "candidateIcon.png" });
            liste.Add(new userDrowndown { userRole = "Employé", userAuthorizations = "Gestion resource Humaine", userPicture = "employeeIcon.png" });


            return Json(liste, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult GoogleMapLngLatJsonPost(address model)
        {
            //googleMapModel model = new googleMapModel();
            //model.Lat = Lat;
            //model.Lng = Lng;
            // Debug.WriteLine("Lat="+model.Lat+ "/Lng=" + model.Lng);
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        private IEnumerable<string> Basic_Usage_Get_File_Info(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }




        public ActionResult UserListe([DataSourceRequest]DataSourceRequest request)
        {
            return Json(liste.OrderBy(e => e.id).ToDataSourceResult(request));
        }

        public ActionResult User_logsBinding(int id, [DataSourceRequest] DataSourceRequest request)
        {
            return Json(listeUser_logs.Where(user_log => user_log.user.id == id).ToDataSourceResult(request));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditUser([DataSourceRequest] DataSourceRequest request, AdministratorRead product)
        {
            if (product != null && ModelState.IsValid)
            {
                // productService.Update(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }


        //****************************************************************************************validation
        public JsonResult doesLoginExist(string login)
        {

            var Existeuser = serviceUser.Get(u => u.login.Equals(login));
            //return Json(Existeuser, JsonRequestBehavior.AllowGet);
            return Json(Existeuser == null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult doesEmailExist(string email)
        {

            var Existeuser = serviceUser.Get(u => u.email.Equals(email));
            //return Json(Existeuser, JsonRequestBehavior.AllowGet);
            return Json(Existeuser == null, JsonRequestBehavior.AllowGet);
        }




        public JsonResult doesLoginExistEdit(string login)
        {

            var Existeuser = serviceUser.Get(u => u.login.Equals(login));

            if (Existeuser == null || Existeuser.login == loginOfActualUserBeingEdited)
                return Json(true, JsonRequestBehavior.AllowGet);
            else

                return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult doesEmailExistEdit(string email)//retuen true if doesn't exist
        {

            var Existeuser = serviceUser.Get(u => u.email.Equals(email));

            if (Existeuser == null || Existeuser.email == emailOfActualUserBeingEdited)
                return Json(true, JsonRequestBehavior.AllowGet);
            else

                return Json(false, JsonRequestBehavior.AllowGet);
        }





        //************************ upload image
        public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    // var fileName = Path.GetFileName(file.FileName);
                    fileName = KeyGenerator.GetUniqueKey(8) + Path.GetExtension(file.FileName);
                   // DirectoryInfo di = Directory.CreateDirectory("C:\\Users\\X\\Documents\\Visual Studio 2015\\Projects\\PI-Neoxam-GRH\\MVCConsumeWebAPI\\Content\\Uploads\\Users");
                   // var physicalPath = Path.Combine(Server.MapPath("~/Content/Uploads/Users"), fileName);
                    var physicalPath = Path.Combine("C:/Users/X/devstudio/wildfly-9.0.1.Final2/standalone/deployments/gestion-resources-humaine-ear.ear/gestion-resources-humaine-web.war/uploads", fileName);


                    // The files are not actually saved in this demo
                    file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult Async_Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                //foreach (var fullName in fileNames)
                // {
                //var fileName = Path.GetFileName(fullName);
                //var physicalPath = Path.Combine(Server.MapPath("~/Content/Uploads/Users"), fileName);
                var physicalPath = Path.Combine("C:/Users/X/devstudio/wildfly-9.0.1.Final2/standalone/deployments/gestion-resources-humaine-ear.ear/gestion-resources-humaine-web.war/uploads", fileName);
                
                // TODO: Verify user permissions

                if (System.IO.File.Exists(physicalPath))
                {
                    // The files are not actually removed in this demo
                    System.IO.File.Delete(physicalPath);
                    fileName = "";
                }
                //}
            }

            // Return an empty string to signify success
            return Content("");
        }
        //**********************************************************************************************************



        public ActionResult User_logListe([DataSourceRequest]DataSourceRequest request)
        {


            int jeeUserId = User.Identity.GetJeeUserId();
            neoxamdbContext.Configuration.ProxyCreationEnabled = false;

            List <user_log> listeUserLogs2 = neoxamdbContext.user_log.Where(userlog => userlog.user_id == jeeUserId).ToList();

            //IEnumerable<Models.AdministratorRead> result = null;
            //List<Models.User_log> listeUserLogs = new List<User_log>();
            //HttpClient Client = new HttpClient();
            //if (!string.IsNullOrEmpty(Session["JeeToken"] as string))
            //    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["JeeToken"].ToString());

            //Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
            //    result = response.Content.ReadAsAsync<IEnumerable<Models.AdministratorRead>>().Result;
            //}







            
            return Json(listeUserLogs2.OrderBy(e => e.id).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyLog()
        {

            int jeeUserId = User.Identity.GetJeeUserId();
            List<user_log> listeUserLogs2 = userLogService.GetMany(u => u.user_id == jeeUserId).ToList();


            return View();


        }

        public JsonResult GetUserList(String clusterNumber, String typeAlgo,String vwidth, String vheight)
        {
            if (vwidth == "" || vheight == "")
            {
                vwidth = "1920";
                vheight = "1080";
            }

            IEnumerable<Models.AdministratorRead> result = null;
            List<Models.User_log> listeUserLogs = new List<User_log>();
            HttpClient Client = new HttpClient();
            if (!string.IsNullOrEmpty(Session["JeeToken"] as string))
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["JeeToken"].ToString());

            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user/getMarkersListe/"+ clusterNumber+"/"+ typeAlgo + "/" + vwidth + "/" + vheight).Result;

            if (response.IsSuccessStatusCode)
            {
                // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
                result = response.Content.ReadAsAsync<IEnumerable<Models.AdministratorRead>>().Result;
                //foreach (AdministratorRead user in result)
                //{
                //    HttpResponseMessage response2 = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/adnene/user_log/getUser_logsByUserID/" + user.id).Result;
                //    if (response2.IsSuccessStatusCode)
                //    {
                //        IEnumerable<Models.User_log> listeUserLogsOfUser = response2.Content.ReadAsAsync<IEnumerable<Models.User_log>>().Result;
                //        user.user_log = listeUserLogsOfUser;
                //        foreach (User_log user_log in listeUserLogsOfUser)
                //        {
                //            listeUserLogs.Add(user_log);
                //        }
                //    }
                //}

            }


            liste = result.ToList<AdministratorRead>();


            return Json(liste, JsonRequestBehavior.AllowGet);

        }







    }
}