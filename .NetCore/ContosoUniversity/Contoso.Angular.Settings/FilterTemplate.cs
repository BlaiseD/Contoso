﻿using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class FilterTemplate
    {
        public FilterTemplate
            (
                string templateName,

                bool isPrimitive,

                [Comments("Update modelType first. Property name for the text field. Use a period for nested fields i.e. foo.bar.")]
                [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
                [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
                string textField,

                [Comments("Update modelType first. Property name for the value field. Use a period for nested fields i.e. foo.bar.")]
                [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
                [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
                string valueField,

                DataRequestState state,

                RequestDetails requestDetails,

                [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
                [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
                [Comments("Fully qualified class name for the model type.")]
                string modelType = null
            )
        {
            TemplateName = templateName;
            IsPrimitive = isPrimitive;
            TextField = textField;
            ValueField = valueField;
            State = state;
            RequestDetails = requestDetails;
        }

        public string TemplateName { get; set; }
        public bool IsPrimitive { get; set; }
        public string TextField { get; set; }
        public string ValueField { get; set; }
        public DataRequestState State { get; set; }
        public RequestDetails RequestDetails { get; set; }
    }
}
