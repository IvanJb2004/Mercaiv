using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using Mercaiv.Models.Servicio;
using Mercaiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iText.Layout;

namespace Mercaiv.Controllers
{
    public class pdfClienteController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoriopdfCliente irepositoriopdf;

        public pdfClienteController(IConfiguration configuration, IRepositoriopdfCliente irepositoriopdf)
        {
            _configuration = configuration;
            this.irepositoriopdf = irepositoriopdf;
        }
        public IActionResult PdfCliente()
        {
            return View();
        }
        public IActionResult ListaCliente()
        {
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            document.Add(new Paragraph("Listado De Cliente")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(6, true);
            table.AddHeaderCell("Indentificacion");
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Apellido");
            table.AddHeaderCell("Genero");
            table.AddHeaderCell("Fecha");
            table.AddHeaderCell("Correo");
        

           RegistrarModel registrarModel = new RegistrarModel();
            var personas = irepositoriopdf.pdfCliente(registrarModel);
            foreach (var persona in personas)
            {
                table.AddCell(persona.Identificacion);
                table.AddCell(persona.Nombre);
                table.AddCell(persona.Apellido);
                table.AddCell(persona.Genero);
                table.AddCell(persona.Fecha);
                table.AddCell(persona.Correo);
                //table.AddCell(persona.Marca);
                //table.AddCell(persona.Color);
            }
            document.Add(table);
            document.Close();

            byte[] pdfbyte = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=Cliente.pdf");
            return File(pdfbyte, "application/pdf");
        }
    }
}
