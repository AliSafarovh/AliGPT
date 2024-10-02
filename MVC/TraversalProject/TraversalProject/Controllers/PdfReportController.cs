using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("TraverSal Rezervl'rin siyahisi ");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Ziyarətçi adı");
            pdfPTable.AddCell("Ziyarətçi Soyadı");
            pdfPTable.AddCell("Ziyarətçi Fin kodu");

            pdfPTable.AddCell("Həsən");
            pdfPTable.AddCell("Məmmədov");
            pdfPTable.AddCell("11111111110");

            pdfPTable.AddCell("Tural");
            pdfPTable.AddCell("Əliyev");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell("Məmməd");
            pdfPTable.AddCell("Vəliyev");
            pdfPTable.AddCell("44444444445");

            document.Add(pdfPTable);

            document.Close();
            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya1.pdf");
        }
    }
}

