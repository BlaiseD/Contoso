using LogicBuilder.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Angular.Settings.Forms
{
    public class ValidatorDescription
    {
        public ValidatorDescription()
        {
        }

        public ValidatorDescription
        (
            [Comments("Class name")]
            [NameValue(AttributeNames.DEFAULTVALUE, "Validators")]
            string className,

            [Comments("Function")]
            [NameValue(AttributeNames.DEFAULTVALUE, "required")]
            string functionName,

            [Comments("Where applicable, use a list of validator arguments as parameters to the validator function.")]
            List<ValidatorArgument> arguments = null
        )
        {
            ClassName = className;
            FunctionName = functionName;
            Arguments = arguments?.ToDictionary(kvp => kvp.Name, kvp => kvp.Value);
        }

        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, object> Arguments { get; set; }
    }
}
