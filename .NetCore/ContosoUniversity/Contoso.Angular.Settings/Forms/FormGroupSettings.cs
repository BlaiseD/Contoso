using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class FormGroupSettings : FormItemSetting
    {
        public FormGroupSettings()
        {
        }

        public FormGroupSettings
        (
            [Comments("Update modelType first. Source property name from the target object.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("HTML template for the form group.")]
            FormGroupTemplate formGroupTemplate,

            [Comments("Configuration for each field in the form group.")]
            List<FormItemSetting> fieldSettings,

            [Comments("Input validation messages for each field.")]
            List<ValidationMessage> validationMessages,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            FormGroupTemplate = formGroupTemplate;
            FieldSettings = fieldSettings;
            ValidationMessages = validationMessages.ToDictionary(kvp => kvp.Field, kvp => kvp.Methods);
        }

        public override AbstractControlEnum AbstractControlType => AbstractControlEnum.FormGroup;
        public string Field { get; set; }
        public FormGroupTemplate FormGroupTemplate { get; set; }
        public List<FormItemSetting> FieldSettings { get; set; }
        public Dictionary<string, Dictionary<string, string>> ValidationMessages { get; set; }
    }
}
