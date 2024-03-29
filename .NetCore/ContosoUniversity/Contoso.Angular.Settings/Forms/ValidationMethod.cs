﻿using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class ValidationMethod
    {
        public ValidationMethod()
        {
        }

        public ValidationMethod
        (
            [Comments("Method")]
            [NameValue(AttributeNames.DEFAULTVALUE, "required")]
            string method,

            [Comments("Validation message.")]
            [NameValue(AttributeNames.DEFAULTVALUE, "(Title) is required.")]
            string message
        )
        {
            Method = method;
            Message = message;
        }

        public string Method { get; set; }
        public string Message { get; set; }
    }
}
