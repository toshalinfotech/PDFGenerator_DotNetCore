using System.IO;
using System.Text;

namespace PDFGenerator.Utility
{
    public class PDFTemplateProcessor
    {
        public static string GetPDFFirstPage()
        {
            StringBuilder pdfContent = GetPDFContentBody("PDFPage1.html");
            return pdfContent.ToString();
        }

        public static string GetPDFSecondPage()
        {
            StringBuilder pdfContent = GetPDFContentBody("PDFPage2.html");
            return pdfContent.ToString();
        }

        private static StringBuilder GetPDFContentBody(string templateName)
        {
            string filepath = "Templates/" + templateName;
            StringBuilder content = new StringBuilder();
            using (StreamReader reader = new StreamReader(filepath))
            {
                content.Append(reader.ReadToEnd());
            }
            return content;
        }
    }
}
