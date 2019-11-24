using LogicBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Angular.Settings
{
    //[Domain("text,numeric,boolean,date")]
    public class ColumnSettings
    {
        public ColumnSettings()
        {
        }

        public ColumnSettings
        (
            [Comments("Update modelType first. Source property name from the target object. Use a period for nested fields i.e. foo.bar.")]
            [ParameterEditorControl(ParameterControlType.ParameterSourcedPropertyInput)]
            [NameValue(AttributeNames.PROPERTYSOURCEPARAMETER, "modelType")]
            string field,

            [Comments("Column title.")]
            string title,

            [Comments("text/numeric/boolean/date")]
            [Domain("text,numeric,boolean,date")]
            string type,

            bool? groupable = null,
            int? width = null,
            string format = null,

            [Domain("text,numeric,boolean,date")]
            string filter = null,

            [Comments("HTML template for the cell.")]
            CellTemplate cellTemplate = null,

            [Comments("HTML template for the cell flor list content.")]
            CellListTemplate cellListTemplate = null,

            [Comments("HTML template which can be applied when the grid's filterable type is 'row' or 'menu, row'.")]
            FilterTemplate filterRowTemplate = null,

            [Comments("HTML template which can be applied when the grid's filterable type is 'menu' or 'menu, row'.")]
            FilterTemplate filterMenuTemplate = null,

            [Comments("Group header template.")]
            AggregateTemplate groupHeaderTemplate = null,

            [Comments("Group footer template.")]
            AggregateTemplate groupFooterTemplate = null,

            [Comments("Grid footer template.")]
            AggregateTemplate gridFooterTemplate = null,


            //List<Select> selects = null, 
            //bool? distinct = null,

            [ParameterEditorControl(ParameterControlType.ParameterSourceOnly)]
            [NameValue(AttributeNames.DEFAULTVALUE, "Contoso.Domain.Entities")]
            [Comments("Fully qualified class name for the model type.")]
            string modelType = null
        )
        {
            Field = field;
            Title = title;
            Type = type;
            Groupable = groupable;
            Width = width;
            Format = format;
            Filter = filter;
            CellTemplate = cellTemplate;
            CellListTemplate = cellListTemplate;
            FilterRowTemplate = filterRowTemplate;
            FilterMenuTemplate = filterMenuTemplate;
            GroupHeaderTemplate = groupHeaderTemplate;
            GroupFooterTemplate = groupFooterTemplate;
            GridFooterTemplate = gridFooterTemplate;
            //Selects = selects;
            //Distinct = distinct;
        }

        public string Field { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool? Groupable { get; set; }
        public int? Width { get; set; }
        public string Format { get; set; }
        public string Filter { get; set; }
        public CellTemplate CellTemplate { get; set; }
        public CellListTemplate CellListTemplate { get; set; }
        public FilterTemplate FilterRowTemplate { get; set; }
        public FilterTemplate FilterMenuTemplate { get; set; }
        public AggregateTemplate GroupHeaderTemplate { get; set; }
        public AggregateTemplate GroupFooterTemplate { get; set; }
        public AggregateTemplate GridFooterTemplate { get; set; }
        //public List<Select> Selects { get; set; }
        //public bool? Distinct { get; set; }
    }
}
