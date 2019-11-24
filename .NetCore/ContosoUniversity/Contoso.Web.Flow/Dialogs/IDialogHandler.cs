using Contoso.Web.Flow.Cache;
using Contoso.Web.Flow.Requests;
using LogicBuilder.RulesDirector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Web.Flow.Dialogs
{
    public interface IDialogHandler
    {
        void Complete(IFlowManager flowManager, RequestBase request);
    }
}
