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

        public static string[] GetAvatars()
        {
            var avatar = Directory.GetFiles("wwwroot/img/avatar");
            for (int i = 0; i < avatar.Length; i++)
            {
                avatar[i] = "/img/avatar/"+avatar[i].Substring(avatar[i].LastIndexOf("\\")+1);
            }

            return avatar;
        }


        public static string UserForm (UserModel userModel)
        {
            var formID = $"form{userModel.UserId}";
            var form = $"<div class=\"container\"><form id=\"{formID}\" class=\"tableRow\" action=\"\" method=\"post\">";
            form += $"<input class=\"tableCell_input\" form=\"{formID}\" name=\"userid\" value=\"{userModel.UserId}\" readonly>";
            form += $"<input class=\"tableCell_input\" form=\"{formID}\" name=\"username\" value=\"{userModel.Username}\" >";
            form += $"<input class=\"tableCell_input\" form=\"{formID}\" name=\"email\" value=\"{userModel.Email}\" >";
            form += $"<input class=\"tableCell_input\" form=\"{formID}\" name=\"password\" value=\"{userModel.Password}\" >";
            
            form += $"<input class=\"tableCell_input\" form=\"{formID}\" name=\"role\" value=\"{userModel.Role}\" >";
            form += $"<img src=\"{userModel.Avatar}\" width=64 height=64 class=\"tableCell_input\" name=\"avatar\">";
            form += "</div>";
            return form;
        }
    }
}
