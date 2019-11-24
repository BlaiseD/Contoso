using AutoMapper;
using Contoso.Repositories;
using Contoso.Web.Flow.Cache;
using Contoso.Web.Flow.Dialogs;
using Contoso.Web.Flow.ScreenSettings;
using Contoso.Web.Flow.Requests;
using Contoso.Web.Flow.ScreenSettings.Views;
using LogicBuilder.Forms.Parameters;
using LogicBuilder.RulesDirector;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Contoso.Web.Flow
{
    public class FlowManager : IFlowManager
    {
        public FlowManager(IMapper mapper,
            ICustomDialogs customDialogs,
            ICustomActions customActions,
            DirectorFactory directorFactory,
            FlowActivityFactory flowActivityFactory,
            ISchoolRepository SchoolRepository,
            ILogger<FlowManager> logger,
            FlowDataCache flowDataCache)
        {
            this.CustomDialogs = customDialogs;
            this.CustomActions = customActions;
            this._logger = logger;
            this.SchoolRepository = SchoolRepository;
            this.Mapper = mapper;
            this.Director = directorFactory.Create(this);
            this.FlowActivity = flowActivityFactory.Create(this);
            this.FlowDataCache = flowDataCache;
        }

        #region Constants
        #endregion Constants

        #region Fields
        private ILogger<FlowManager> _logger;
        #endregion Fields

        #region Properties
        public Variables Variables => this.FlowDataCache.Variables;
        public Progress Progress { get; } = new Progress();
        public FlowDataCache FlowDataCache { get; set; }

        public ICustomActions CustomActions { get; private set; }

        public ICustomDialogs CustomDialogs { get; private set; }
        public DirectorBase Director { get; }
        public IFlowActivity FlowActivity { get; }

        public ISchoolRepository SchoolRepository { get; }
        public IMapper Mapper { get; }
        #endregion Properties

        public void DisplayInputQuestions(InputFormParameters form, ICollection<ConnectorParameters> connectors = null)
        {
            throw new NotImplementedException();
        }

        public void DisplayQuestions(QuestionFormParameters form, ICollection<ConnectorParameters> connectors = null)
        {
            throw new NotImplementedException();
        }

        public void FlowComplete()
        {
            _logger.LogWarning(0, string.Format("FlowComplete {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Progress)));
            FlowDataCache.ScreenSettings = new ScreenSettings<object>(null, null, ViewType.FlowComplete);
        }

        public void SetCurrentBusinessBackupData()
        {
        }

        public void Terminate()
        {
        }

        public void Wait()
        {
        }

        public FlowSettings Start(string module, int stage)
        {
            try
            {
                FlowDataCache.RequestedFlowStage = new RequestedFlowStage { InitialModule = module, TargetModule = stage };
                this.Director.StartInitialFlow(module);
                return new FlowSettings
                {
                    ScreenSettings = FlowDataCache.ScreenSettings,
                    NavigationBar = FlowDataCache.NavigationBar,
                    FlowState = ((Director)this.Director).FlowState
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning(0, string.Format("Progress Start {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Progress)));
                this._logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public FlowSettings Next(RequestBase request)
        {
            try
            {
                BaseDialogHandler handler = BaseDialogHandler.Create(request);
                handler.Complete(this, request);
                this.Director.ExecuteRulesEngine();

                return new FlowSettings
                {
                    ScreenSettings = FlowDataCache.ScreenSettings,
                    NavigationBar = FlowDataCache.NavigationBar,
                    FlowState = ((Director)this.Director).FlowState
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning(0, string.Format("Progress Next {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Progress)));
                this._logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public FlowSettings NavStart(NavBarRequest navBarRequest)
        {
            try
            {
                FlowDataCache.RequestedFlowStage = new RequestedFlowStage
                {
                    InitialModule = navBarRequest.InitialModuleName,
                    TargetModule = navBarRequest.TargetModule
                };

                this.Director.StartInitialFlow(FlowDataCache.RequestedFlowStage.InitialModule);

                return new FlowSettings
                {
                    ScreenSettings = FlowDataCache.ScreenSettings,
                    NavigationBar = FlowDataCache.NavigationBar,
                    FlowState = ((Director)this.Director).FlowState
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning(0, string.Format("Progress NavStart {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Progress)));
                this._logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
