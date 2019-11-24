using LogicBuilder.Attributes;
using System.Collections.Generic;

namespace Contoso.Angular.Settings.Forms
{
    public class MultiSelectFormControlSettings : FormControlSettings
    {
        public MultiSelectFormControlSettings()
        {
        }

        public MultiSelectFormControlSettings
        (
            [Comments("Usually just a list of one item - the primary key. Additional fields apply when the primary key is a composite key.")]
            List<string> keyFields,

            [Comments("Update modelType first. Source property name from the target object.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("ID attribute for the DOM element - usually (field)_id - also used on the label's for attribute.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "(field)_id")]
            string domElementId,

            [Comments("Title")]
            [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
            string title,

            [Comments("Place holder text.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "(Title) reuired")]
            string placeHolder,

            [Comments("text/numeric/boolean/date")]
            [Domain("text,numeric,boolean,date")]
            string type,

            [Comments("Defines the field's default value, validation functions (and arguments for the validator where necessary).")]
            FormValidationSetting validationSetting = null,

            [Comments("HTML template applicable to input elements.")]
            TextFieldTemplate textTemplate = null,

            [Comments("HTML template applicable to drop-down elements.")]
            DropDownTemplate dropDownTemplate = null,

            [Comments("HTML template applicable to multi-select elements.")]
            MultiSelectTemplate multiSelectTemplate = null,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        ) : base
            (
                field, domElementId, title, placeHolder, type, validationSetting, textTemplate, dropDownTemplate, multiSelectTemplate, modelType
            )
        {
            KeyFields = keyFields;
        }

        public override AbstractControlEnum AbstractControlType { get => AbstractControlEnum.MultiSelectFormControl; }
        public List<string> KeyFields { get; set; }
    }
}
