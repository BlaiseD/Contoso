using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    public class DataRequestState
    {
        public DataRequestState
        (
            [Comments("Number of records to skip.")]
            int? skip = null,

            [Comments("Page size.")]
            int? take = null,

            [Comments("Sort descriptor.")]
            List<Sort> sort = null,

            [Comments("Group by.")]
            List<Group> group = null,

            [Comments("Filter descriptors.")]
            FilterGroup filterGroup = null,

            [Comments("Aggregate functions.")]
            List<AggregateDefinition> aggregates = null
        )
        {
            Skip = skip;
            Take = take;
            Sort = sort;
            Group = group;
            FilterGroup = filterGroup;
            Aggregates = aggregates;
        }

        public int? Skip { get; set; }
        public int? Take { get; set; }
        public List<Sort> Sort { get; set; }
        public List<Group> Group { get; set; }
        public FilterGroup FilterGroup { get; set; }
        public List<AggregateDefinition> Aggregates { get; set; }
    }
}
