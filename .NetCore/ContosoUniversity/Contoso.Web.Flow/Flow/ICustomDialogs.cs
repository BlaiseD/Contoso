using Contoso.Angular.Settings;
using Contoso.Angular.Settings.About;
using Contoso.Angular.Settings.Detail;
using Contoso.Angular.Settings.Forms;
using Contoso.Angular.Settings.Html;
using Contoso.Web.Flow.ScreenSettings.Views;
using LogicBuilder.Attributes;
using LogicBuilder.Forms.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Web.Flow
{
    public interface ICustomDialogs
    {
        [AlsoKnownAs("DisplayGrid")]
        [FunctionGroup(FunctionGroup.DialogForm)]
        void DisplayGrid
        (
            GridSettings setting,

            [ListEditorControl(ListControlType.Connectors)]
            ICollection<ConnectorParameters> buttons
        );

        [AlsoKnownAs("DisplayEditForm")]
        [FunctionGroup(FunctionGroup.DialogForm)]
        void DisplayEditForm
        (
            [Comments("Configuration details for the form.")]
            EditFormSettings setting,

            [Comments("Create or Edit")]
            ViewType viewType,

            [ListEditorControl(ListControlType.Connectors)]
            ICollection<ConnectorParameters> buttons
        );

        [AlsoKnownAs("DisplayDetail")]
        [FunctionGroup(FunctionGroup.DialogForm)]
        void DisplayDetailForm
        (
            [Comments("Configuration details for the form.")]
            DetailFormSettings setting,

            [Comments("Detail or Delete")]
            ViewType viewType,

            [ListEditorControl(ListControlType.Connectors)]
            ICollection<ConnectorParameters> buttons
        );

        [AlsoKnownAs("DisplayHtmlContent")]
        [FunctionGroup(FunctionGroup.DialogForm)]
        void DisplayHtmlForm
        (
            [Comments("Configuration details for the form.")]
            HtmlPageSettings setting,

            [ListEditorControl(ListControlType.Connectors)]
            ICollection<ConnectorParameters> buttons
        );

        [AlsoKnownAs("DisplayAbout")]
        [FunctionGroup(FunctionGroup.DialogForm)]
        void DisplayAbout
        (
            [Comments("Configuration details for the form.")]
            AboutFormSettings setting,

            [ListEditorControl(ListControlType.Connectors)]
            ICollection<ConnectorParameters> buttons
        );
    }
}
