using Contoso.Repositories;
using Contoso.Web.Flow.Cache;
using Contoso.Web.Flow.ScreenSettings;
using Contoso.Web.Flow.Requests;
using LogicBuilder.Forms.Parameters;
using LogicBuilder.RulesDirector;
using System.Collections.Generic;

namespace Contoso.Web.Flow
{
    public interface IFlowManager
    {
        FlowSettings Start(string module, int stage);
        FlowSettings Next(RequestBase response);
        FlowSettings NavStart(NavBarRequest navBarRequest);
        void FlowComplete();
        void Terminate();
        void Wait();

        void DisplayQuestions(QuestionFormParameters form, ICollection<ConnectorParameters> connectors = null);
        void DisplayInputQuestions(InputFormParameters form, ICollection<ConnectorParameters> connectors = null);

        //Dictionary<int, int> QuestionListAnswers { get; }
        //Dictionary<int, object> InputQuestionsAnswers { get; }
        Variables Variables { get; }
        Progress Progress { get; }
        ICustomActions CustomActions { get; }
        ICustomDialogs CustomDialogs { get; }
        void SetCurrentBusinessBackupData();

        FlowDataCache FlowDataCache { get; set; }
        DirectorBase Director { get; }
        IFlowActivity FlowActivity { get; }
        ISchoolRepository SchoolRepository { get; }
    }
}