using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public class DetailFieldTemplate
    {
        public DetailFieldTemplate()
        {
        }

        public DetailFieldTemplate
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
