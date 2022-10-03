using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using PdfSharp;
using System.IO;

namespace serialGeneratorGUI
{
    internal class Printing
    {
        public void doPdf(ListBox listForm1)
        {
            //Create PDF Document
            PdfDocument document = new PdfDocument();
            //You will have to add Page in PDF Document
            PdfPage page = document.AddPage();
            //For drawing in PDF Page you will nedd XGraphics Object
            XGraphics gfx = XGraphics.FromPdfPage(page);
            //For Test you will have to define font to be used
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
            //Finally use XGraphics & font object to draw text in PDF Page

            int h = 0;
            foreach (var item in listForm1.Items)
            {
                gfx.DrawString(item.ToString(), font, XBrushes.Black,
                new XRect(0, h, page.Width, page.Height), XStringFormats.TopLeft);
                h = h+12;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "pdf";
            dlg.Filter = "Pdf files (*.pdf)|*.pdf |Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.ShowDialog();

            string filename = dlg.FileName;
            document.Save(filename);
            //Load PDF File for viewing
            Process.Start(filename);

        }
    }
}
