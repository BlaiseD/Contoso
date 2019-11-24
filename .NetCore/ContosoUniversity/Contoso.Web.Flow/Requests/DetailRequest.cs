using Contoso.Angular.Settings;
using Contoso.Web.Flow.ScreenSettings.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Web.Flow.Requests
{
    public class DetailRequest : RequestBase
    {
        public FilterGroup FilterGroup { get; set; }
        public override ViewType ViewType { get; set; }
    }
}
