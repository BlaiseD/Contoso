using LogicBuilder.Attributes;

namespace Contoso.Angular.Settings.Forms
{
    public class FormGroupTemplate
    {
        public FormGroupTemplate()
        {
        }

        public FormGroupTemplate
        (
            [Comments("HTML template for the form group.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "formGroupTemplate")]
            string templateName
        )
        {
            TemplateName = templateName;
        }

        public string TemplateName { get; set; }
    }
}
