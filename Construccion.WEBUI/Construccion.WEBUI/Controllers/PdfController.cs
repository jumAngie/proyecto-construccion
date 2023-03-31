using Construccion.WEBUI.Models;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Controllers
{
    public class PdfController : Controller
    {
        private readonly HttpClient _httpClient;

        public PdfController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("/CreatePDF/Reporte")]
        public async Task<IActionResult> Index()
        {
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName != "" && UserName != null)
            {
                ViewBag.Admin = HttpContext.Session.GetString("user_EsAdmin");
                ViewBag.Nombre = HttpContext.Session.GetString("empl_Nombre");
                ViewBag.Mensaje = HttpContext.Session.GetString("Mensaje");
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/List");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseAPI<EmpleadosViewModel>>(content);
                    
                    string pdfPathFolder = @"..\Construccion.WEBUI\wwwroot\PDF";
                    if (!Directory.Exists(pdfPathFolder))
                    {
                        Directory.CreateDirectory(pdfPathFolder);
                    }

                    string fileName = "MyStatement.pdf";
                    string fullFilePath = System.IO.Path.Combine(pdfPathFolder, fileName);
                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.CP1252, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                    DeviceRgb purpleColour = new(0, 128, 128);
                    DeviceRgb offPurpleColour = new(250, 250, 229);

                    PdfDocument pdfDocument = new(new PdfWriter(new FileStream(fullFilePath, FileMode.Create, FileAccess.Write)));
                    Document document = new(pdfDocument, PageSize.A4, false);
                    document.SetMargins(20, 20, 20, 40);
                    document.Add(new Paragraph("Listado de empleados.").SetFont(font).SetFontColor(purpleColour).SetFontSize(22F).SetWidth(400).SetTextAlignment(TextAlignment.CENTER).SetMarginLeft(100F));
                    Table transactionsTable = new Table(new float[] { 70, 70, 70, 70, 70, 70,70 }).SetFont(font).SetFontSize(10F).SetFontColor(ColorConstants.BLACK).SetBorder(Border.NO_BORDER).SetMarginTop(10);
                    transactionsTable.AddCell(new Cell(1, 7).Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetFontSize(11F).SetBorderBottom(new SolidBorder(purpleColour, 1F)));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("Id")).SetBorder(Border.NO_BORDER).SetFontSize(11F).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("DNI")).SetBorder(Border.NO_BORDER).SetFontSize(11F).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("Nombre")).SetBorder(Border.NO_BORDER).SetFontSize(11F).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("CorreoElectronico")).SetBorder(Border.NO_BORDER).SetFontSize(11F).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("Cargo")).SetBorder(Border.NO_BORDER).SetFontSize(11F).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("Direccion Exacta")).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell().Add(new Paragraph("Fecha de nacimiento")).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(purpleColour, 0.5F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour));
                    transactionsTable.AddCell(new Cell(1, 7).Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(purpleColour, 1F)).SetBorderRight(new SolidBorder(ColorConstants.WHITE, 0.5F)).SetFontColor(purpleColour).SetBackgroundColor(offPurpleColour));
                    var res = result.data;

                    int backgroundCounter = 0;
                    for (int i = 0; i < res.Count; i++)
                    {
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].empl_Id.ToString())).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                            .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK));
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].empl_DNI)).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                            .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK).SetKeepTogether(true));
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].empl_Nombre)).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                            .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK).SetTextAlignment(TextAlignment.RIGHT));
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].empl_CorreoEletronico)).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                            .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK).SetTextAlignment(TextAlignment.RIGHT));
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].carg_Cargo)).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                            .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK).SetTextAlignment(TextAlignment.RIGHT));
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].empl_DireccionExacta.ToString())).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                       .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK).SetTextAlignment(TextAlignment.RIGHT));
                        transactionsTable.AddCell(new Cell().Add(new Paragraph(res[i].empl_FechaNacimiento.ToString())).SetBackgroundColor((backgroundCounter % 2 == 0) ? ColorConstants.WHITE : offPurpleColour)
                       .SetBorder(new SolidBorder(ColorConstants.WHITE, 1F)).SetFontColor(ColorConstants.BLACK).SetTextAlignment(TextAlignment.RIGHT));
                        backgroundCounter++;
                    }


                    document.Add(transactionsTable);


                    pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new PDFHeaderEventHandler());
                    PDFFooterEventHandler currentEvent = new();
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, (IEventHandler)currentEvent);
                    document.Close();
                    return View();
                }
                else
                {
                    // manejar error
                    return null;
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
