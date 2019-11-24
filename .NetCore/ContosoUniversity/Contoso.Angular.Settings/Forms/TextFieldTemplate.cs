using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class TextFieldTemplate
    {
        public TextFieldTemplate()
        {
        }

        public TextFieldTemplate
        (
            [Comments("HTML template for the field.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "textTemplate")]
            string templateName
        )
        {
            TemplateName = templateName;
        }

        public string TemplateName { get; set; }
    }
}
