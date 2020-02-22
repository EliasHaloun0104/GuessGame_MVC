using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;

namespace GuessGame.Models
{
    public class PrintModel
    {
        public static string Title(string text, int size)
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "container w-75 p-3 text-center");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "h"+size+ " m-2 shadow bg-transparent rounded");
                writer.AddAttribute(HtmlTextWriterAttribute.Style, "font-family: Merriweather, serif; color: cadetblue; padding: 10px");
                writer.RenderBeginTag(HtmlTextWriterTag.H1); // Begin #2
                writer.Write(text);
                writer.RenderEndTag(); // End #2
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();           
        }
        
        public static string SubTitle(string text, int size)
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "container p-3");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "h"+size+ " m-2 shadow bg-transparent rounded");
                writer.AddAttribute(HtmlTextWriterAttribute.Style, "font-family: Merriweather, serif; color: cadetblue; padding: 10px");
                writer.RenderBeginTag(HtmlTextWriterTag.H1); // Begin #2
                writer.Write(text);
                writer.RenderEndTag(); // End #2
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();           
        }


        public static string Paragraph(string text)
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "text-justify");
                writer.RenderBeginTag(HtmlTextWriterTag.P); // Begin #1               
                writer.Write(text);
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
    }
}
