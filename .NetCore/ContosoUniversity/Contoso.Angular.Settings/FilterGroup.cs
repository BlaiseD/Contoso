using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public abstract class SomeBaseType
    {

    }
    public class FilterGroup// : SomeBaseType
    {
        public FilterGroup()
        {
        }

        public FilterGroup
        (
            [Domain("and,or")]
            string logic, 
            List<FilterDefinition> filters = null, 
            List<FilterGroup> filterGroups = null
        )
        {
            Logic = logic;
            Filters = filters;
            FilterGroups = filterGroups;
        }

        public string Logic { get; set; }
        public List<FilterDefinition> Filters { get; set; }
        public List<FilterGroup> FilterGroups { get; set; }
    }
}
