using LogicBuilder.Attributes;

namespace Contoso.Angular.Settings
{
    public class CellListTemplate
    {
        public CellListTemplate()
        {
        }

        public CellListTemplate
        (
            [Comments("HTML template name for the cell.")]
            string templateName,

            [Comments("Update modelType first. Source property name from the target object. Use a period for nested fields i.e. foo.bar.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string displayMember,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = "Contoso.Domain.Entities"
        )
        {
            TemplateName = templateName;
            DisplayMember = displayMember;
        }

        public string TemplateName { get; set; }
        public string DisplayMember { get; set; }
    }
}
