using Contoso.Angular.Settings.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings.Detail
{
    public abstract class DetailItem
    {
        abstract public DetailItemEnum DetailType { get; }
    }

    public class DummyConstructor
    {
        public DummyConstructor
        (
            DetailFormSettings form,
            DetailFieldSetting field,
            DetailGroupSetting group,
            DetailListSetting list,
            FormControlSettings formControlSettings,
            FormGroupArraySettings formGroupArraySettings,
            FormGroupSettings formGroupSettings,
            MultiSelectFormControlSettings multiSelectFormControlSettings,
            CommandButtonData commandButtonData,
            ValidatorArgument validatorArguments
        )
        {

        }
    }
}
