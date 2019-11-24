using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class AggregateDefinition
    {
        public AggregateDefinition()
        {
        }

        public AggregateDefinition
        (
            [Comments("Update modelType first. Property name for the aggregate field. Use a period for nested fields i.e. foo.bar.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Domain("average,count,max,min,sum")]
            string aggregate,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            Aggregate = aggregate;
        }

        public string Field { get; set; }
        public string Aggregate { get; set; }
    }
}
