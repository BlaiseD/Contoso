using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class Group
    {
        public Group()
        {
        }

        public Group
        (
            [Comments("Update modelType first. Property name from the target object. Use a period for nested fields i.e. foo.bar.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field, 

            [Domain("asc,desc")]
            string dir, 

            List<AggregateDefinition> aggregates,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            Dir = dir;
            Aggregates = aggregates;
        }

        public string Field { get; set; }
        public string Dir { get; set; }
        public List<AggregateDefinition> Aggregates { get; set; }
    }
}
