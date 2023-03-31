using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using System;

namespace Construccion.WEBUI.Controllers
{
    public class PDFHeaderEventHandler : IEventHandler
    {
        public void HandleEvent(Event currentEvent)
        {
            try
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent; 
                string logoPath = @"..\Construccion.WEBUI\Construccion.WEBUI\wwwroot\Content\images\ACROPOLIS-LOGO.png";
                var logo = ImageDataFactory.Create(logoPath);
                PdfPage page = docEvent.GetPage();
                PdfDocument pdf = docEvent.GetDocument();
                Rectangle pageSize = page.GetPageSize();
                PdfCanvas pdfCanvas = new(page.GetLastContentStream(), page.GetResources(), pdf);
                if (pdf.GetPageNumber(page) == 1)
                {
                    //i want the logo just on page 1
                    pdfCanvas.AddImageAt(logo, pageSize.GetWidth() - logo.GetWidth() - 480, pageSize.GetHeight() - logo.GetHeight() - 15, true);
                    _ = new Canvas(pdfCanvas, pageSize);
                }
                else
                {
                    _ = new Canvas(pdfCanvas, pageSize);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}