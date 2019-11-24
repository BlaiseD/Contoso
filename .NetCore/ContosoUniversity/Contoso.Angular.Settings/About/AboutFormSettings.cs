using Contoso.Angular.Settings.Detail;
using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.About
{
    public class AboutFormSettings
    {
        public AboutFormSettings()
        {
        }

        public AboutFormSettings
        (
            [NameValue(AttributeNames.DEFAULTVALUE, "Title")]
            [Comments("Header field on the form")]
            string title,

            [Comments("Includes the URL to retrieve the data.")]
            RequestDetails requestDetails,

            [Comments("Defines the state of the request including the sort, filter, page and page size.")]
            DataRequestState state,

            [Comments("List of fields and form groups for display.")]
            List<DetailItem> fieldSettings
        )
        {
            Title = title;
            RequestDetails = requestDetails;
            State = state;
            FieldSettings = fieldSettings;
        }

        public string Title { get; set; }
        public RequestDetails RequestDetails { get; set; }
        public DataRequestState State { get; set; }
        public List<DetailItem> FieldSettings { get; set; }
    }
}
