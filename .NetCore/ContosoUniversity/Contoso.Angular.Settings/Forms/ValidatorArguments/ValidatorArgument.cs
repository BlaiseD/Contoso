﻿using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    public class ValidatorArgument
    {
        public ValidatorArgument() { }

        public ValidatorArgument
        (
            [Comments("The argument's name.")]
            [NameValue(AttributeNames.USEFOREQUALITY, "true")]
            [NameValue(AttributeNames.USEFORHASHCODE, "true")]
            string name,

            [Comments("The argument's value.")]
            [NameValue(AttributeNames.USEFOREQUALITY, "false")]
            [NameValue(AttributeNames.USEFORHASHCODE, "false")]
            object value
        )
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
