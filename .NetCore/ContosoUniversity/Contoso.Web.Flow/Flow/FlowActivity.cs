﻿using Contoso.Angular.Settings;
//using Contoso.Angular.Settings.Forms;
//using Forms;
using LogicBuilder.Forms.Parameters;
using LogicBuilder.RulesDirector;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Contoso.Web.Flow
{
    public class FlowActivity : IFlowActivity
    {
        public FlowActivity(IFlowManager flowManager)
        {
            this._flowManager = flowManager;
        }

        #region Variables
        private IFlowManager _flowManager;
        #endregion Variables

        #region Properties
        public DirectorBase Director => this._flowManager.Director;
        #endregion Properties

        #region Methods
        public string FormatString(string format, Collection<object> list) 
            => string.Format(CultureInfo.CurrentCulture, format, list.ToArray());

        public void FlowComplete() => this._flowManager.FlowComplete();

        public void Terminate() => this._flowManager.Terminate();

        public void Wait() => this._flowManager.Wait();

        public void DisplayQuestions(QuestionFormParameters form, ICollection<ConnectorParameters> connectors = null) 
            => this._flowManager.DisplayQuestions(form, connectors);

        public void DisplayInputQuestions(InputFormParameters form, ICollection<ConnectorParameters> connectors = null)
            => this._flowManager.DisplayInputQuestions(form, connectors);
        #endregion Methods
    }
}
