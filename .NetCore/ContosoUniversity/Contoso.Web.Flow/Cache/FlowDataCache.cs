using Contoso.Angular.Settings;
using Contoso.Domain;
using Contoso.Utils;
using Contoso.Web.Flow.ScreenSettings;
using Contoso.Web.Flow.ScreenSettings.Navigation;
using Contoso.Web.Flow.Requests;
using Contoso.Web.Flow.ScreenSettings.Views;
using LogicBuilder.RulesDirector;
using System.Collections.Generic;

namespace Contoso.Web.Flow.Cache
{
    public class FlowDataCache
    {
        #region Properties
        public RequestedFlowStage RequestedFlowStage { get; set; } = new RequestedFlowStage();
        public NavigationBar NavigationBar { get; set; } = new NavigationBar();
        public ScreenSettingsBase ScreenSettings { get; set; }
        public SafeUpdateDictionary<string, BaseModelClass> BusinessModels { get; set; } = new SafeUpdateDictionary<string, BaseModelClass>();
        public SafeUpdateDictionary<string, object> FlowItems{ get; set; } = new SafeUpdateDictionary<string, object>();
        public Variables Variables { get; set; } = new Variables();
        #endregion Properties
    }
}
