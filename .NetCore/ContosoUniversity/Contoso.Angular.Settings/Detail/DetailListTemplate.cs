using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public class DetailListTemplate
    {
        public DetailListTemplate()
        {
        }

        public DetailListTemplate
        (
            [Comments("HTML template for the list.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "listTemplate")]
            string templateName
        )
        {
            TemplateName = templateName;
        }

        public string TemplateName { get; set; }
    }
}
