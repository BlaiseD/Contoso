using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class FormControlSettings : FormItemSetting
    {
        public FormControlSettings()
        {
        }

        public FormControlSettings
        (
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
        )
        {
            Field = field;
            DomElementId = domElementId;
            Title = title;
            PlaceHolder = placeHolder;
            Type = type;
            ValidationSetting = validationSetting;
            TextTemplate = textTemplate;
            DropDownTemplate = dropDownTemplate;
            MultiSelectTemplate = multiSelectTemplate;
        }

        public override AbstractControlEnum AbstractControlType { get => AbstractControlEnum.FormControl; }
        public string Field { get; set; }
        public string DomElementId { get; set; }
        public string Title { get; set; }
        public string PlaceHolder { get; set; }
        public string Type { get; set; }
        public FormValidationSetting ValidationSetting { get; set; }
        public TextFieldTemplate TextTemplate { get; set; }
        public DropDownTemplate DropDownTemplate { get; set; }
        public MultiSelectTemplate MultiSelectTemplate { get; set; }
    }
}
