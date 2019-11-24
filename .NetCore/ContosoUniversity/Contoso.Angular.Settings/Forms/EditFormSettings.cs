using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class EditFormSettings
    {
        public EditFormSettings()
        {
        }

        public EditFormSettings
        (
            [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
            [Comments("Header field on the form")]
            string title,

            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            [Comments("Update modelType first. This field is displayed next to the title - empty on Create.")]
            string displayField,

            [Comments("Includes the URL's for create, read, update and delete.")]
            RequestDetails requestDetails,

            [Comments("Input validation messages for each field.")]
            List<ValidationMessage> validationMessages,

            [Comments("List of fields and form groups for this form.")]
            List<FormItemSetting> fieldSettings,

            [Comments("Defines the filter for the single object being edited - does not apply on Create.")]
            FilterGroup filterGroup = null,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = "Contoso.Domain.Entities"
        )
        {
            Title = title;
            DisplayField = displayField;
            RequestDetails = requestDetails;
            ValidationMessages = validationMessages.ToDictionary(kvp => kvp.Field, kvp => kvp.Methods);
            FieldSettings = fieldSettings;
            FilterGroup = filterGroup;
        }

        public string Title { get; set; }
        public string DisplayField { get; set; }
        public RequestDetails RequestDetails { get; set; }
        public Dictionary<string, Dictionary<string, string>> ValidationMessages { get; set; }
        public List<FormItemSetting> FieldSettings { get; set; }
        public FilterGroup FilterGroup { get; set; }
    }
}
