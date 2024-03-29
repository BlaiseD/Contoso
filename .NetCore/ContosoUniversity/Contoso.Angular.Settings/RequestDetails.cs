﻿using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class RequestDetails
    {
        public RequestDetails()
        {
        }

        public RequestDetails
            (
                [ParameterEditorControl(ParameterControlType.TypeAutoComplete)]
                [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
                [Comments("Fully qualified class name for the model type.")]
                string modelType,

                [ParameterEditorControl(ParameterControlType.TypeAutoComplete)]
                [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Data.Entities")]
                [Comments("Fully qualified class name for the data type.")]
                string dataType,

                string dataSourceUrl = "/api/Generic/GetData",
                string getUrl = "/api/Generic/GetSingle",
                string addUrl = "/api/Generic/Add",
                string updateUrl = "/api/Generic/Update",
                string deleteUrl = "/api/Generic/Delete",

                [ListEditorControl(ListControlType.HashSetForm)]
                [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
                [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
                string[] includes = null,

                [ListEditorControl(ListControlType.HashSetForm)]
                List<Select> selects = null, 
                bool? distinct = null
            )
        {
            ModelType = modelType;
            DataType = dataType;
            DataSourceUrl = dataSourceUrl;
            GetUrl = getUrl;
            AddUrl = addUrl;
            UpdateUrl = updateUrl;
            DeleteUrl = deleteUrl;
            Includes = includes;
            Selects = selects?.ToDictionary(s => s.FieldName, s => s.SourceMember);
            Distinct = distinct;
        }

        public string ModelType { get; set; }
        public string DataType { get; set; }
        public string DataSourceUrl { get; set; }
        public string GetUrl { get; set; }
        public string AddUrl { get; set; }
        public string UpdateUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string[] Includes { get; set; }
        public Dictionary<string, string> Selects { get; set; }
        public bool? Distinct { get; set; }
    }
}
