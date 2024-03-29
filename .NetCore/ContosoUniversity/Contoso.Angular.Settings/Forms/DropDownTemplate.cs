﻿using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class DropDownTemplate
    {
        public DropDownTemplate()
        {
        }

        public DropDownTemplate
        (
            [Comments("HTML template for the drop-down.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "dropDownTemplate")]
            string templateName,

            [Comments("Place holder text.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "Select One ...")]
            string placeHolderText,

            [Comments("Update modelType first. Property name for the text field. Use a period for nested fields i.e. foo.bar.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string textField,

            [Comments("Update modelType first. Property name for the value field. Use a period for nested fields i.e. foo.bar.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string valueField,

            [Comments("Details about the drop-down data source including joins and partial field set (selects).")]
            RequestDetails requestDetails,

            [Comments("The request state defines sorting, filtering, grouping and aggregates if necessary.")]
            DataRequestState state = null, 

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = "Contoso.Domain.Entities"
        )
        {
            TemplateName = templateName;
            PlaceHolderText = placeHolderText;
            TextField = textField;
            ValueField = valueField;
            State = state;
            RequestDetails = requestDetails;
        }

        public string TemplateName { get; set; }
        public string PlaceHolderText { get; set; }
        public string TextField { get; set; }
        public string ValueField { get; set; }
        public DataRequestState State { get; set; }
        public RequestDetails RequestDetails { get; set; }
    }
}
