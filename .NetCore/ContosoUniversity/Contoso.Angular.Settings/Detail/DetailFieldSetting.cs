using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public class DetailFieldSetting : DetailItem
    {
        public DetailFieldSetting
        (
            [Comments("Update modelType first. Source property name from the target object.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("Title")]
            [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
            string title,

            [Comments("text/numeric/boolean/date")]
            [Domain("text,numeric,boolean,date")]
            string type,

            [Comments("HTML template for the field.")]
            DetailFieldTemplate fieldTemplate,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            Title = title;
            Type = type;
            FieldTemplate = fieldTemplate;
        }

        public override DetailItemEnum DetailType => DetailItemEnum.Field;
        public string Field { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DetailFieldTemplate FieldTemplate { get; set; }
    }
}
