//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Graphics;
//using System.Drawing;

//namespace MVCConsumeWebApi.Controllers
//{
//    public class PDFController : Controller
//    {
//        // GET: PDF
//        public ActionResult Index()
//        {
//            return View();
//        }
//        //Syncfusion.Pdf.AspNet.Mvc
//        public void CreateDocument()
//        {
////Create an instance of PdfDocument.
//using (PdfDocument document = new PdfDocument())
//            {
//                //Add a page to the document
//                PdfPage page = document.Pages.Add();

//                //Create PDF graphics for the page
//                PdfGraphics graphics = page.Graphics;

//                //Set the standard font
//                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

//                //Draw the text
//                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

//                // Open the document in browser after saving it
//                document.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
//            }
//        }

//        //Rotativa 




//    }
//}