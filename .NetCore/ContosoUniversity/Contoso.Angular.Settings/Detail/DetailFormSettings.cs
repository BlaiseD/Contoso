using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public class DetailFormSettings
    {
        public DetailFormSettings()
        {
        }

        public DetailFormSettings
        (
            [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
            [Comments("Header field on the form")]
            string title,

            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            [Comments("Update modelType first. This field is displayed next to the title.")]
            string displayField,

            [Comments("Includes the URL to retrieve the data.")]
            RequestDetails requestDetails,

            [Comments("List of fields and form groups for display.")]
            List<DetailItem> fieldSettings,

            [Comments("Defines the filter for the single object being displayed.")]
            FilterGroup filterGroup = null,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = "Contoso.Domain.Entities"
        )
        {
            Title = title;
            DisplayField = displayField;
            RequestDetails = requestDetails;
            FieldSettings = fieldSettings;
            FilterGroup = filterGroup;
        }

        public string Title { get; set; }
        public string DisplayField { get; set; }
        public RequestDetails RequestDetails { get; set; }
        public List<DetailItem> FieldSettings { get; set; }
        public FilterGroup FilterGroup { get; set; }
    }
}
