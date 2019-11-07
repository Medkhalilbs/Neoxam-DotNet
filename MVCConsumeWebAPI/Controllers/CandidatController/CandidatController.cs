using MVCConsumeWebAPI.Models;
using MVCConsumeWebAPI.Extensions;

using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PI_Neoxam_GRH.Services.UserServices;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.Services.ExperienceService;
using PI_Neoxam_GRH.Services.HobbiesService;
using PI_Neoxam_GRH.Services.SkillsServices;

using MimeKit;

namespace MVCConsumeWebAPI.Controllers.CandidatController
{
    public class CandidatController : Controller
    {

        IUserService candidateService;
        IExperienceService experienceService;
        IHobbiesService hobbiesService;
        ISkillsService skillService;


        public CandidatController()
        {
            candidateService = new UserService();
            experienceService = new ExperienceService();
            hobbiesService = new HobbiesService();
            skillService = new SkillsService();
        }

        /*************************************************************************************/
        //[HttpPost]
        //public ActionResult AddPST()
        //{
        //    JObject jsonObject = new JObject();


        //    HttpClient Client = new HttpClient();
        //    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = Client.PostAsync("http://127.0.0.1:18080/gestion-resources-humaine-web/UploadPstServlet", content).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        ViewBag.message = "Success";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //        return View();
        //}





