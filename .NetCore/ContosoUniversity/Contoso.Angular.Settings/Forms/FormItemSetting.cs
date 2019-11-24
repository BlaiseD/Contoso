using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Forms
{
    //FormGroup, FormControl, 
    public abstract class FormItemSetting
    {
        abstract public AbstractControlEnum AbstractControlType { get; }
    }
}
