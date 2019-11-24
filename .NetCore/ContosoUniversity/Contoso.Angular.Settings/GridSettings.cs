using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;

namespace Contoso.Angular.Settings
{
    public class GridSettings
    {
        public GridSettings()
        {
        }

        public GridSettings
        (
            [Comments("Grid Title.")]
            string title,

            [Comments("True if the grid is sortable otherwise false")]
            [Domain("true,false")]
            bool sortable,

            [Comments("True if the grid is pageable otherwise false")]
            [Domain("true,false")]
            bool pageable,

            [Comments("'scrollable' if the grid is scrollable otherwise empty string.")]
            [Domain("scrollable")]
            string scrollable,

            [Comments("True if the grid is groupable otherwise false")]
            [Domain("true,false")]
            bool groupable,

            [Comments("True if the grid is filterpable otherwise false.  The filterableType field takes precedence.")]
            [Domain("true,false")]
            bool isFilterable,

            [Comments("Defines the type of filter for the grid.  Use menu, row for both filter types.  When a filter type has been set, the grid will be filterable regardless of the isFilterable property.")]
            [Domain("row,menu,\"menu, row\"")]
            string filterableType,

            [Comments("URL and other meta data for the data request.")]
            RequestDetails requestDetails,

            [Comments("Column definitions.")]
            List<ColumnSettings> columns,

            [Comments("The grid ID helps determine if a command button should be assigned to the grid's command column.")]
            int? gridId = null,

            [Comments("Filter descriptors.")]
            FilterGroup itemFilter = null,

            [Comments("Gives the grid a fixed height when set.")]
            int? height = null,

            [Comments("Details about the command (Edit, Detail, Delete) column.")]
            CommandColumn commandColumn = null,

            [Comments("Defines the state of the grid including the sort, filter, page and page size.")]
            DataRequestState state = null,

            [Comments("List of fields and correspondong aggregate functions if set.")]
            List<AggregateDefinition> aggregates = null,

            [Comments("Detail grid if set.")]
            GridSettings detailGridSettings = null
        )
        {
            Title = title;
            Sortable = sortable;
            Pageable = pageable;
            Scrollable = scrollable;
            Groupable = groupable;
            IsFilterable = isFilterable;
            FilterableType = filterableType;
            Columns = columns;
            GridId = gridId;
            ItemFilter = itemFilter;
            Height = height;
            CommandColumn = commandColumn;
            State = state;
            Aggregates = aggregates;
            RequestDetails = requestDetails;
            DetailGridSettings = detailGridSettings;
        }

        public string Title { get; set; }
        public bool Sortable { get; set; }
        public bool Pageable { get; set; }
        public string Scrollable { get; set; }
        public bool Groupable { get; set; }
        public bool IsFilterable { get; set; }
        public string FilterableType { get; set; }
        public dynamic Filterable => string.IsNullOrEmpty(FilterableType)
                                        ? (object)IsFilterable
                                        : FilterableType;
        public List<ColumnSettings> Columns { get; set; }
        public int? GridId { get; set; }
        public FilterGroup ItemFilter { get; set; }
        public int? Height { get; set; }
        public CommandColumn CommandColumn { get; set; }
        public DataRequestState State { get; set; }
        public List<AggregateDefinition> Aggregates { get; set; }
        public RequestDetails RequestDetails { get; set; }
        public GridSettings DetailGridSettings { get; set; }
    }
}
