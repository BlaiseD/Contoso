using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class AggregateTemplate
    {
        public AggregateTemplate()
        {
        }

        public AggregateTemplate(string templateName, List<AggregateTemplateFields> aggregates)
        {
            TemplateName = templateName;
            Aggregates = aggregates;
        }

        public string TemplateName { get; set; }
        public List<AggregateTemplateFields> Aggregates { get; set; }
    }
}
