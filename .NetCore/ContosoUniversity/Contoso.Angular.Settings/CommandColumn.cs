using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class CommandColumn
    {
        public CommandColumn()
        {
        }

        public CommandColumn
            (
                [Comments("Column title.")]
                string title,

                [Comments("Column width")]
                int? width
            )
        {
            Title = title;
            Width = width;
        }

        public string Title { get; set; }
        public int? Width { get; set; }
    }
}
