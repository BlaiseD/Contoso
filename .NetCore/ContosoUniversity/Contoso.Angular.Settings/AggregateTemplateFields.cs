using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class AggregateTemplateFields
    {
        public AggregateTemplateFields(string label,
            [Domain("average,count,max,min,sum")]
            string aggregateFunction)
        {
            Label = label;
            Function = aggregateFunction;
        }

        public string Label { get; set; }
        public string Function { get; set; }
    }
}
