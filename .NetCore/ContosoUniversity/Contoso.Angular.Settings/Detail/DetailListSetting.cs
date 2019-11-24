using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public class DetailListSetting : DetailItem
    {
        public DetailListSetting()
        {
        }

        public DetailListSetting
        (
            [Comments("Update modelType first. Source property name from the target object.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("Title")]
            [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
            string title,

            [Comments("HTML template for the list.")]
            DetailListTemplate listTemplate,

            [Comments("List of fields and form groups in the list.")]
            List<DetailItem> fieldSettings,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            Title = title;
            ListTemplate = listTemplate;
            FieldSettings = fieldSettings;
        }

        public override DetailItemEnum DetailType => DetailItemEnum.List;
        public string Field { get; set; }
        public string Title { get; set; }
        public DetailListTemplate ListTemplate { get; set; }
        public List<DetailItem> FieldSettings { get; set; }
    }
}
