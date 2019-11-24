using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class CellTemplate
    {
        public CellTemplate()
        {
        }

        public CellTemplate(string templateName)
        {
            TemplateName = templateName;
        }

        public string TemplateName { get; set; }
    }
}
