﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class CommandButton
    {
        public int Id { get; set; }
        public string ShortString { get; set; }
        public string LongString { get; set; }
        public bool Cancel { get; set; }
        public int? GridId { get; set; }
        public bool? GridCommandButton { get; set; }
        public string ButtonIcon { get; set; }
        public string ClassString { get; set; }
    }
}
