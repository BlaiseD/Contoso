using System;
using System.Collections.Generic;
using System.Text;
using Contoso.Angular.Settings;
using Contoso.Web.Flow.Cache;
using Contoso.Web.Flow.Requests;
using LogicBuilder.RulesDirector;

namespace Contoso.Web.Flow.Dialogs
{
    public class GridDialogHandler : BaseDialogHandler
    {
        public override void Complete(IFlowManager flowManager, RequestBase request)
        {
            if (!request.CommandButtonRequest.Cancel)
            {
                //VariablesHelper<FilterGroup>.SetVariable(typeof(FilterGroup).FullName, ((GridRequest)request).FilterGroup, flowManager.Director);
                flowManager.FlowDataCache.FlowItems[typeof(FilterGroup).FullName] = ((GridRequest)request).FilterGroup;
            }

            base.Complete(flowManager, request);
        }
    }
}
