using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public class DetailGroupTemplate
    {
        public DetailGroupTemplate()
        {
        }

        public DetailGroupTemplate
        (
            [Comments("HTML template for the group.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "groupTemplate")]
            string templateName
        )
        {
            TemplateName = templateName;
        }

        public string TemplateName { get; set; }
    }
}
