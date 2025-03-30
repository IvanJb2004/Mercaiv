using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Document = iText.Layout.Document;

namespace Mercaiv.Controllers
{
    public class pdfContactanosController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoriopdfContactanos irepositoriopdf;

        public pdfContactanosController (IConfiguration configuration, IRepositoriopdfContactanos irepositoriopdf)
        {
            _configuration = configuration;
            this.irepositoriopdf = irepositoriopdf;
        }
        public IActionResult PdfContactanos()
        {
            return View();
        }
        public IActionResult ListaContactanos()
        {
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            document.Add(new Paragraph("Listado De Mensaje")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(3, true);
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Correo");
            table.AddHeaderCell("Mensaje");
           

            InfoContactoModel insertarProductoModel = new InfoContactoModel();
            var personas = irepositoriopdf.pdfContactanos(insertarProductoModel);
            foreach (var persona in personas)
            {
                table.AddCell(persona.Nombre);
                table.AddCell(persona.Correo);
                table.AddCell(persona.Mensaje);
             
            }
            document.Add(table);
            document.Close();

            byte[] pdfbyte = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=Inventario.pdf");
            return File(pdfbyte, "application/pdf");
        }
    }
}
