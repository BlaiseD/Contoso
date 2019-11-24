using Contoso.Angular.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Web.Flow.ScreenSettings.Views
{
    public class ScreenSettings<TDialogSetting> : ScreenSettingsBase
    {
        public ScreenSettings(TDialogSetting settings, IEnumerable<CommandButton> commandButtons, ViewType viewType)
        {
            Settings = settings;
            CommandButtons = commandButtons;
            this.ViewType = viewType;
        }

        public override ViewType ViewType { get; }
        public TDialogSetting Settings { get; set; }
    }
}
