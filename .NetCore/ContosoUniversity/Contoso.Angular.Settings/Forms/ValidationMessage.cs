using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class ValidationMessage
    {
        public ValidationMessage()
        {
        }

        public ValidationMessage
        (
            [Comments("Update modelType first. Source property name from the target object.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("Validation method and message to be used by the Reactive Forms validator.")]
            List<ValidationMethod> methods,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            Methods = methods.ToDictionary(kvp=> kvp.Method, kvp => kvp.Message);
        }

        public string Field { get; set; }
        public Dictionary<string, string> Methods { get; set; }
    }
}
