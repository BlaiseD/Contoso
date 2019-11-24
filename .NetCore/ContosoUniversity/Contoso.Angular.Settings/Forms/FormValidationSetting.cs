using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class FormValidationSetting
    {
        public FormValidationSetting()
        {
        }

        public FormValidationSetting
        (
            [Comments("Default value for the form control.")]
            object defaultValue = null,

            [Comments("Confifuration for validation classes, functions (and arguments for the validator where necessary).")]
            List<ValidatorDescription> validators = null
        )
        {
            DefaultValue = defaultValue;
            Validators = validators ?? new List<ValidatorDescription>();
        }

        public object DefaultValue { get; set; }
        public List<ValidatorDescription> Validators { get; set; }
    }
}
