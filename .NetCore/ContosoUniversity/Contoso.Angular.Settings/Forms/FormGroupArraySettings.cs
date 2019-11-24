using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class FormGroupArraySettings : FormItemSetting
    {
        public FormGroupArraySettings()
        {
        }

        public FormGroupArraySettings
        (
            [Comments("Update modelType first. Source property name from the target object.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("Configuration for each field in one of the array's form groups.")]
            List<FormItemSetting> fieldSettings,

            [Comments("Input validation messages for each field.")]
            List<ValidationMessage> validationMessages,

            [Comments("Usually just a list of one item - the primary key. Additional fields apply when the primary key is a composite key.")]
            List<string> keyFields,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            FieldSettings = fieldSettings;
            ValidationMessages = validationMessages.ToDictionary(kvp => kvp.Field, kvp => kvp.Methods);
            KeyFields = keyFields;
        }

        public override AbstractControlEnum AbstractControlType => AbstractControlEnum.FormGroupArray;
        public string Field { get; set; }
        public List<FormItemSetting> FieldSettings { get; set; }
        public Dictionary<string, Dictionary<string, string>> ValidationMessages { get; set; }
        public List<string> KeyFields { get; set; }
    }
}
