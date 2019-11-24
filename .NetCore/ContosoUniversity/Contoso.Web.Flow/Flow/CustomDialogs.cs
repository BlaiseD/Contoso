using AutoMapper;
using Contoso.Angular.Settings;
using Contoso.Angular.Settings.About;
using Contoso.Angular.Settings.Detail;
using Contoso.Angular.Settings.Forms;
using Contoso.Angular.Settings.Html;
using Contoso.Web.Flow.Cache;
using Contoso.Web.Flow.ScreenSettings.Views;
using LogicBuilder.Attributes;
using LogicBuilder.Forms.Parameters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Contoso.Web.Flow
{
    public class CustomDialogs : ICustomDialogs
    {
        public CustomDialogs(IMapper mapper, FlowDataCache flowDataCache)
        {
            this.flowDataCache = flowDataCache;
            this.mapper = mapper;
        }

        #region Fields
        private readonly FlowDataCache flowDataCache;
        private readonly IMapper mapper;
        #endregion Fields

        public void DisplayGrid(GridSettings setting, ICollection<ConnectorParameters> buttons) 
            => this.flowDataCache.ScreenSettings = new ScreenSettings<GridSettings>
            (
                setting,
                mapper.Map<IEnumerable<ConnectorParameters>, IEnumerable<CommandButton>>(buttons),
                ViewType.Grid
            );

        public void DisplayEditForm(EditFormSettings setting, ViewType viewType, ICollection<ConnectorParameters> buttons)
        {
            switch (viewType)
            {
                case ViewType.Edit:
                case ViewType.Create:
                    this.flowDataCache.ScreenSettings = new ScreenSettings<EditFormSettings>(setting, mapper.Map<IEnumerable<ConnectorParameters>, IEnumerable<CommandButton>>(buttons), viewType);
                    break;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.invalidArgumentFormat, "viewType"));
            }

        }

        public void DisplayDetailForm(DetailFormSettings setting, ViewType viewType, ICollection<ConnectorParameters> buttons)
        {
            switch (viewType)
            {
                case ViewType.Detail:
                case ViewType.Delete:
                    this.flowDataCache.ScreenSettings = new ScreenSettings<DetailFormSettings>(setting, mapper.Map<IEnumerable<ConnectorParameters>, IEnumerable<CommandButton>>(buttons), viewType);
                    break;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.invalidArgumentFormat, "viewType"));
            }
        }

        public void DisplayHtmlForm(HtmlPageSettings setting, ICollection<ConnectorParameters> buttons)
            => this.flowDataCache.ScreenSettings = new ScreenSettings<HtmlPageSettings>(setting, mapper.Map<IEnumerable<ConnectorParameters>, IEnumerable<CommandButton>>(buttons), ViewType.Html);

        public void DisplayAbout(AboutFormSettings setting, ICollection<ConnectorParameters> buttons)
            => this.flowDataCache.ScreenSettings = new ScreenSettings<AboutFormSettings>(setting, mapper.Map<IEnumerable<ConnectorParameters>, IEnumerable<CommandButton>>(buttons), ViewType.About);
    }
}
