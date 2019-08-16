using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using PDFGenerator.Models;
using PDFGenerator.Utility;

namespace PDFGenerator.Controllers
{
    public class HomeController : Controller
    {
        private IConverter _converter;

        public HomeController(IConverter converter)
        {
            _converter = converter;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadPDF()
        {
            var assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "Templates\\assets");

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() { Top = 0, Left = 0, Right = 0, Bottom = 0 },
                PageOffset = 0
            };

            var page1Settings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PDFTemplateProcessor.GetPDFFirstPage(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = assetsPath + "\\styles.css" }
            };

            var page2Settings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PDFTemplateProcessor.GetPDFSecondPage(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = assetsPath + "\\styles.css" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { page1Settings, page2Settings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "MemberIDCard.pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
