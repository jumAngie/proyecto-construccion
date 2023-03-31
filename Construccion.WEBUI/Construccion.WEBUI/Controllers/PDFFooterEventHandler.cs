using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace Construccion.WEBUI.Controllers
{
    public class PDFFooterEventHandler : IEventHandler
    {
        public void HandleEvent(Event currentEvent)
        {
            try
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
                PdfPage page = docEvent.GetPage();
                PdfDocument pdf = docEvent.GetDocument();
                Rectangle pageSize = page.GetPageSize();
                PdfCanvas pdfCanvas = new(page.GetLastContentStream(), page.GetResources(), pdf);
                int pageNumber = pdf.GetPageNumber(page);
                int numberOfPages = pdf.GetNumberOfPages();
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.CP1252, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                DeviceRgb offPurpleColour = new(250, 250, 229);
                float[] tableWidth = { 445, 50F };
                Table footerTable = new Table(tableWidth).SetFixedPosition(0F, 15F, pageSize.GetWidth()).SetBorder(Border.NO_BORDER);

                var botom = pageSize.GetBottom() + 15F;
                var getwidth = pageSize.GetWidth();

                footerTable.AddCell(new Cell().Add(new Paragraph("@ACROPOLIS CONSTRUCTION"))
                                    .SetFont(font).SetFontSize(7F).SetBackgroundColor(offPurpleColour).SetBorder(Border.NO_BORDER).SetPaddingLeft(25F).SetPaddingRight(10F));

                Canvas canvas = new(pdfCanvas, pageSize);
                canvas.Add(footerTable).SetBorder(Border.NO_BORDER);

            }
            catch (Exception)
            {
                //_logger.LogError(ex, "An error occurred while in HandleEvent method in PDFFooterEventHandler class : {RequestId}");
                throw;
            }
        }

        public void WritePageNumbers(PdfDocument pdf, Document document)
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.CP1252, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
            DeviceRgb offPurpleColour = new(250, 250, 229);
            int numberOfPages = pdf.GetNumberOfPages();

            for (int i = 1; i <= numberOfPages; i++)
            {
                // Write aligned text to the specified by parameters point
                document.ShowTextAligned(new Paragraph("Pagina " + i + " of " + numberOfPages).SetFont(font).SetFontSize(7F).SetBackgroundColor(offPurpleColour).SetBorder(Border.NO_BORDER).SetWidth(50F).SetPaddings(8F, 28F, 9F, 7F).SetTextAlignment(TextAlignment.RIGHT),
                        555, 15.5f, i, TextAlignment.CENTER, VerticalAlignment.BOTTOM, 0);
            }
        }
    }
}