        public ActionResult AddProfileInformations()
        {
            Debug.WriteLine("TEST" + User.Identity);
            
            /*****************************retrieve informations*************************************/
            List<User> CandidateList = new List<User>();
            List<MVCConsumeWebAPI.Models.experience> ExperienceList = new List<MVCConsumeWebAPI.Models.experience>();
            List<MVCConsumeWebAPI.Models.hoby> HobbiesList = new List<MVCConsumeWebAPI.Models.hoby>();
            List<MVCConsumeWebAPI.Models.skill> skillList = new List<MVCConsumeWebAPI.Models.skill>();


            string connectionString = @"server=localhost;user id=root;database=neoxamdb" ;


            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command1 = new MySqlCommand("SELECT u.first_name,u.last_name,u.Birthdate,u.phone_number,u.Age,u.email,c.id,u.id FROM users u, cv c WHERE u.role='Candidate' and u.id="+User.Identity.GetJeeUserId() +" and u.id=c.Candidates_id", con))
                using (MySqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<Models.cv> lst = new List<Models.cv>();
                        lst.Add(new Models.cv { id = reader.GetInt32(6) });
                        CandidateList.Add(new User
                        {
                            Age=reader.GetInt32(4),
                            Birthdate= reader.GetString(2),
                            email = reader.GetString(5),
                            first_name = reader.GetString(0),
                            last_name = reader.GetString(1),
                            phone_number = reader.GetString(3),
                            cvs = lst,
                            id = reader.GetInt32(7)
                 
                        });
                    }
                }
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command1 = new MySqlCommand("SELECT addressLine1,addressLine2,city,Company_Name,country,Department,Duration,End_Date,Role,Sector,Start_Date,state,Subject,zipCode  FROM experience e JOIN cv c WHERE e.cv1_id=c.id AND c.Candidates_id=" + User.Identity.GetJeeUserId(), con))
                using (MySqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExperienceList.Add(new MVCConsumeWebAPI.Models.experience
                        {
                            addressLine1 = reader.GetString(0) ,
                            addressLine2 = reader.GetString(1),
                            city = reader.GetString(2),
                            Company_Name = reader.GetString(3),
                            country = reader.GetString(4),                         
                            Department = reader.GetString(5),
                            Duration = reader.GetInt32(6),
                            End_Date = reader.GetDateTime(7),
                            Role = reader.GetString(8),
                            Sector = reader.GetString(9),
                            Start_Date = reader.GetDateTime(10),
                            state = reader.GetString(11),
                            Subject = reader.GetString(12),
                            zipCode = reader.GetString(13)
                        });                 
                    }
                }
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command1 = new MySqlCommand("SELECT Level,Name,Place,Type FROM hobies h JOIN cv c WHERE h.cv3_id=c.id AND c.Candidates_id=" + User.Identity.GetJeeUserId() , con))
                using (MySqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HobbiesList.Add(new MVCConsumeWebAPI.Models.hoby {
                            Level = reader.GetString(0),
                            Name = reader.GetString(1),
                            Place = reader.GetString(2),
                            Type = reader.GetString(3)

                        });
                    }
                }
            }
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command1 = new MySqlCommand("SELECT Level,Name,Type FROM skills s JOIN cv c WHERE s.cv6_id=c.id AND c.Candidates_id="  + User.Identity.GetJeeUserId(), con))
                using (MySqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        skillList.Add(new MVCConsumeWebAPI.Models.skill
                        {
                            Level = reader.GetString(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2)

                        });
                    }
                }
            }
            ViewBag.skillsVB = skillList;

            ViewBag.HobbiesVB = HobbiesList;
            ViewBag.ExperienceVB = ExperienceList;
            ViewBag.CandidateVB = CandidateList;




            return View();

        }

        //[HttpPost]
        //public ActionResult AddProfileInformations(PI_Neoxam_GRH.Domain.Enities.experience experience)
        //{
        //    /*****************************retrieve informations*************************************/
        //    List<User> CandidateList = new List<User>();
        //    string connectionString = @"server=localhost;user id=root;database=neoxamdb";
        //    using (MySqlConnection con = new MySqlConnection(connectionString))
        //    {
        //        con.Open();

        //        using (MySqlCommand command1 = new MySqlCommand("SELECT first_name,last_name,Birthdate,phone_number,Age,email FROM users WHERE role='Candidate' and id=5", con))
        //        using (MySqlDataReader reader = command1.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                CandidateList.Add(new User
        //                {
        //                    Age = reader.GetInt32(4),
        //                    Birthdate = reader.GetString(2),
        //                    email = reader.GetString(5),
        //                    first_name = reader.GetString(0),
        //                    last_name = reader.GetString(1),
        //                    phone_number = reader.GetString(3)
        //                });
        //            }

        //            Debug.WriteLine(CandidateList);
        //        }
        //    }
        //    ViewBag.CandidateVB = CandidateList;
        //    /*****************************add experience *************************************/
        //    PI_Neoxam_GRH.Domain.Enities.experience experienceDomain = new PI_Neoxam_GRH.Domain.Enities.experience()
        //    {
        //        addressLine1 = experience.addressLine1,
        //        addressLine2 = experience.addressLine2,
        //        city = experience.city,
        //        Company_Name = experience.Company_Name,
        //        country = experience.country,
        //        cv1_id = 1,
        //        Department = experience.Department,
        //        Duration = experience.Duration,
        //        End_Date = experience.End_Date,
        //        Role = experience.Role,
        //        Sector = experience.Sector,
        //        Start_Date = experience.Start_Date,
        //        state = experience.state,
        //        Subject = experience.Subject,
        //        zipCode = experience.zipCode

        //    };
        //    experienceService.Add(experienceDomain);
        //    experienceService.Commit();
           

        //    return View();
        //}

    
        public ActionResult AddExperience(int cv)
        {
            ViewBag.idCv = cv;
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(PI_Neoxam_GRH.Domain.Enities.experience experience)
        {
            PI_Neoxam_GRH.Domain.Enities.experience experienceDomain = new PI_Neoxam_GRH.Domain.Enities.experience()
            {
                addressLine1 = experience.addressLine1,
                addressLine2 = experience.addressLine2,
                city = experience.city,
                Company_Name = experience.Company_Name,
                country = experience.country,
                cv1_id = experience.cv1_id,
                Department = experience.Department,
                Duration = experience.Duration,
                End_Date = experience.End_Date,
                Role = experience.Role,
                Sector = experience.Sector,
                Start_Date = experience.Start_Date,
                state = experience.state,
                Subject = experience.Subject,
                zipCode = experience.zipCode

            };
            experienceService.Add(experienceDomain);
            experienceService.Commit();

            return RedirectToAction("AddProfileInformations");
        }

        public ActionResult AddHobbies(int cv)
        {
            ViewBag.idCv = cv;
            return View();
        }

        [HttpPost]
        public ActionResult AddHobbies(PI_Neoxam_GRH.Domain.Enities.hoby hobbies)
        {
            PI_Neoxam_GRH.Domain.Enities.hoby hobbiesDomain = new PI_Neoxam_GRH.Domain.Enities.hoby()
            {
               Level = hobbies.Level,
               Name = hobbies.Name,
               Place = hobbies.Place,
               Type = hobbies.Type,
               cv3_id= hobbies.cv3_id


            };

            hobbiesService.Add(hobbiesDomain);
            hobbiesService.Commit();

            return RedirectToAction("AddProfileInformations");
        }
        public ActionResult AddSkill(int cv)
        {
            ViewBag.idCv = cv;
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(PI_Neoxam_GRH.Domain.Enities.skill skill)
        {
            PI_Neoxam_GRH.Domain.Enities.skill skillDomain = new PI_Neoxam_GRH.Domain.Enities.skill()
            {
               Level = skill.Level,
               Name = skill.Name,
               Type = skill.Type,
               cv6_id = skill.cv6_id


            };

            skillService.Add(skillDomain);
            skillService.Commit();

            return RedirectToAction("AddProfileInformations");
        }

        /*************************************************************************************/


        public ActionResult EmailSend(string candidateName,int idCandidate) {

            string connectionString = @"server=localhost;user id=root;database=neoxamdb";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command1 = new MySqlCommand("UPDATE `users` SET `ProfilValide`=1  WHERE id="+idCandidate, con))
                using (MySqlDataReader reader = command1.ExecuteReader()) ;
            }
            sendMail(candidateName);
            return RedirectToAction("Index");
        }



        // GET: Candidate
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            // Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate").Result;
          
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(ViewBag.result);
        }
       

        // GET: Candidat/Details/5
        public ActionResult Details(int id)
        {
            Models.User user = null;
            Models.experience exp = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<Models.User>().Result;
                exp = response.Content.ReadAsAsync<Models.experience>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View(user);
        }

        public ActionResult Validate(int idCandidate)
        {
            string connectionString = @"server=localhost;user id=root;database=neoxamdb";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command1 = new MySqlCommand("UPDATE `users` SET `ProfilValide`=2  WHERE id=" + idCandidate, con))
                using (MySqlDataReader reader = command1.ExecuteReader()) ;
            }
            return RedirectToAction("Index");
        }

        // GET: Candidat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidat/Create
        [HttpPost]
        public ActionResult Create(User CandidateUser)
        {
            try
            {


                HttpClient Client = new HttpClient();
                //HttpResponseMessage response = Client.PostAsJsonAsync<User>("http://localhost:18080/gestion-resources-humaine-web/api/candidate", CandidateUser).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;


                JObject jsonObject = new JObject();
                jsonObject.Add("email", CandidateUser.email);
                jsonObject.Add("login", CandidateUser.login);
                jsonObject.Add("password", CandidateUser.password);
                //CandidateUser.registration_date = DateTime.Now;
                //DateTime dt = DateTime.Now.ToString("yyyy - MM - dd'T'HH: mm:ss.SSSZ");
                string dt1 = DateTime.Now.ToString("yyyy-MM-dd");
                string dt2 = DateTime.Now.ToString("HH:mm:ss.fff");
                string dt3 = DateTime.Now.ToString("zzz");
                dt3 = dt3.Replace(":", "");
                jsonObject.Add("registration_date", dt1 + "T" + dt2 + dt3);
                jsonObject.Add("status", CandidateUser.status);
                jsonObject.Add("phone_number", CandidateUser.phone_number);
                jsonObject.Add("first_name", CandidateUser.first_name);
                jsonObject.Add("last_name", CandidateUser.last_name);
                jsonObject.Add("Birthdate", CandidateUser.Birthdate);
                jsonObject.Add("ProfilValide", CandidateUser.ProfilValide);
                jsonObject.Add("SocialState", CandidateUser.SocialState);
                jsonObject.Add("DriverLience", CandidateUser.DriverLience);
                jsonObject.Add("Age", CandidateUser.Age);
                jsonObject.Add("Description", CandidateUser.Description);
                jsonObject.Add("address", null);


                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                var response = Client.PostAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate", content).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.message = "Success";
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidat/Edit/5
        public ActionResult Edit(int id)
        {

            User Candidateuser = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Candidateuser = response.Content.ReadAsAsync<User>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }



            return View(Candidateuser);
        }

        // POST: Candidat/Edit/5
        [HttpPost]
        public ActionResult Edit(User CandidateUser)
        {
            try
            {
                HttpClient Client = new HttpClient();

                JObject jsonObject = new JObject();
                jsonObject.Add("id", CandidateUser.id);
                jsonObject.Add("email", CandidateUser.email);
                jsonObject.Add("login", CandidateUser.login);
                jsonObject.Add("password", CandidateUser.password);
                jsonObject.Add("status", CandidateUser.status);
                jsonObject.Add("phone_number", CandidateUser.phone_number);
                jsonObject.Add("first_name", CandidateUser.first_name);
                jsonObject.Add("last_name", CandidateUser.last_name);
                jsonObject.Add("Birthdate", CandidateUser.Birthdate);
                jsonObject.Add("ProfilValide", CandidateUser.ProfilValide);
                jsonObject.Add("SocialState", CandidateUser.SocialState);
                jsonObject.Add("DriverLience", CandidateUser.DriverLience);
                jsonObject.Add("Age", CandidateUser.Age);
                jsonObject.Add("Description", CandidateUser.Description);
                jsonObject.Add("address", null);

                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                //HttpResponseMessage response = Client.PutAsJsonAsync<User>("http://localhost:18080/gestion-resources-humaine-web/api/candidate", content).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;
                var response = Client.PutAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate", content).Result;

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

        // GET: Candidat/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient Client = new HttpClient();
            //Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.DeleteAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate?id=" + id).Result;

            if (response.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();

        }

        // POST: Candidat/Delete/5
        [HttpPost]
        public void Delete(User CandidateUser)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.DeleteAsync("http://localhost:18080/gestion-resources-humaine-web/api/candidate?id=" + CandidateUser).Result;
        }

        public ActionResult Chatbot()
        {
            return View();
        }


        public void sendMail(String candidateName)
        {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("no-reply-neoxam@gmail.com"));
                message.To.Add(new MailboxAddress("esprit.neoxam@gmail.com"));
                // message.Cc.Add(new MailboxAddress(reader.GetString(1)));
                message.Subject = "Candidate profile update";

                var builder = new BodyBuilder();

                builder.TextBody = "Dear Administrator,\n\nThe candidate "+ candidateName +" has updated his profile information. You may now check it out to validate it.. \n\n Have a nice day :) \n\n Best regards,\nThe System bot";

                //builder.Attachments.Add(@"C:\file\data.xlxs");

                message.Body = builder.ToMessageBody();


                var client = new MailKit.Net.Smtp.SmtpClient();

                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("esprit.neoxam@gmail.com", "054933061693");
                client.Send(message);
                client.Disconnect(true);



            //Console.ReadLine();
            //return addressmail;
        }


    }
}

