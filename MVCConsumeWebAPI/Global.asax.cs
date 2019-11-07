using ActiveUp.Net.Mail;
using EAGetMail;
using MVCConsumeWebAPI.Controllers;
using MVCConsumeWebAPI.Controllers.UserController;
using MVCConsumeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCConsumeWebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Imap4Client _imap = new Imap4Client();
        public static Mailbox inbox = new Mailbox();
        public static int lastMailsKnownNumber = 0;
        public static Mail[] mails;
        public static List<Mail> listMails = new List<Mail>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());




            Debug.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            string tempFolder = "c:\\temp";
            if (!System.IO.Directory.Exists(tempFolder))
                System.IO.Directory.CreateDirectory(tempFolder);
            var p = new MvcApplication();
            MvcApplication.ConnectToGmailAccountAndGetOrUpdateMails();
            EmailController.liste = listMails;

            listMails.ForEach(e =>
            {
                System.Console.WriteLine("From=" + e.From + " Subject=" + e.Subject + " Body=" + e.TextBody);
                foreach (EAGetMail.Attachment a in e.Attachments)
                {
                    System.Console.WriteLine("Attachments" + a.Name);
                    string attname = String.Format("{0}\\{1}", tempFolder, a.Name);
                    a.SaveAs(attname, true);
                }
            });

            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(StartIdleProcess);

            if (worker.IsBusy)
                worker.CancelAsync();

            worker.RunWorkerAsync();



        }




        private void StartIdleProcess(object sender, DoWorkEventArgs e)
        {


            if (_imap != null && _imap.IsConnected)
            {
                _imap.StopIdle();
                _imap.Disconnect();
            }

            _imap.ConnectSsl("imap.gmail.com", 993);
            _imap.Login("makerlab2018@gmail.com", "maker2018");

            inbox = _imap.SelectMailbox("INBOX");


            _imap.NewMessageReceived += new NewMessageReceivedEventHandler(NewMessageReceived);

            inbox.Subscribe();

            _imap.StartIdle();
        }

        public static void NewMessageReceived(object source, NewMessageReceivedEventArgs e)
        {
            //int offset = e.MessageCount - 2;
            System.Console.WriteLine("message count" + e.MessageCount);
            //var p = new MvcApplication();
            MvcApplication.ConnectToGmailAccountAndGetOrUpdateMails();
            System.Console.WriteLine("email received and list updated");

        }


       public static void ConnectToGmailAccountAndGetOrUpdateMails()
        {


            // Gmail IMAP4 server is "imap.gmail.com"
            MailServer oServer = new MailServer("imap.gmail.com", "makerlab2018@gmail.com", "maker2018", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");

            // Set SSL connection,
            oServer.SSLConnection = true;

            // Set 993 IMAP4 port
            oServer.Port = 993;


            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                lastMailsKnownNumber = infos.Length;



                //si le tableau des emails est vide telecharger tout les emails maintenant dans un tabelau et une liste
                if (listMails.Count == 0)
                {
                    //mails = oClient.FetchMails(false);
                    for (int i = 0; i < infos.Length; i++)
                    {
                        Mail tempMail = oClient.GetMail(infos[i]);
                        //tempMail.Subject = tempMail.Subject.Replace("(Trial Version)", "");
                        tempMail.HtmlBody.Remove(0, 25);
                        // tempMail.Tag =i;
                        //tempMail.HtmlBody.Replace("</body></html>", "");
                        listMails.Add(oClient.GetMail(infos[i]));
                    }
                }
                else // sinon , telecharger seulement les nouveau mails et les ajouter dans le tableau et la liste
                {
                    for (int i = listMails.Count; i < infos.Length; i++)
                    {
                        //mails[i] = oClient.GetMail(infos[i]);
                        Mail newMail = oClient.GetMail(infos[i]);
                        //newMail.Subject =newMail.Subject.Replace("(Trial Version)", "");
                        newMail.HtmlBody.Remove(0, 25);
                        //newMail.Tag = i;
                        // newMail.HtmlBody.Replace("</body></html>", "");
                        listMails.Add(newMail);
                        System.Console.WriteLine("New mail From=" + newMail.From + " Subject=" + newMail.Subject + " Body=" + newMail.TextBody);
                    }
                }



            }
            catch (Exception e)
            { }






        }
    }
}
