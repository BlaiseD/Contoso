using Contoso.Angular.Settings;
using Contoso.Web.Flow.Cache;
using Contoso.Web.Flow.Requests;
using LogicBuilder.RulesDirector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Web.Flow.Dialogs
{
    public class DetailDialogHandler : BaseDialogHandler
    {
        public override void Complete(IFlowManager flowManager, RequestBase request)
        {
            if (!request.CommandButtonRequest.Cancel)
            {
                //VariablesHelper<FilterGroup>.SetVariable(typeof(FilterGroup).FullName, ((DetailRequest)request).FilterGroup, flowManager.Director);
                flowManager.FlowDataCache.FlowItems[typeof(FilterGroup).FullName] = ((DetailRequest)request).FilterGroup;
            }

            base.Complete(flowManager, request);
        }
    }
}
