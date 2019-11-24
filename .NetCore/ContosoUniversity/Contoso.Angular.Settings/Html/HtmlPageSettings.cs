using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Html
{
    public class HtmlPageSettings
    {
        public HtmlPageSettings()
        {
        }

        public HtmlPageSettings
        (
            [Comments("Template when the page will be used for markup.")]
            ContentTemplate contentTemplate = null,

            [Comments("Template when the page will be used to display a message or ask a question.")]
            MessageTemplate messageTemplate = null
        )
        {
            ContentTemplate = contentTemplate;
            MessageTemplate = messageTemplate;
        }

        //public HtmlPageSettings
        //(
        //    [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
        //    [Comments("Header text for the page")]
        //    string title,

        //    [Comments("HTML template for the page markup.")]
        //    [NameValue(AttributeNames.DEFAULTVALUE, "(customTemplate)")]
        //    string templateName
        //)
        //{
        //    Title = title;
        //    TemplateName = templateName;
        //}

        public ContentTemplate ContentTemplate { get; set; }
        public MessageTemplate MessageTemplate { get; set; }
    }
}
