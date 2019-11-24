using Contoso.Angular.Settings;
using Contoso.Utils;
using Contoso.Web.Flow.ScreenSettings.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contoso.Web.Flow.ScreenSettings.Views
{
    [JsonConverter(typeof(DialogSettingsConverter))]
    abstract public class ScreenSettingsBase
    {
        abstract public ViewType ViewType { get; }
        public IEnumerable<CommandButton> CommandButtons { get; set; }
    }
}
