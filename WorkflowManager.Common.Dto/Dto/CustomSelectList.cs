using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WorkflowManager.Common.Dto.Dto
{
    public class CustomSelectList : SelectList
    {
        #region custom
        ////private IList<SelectListGroup> _groups;

        ////
        //// Summary:
        ////     Gets the data group field.
        //public string DataGroupField { get; private set; }

        ////
        //// Summary:
        ////     Gets or sets the data text field.
        ////
        //// Returns:
        ////     The data text field.
        //public string DataTextField { get; private set; }

        ////
        //// Summary:
        ////     Gets or sets the data value field.
        ////
        //// Returns:
        ////     The data value field.
        //public string DataValueField { get; private set; }

        ////
        //// Summary:
        ////     Gets the disabled groups.
        //public IEnumerable DisabledGroups { get; private set; }

        ////
        //// Summary:
        ////     Gets the disabled values.
        //public IEnumerable DisabledValues { get; private set; }

        ////
        //// Summary:
        ////     Gets or sets the items in the list.
        ////
        //// Returns:
        ////     The items in the list.
        //public IEnumerable Items { get; private set; }

        ////
        //// Summary:
        ////     Gets or sets the selected values.
        ////
        //// Returns:
        ////     The selected values.
        //public IEnumerable SelectedValues { get; private set; }

        //public CustomSelectList(IEnumerable items)
        //{
        //}

        //public CustomSelectList(IEnumerable items, object selectedValue)
        //{
        //    if (items == null)
        //    {
        //        throw new ArgumentNullException("items");
        //    }

        //    Items = items;
        //}

        //public CustomSelectList(IEnumerable items, object selectedValue, IEnumerable disabledValues)
        //{
        //    if (items == null)
        //    {
        //        throw new ArgumentNullException("items");
        //    }

        //    Items = items;

        //    DisabledValues = disabledValues;
        //}

        //public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField)
        //{
        //    if (items == null)
        //    {
        //        throw new ArgumentNullException("items");
        //    }

        //    Items = items;
        //    DataValueField = dataValueField;
        //    DataTextField = dataTextField;
        //}
        #endregion

        #region selectlist base

        public CustomSelectList(IEnumerable items) : base(items)
        {
        }

        public CustomSelectList(IEnumerable items, object selectedValue) : base(items, selectedValue)
        {
        }

        public CustomSelectList(IEnumerable items, object selectedValue, IEnumerable disabledValues) : base(items, selectedValue, disabledValues)
        {
        }

        public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField) : base(items, dataValueField, dataTextField)
        {
        }

        public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue) : base(items, dataValueField, dataTextField, selectedValue)
        {
        }

        public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField, string dataGroupField, object selectedValue) : base(items, dataValueField, dataTextField, dataGroupField, selectedValue)
        {
        }

        public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue, IEnumerable disabledValues) : base(items, dataValueField, dataTextField, selectedValue, disabledValues)
        {
        }

        public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField, string dataGroupField, object selectedValue, IEnumerable disabledValues) : base(items, dataValueField, dataTextField, dataGroupField, selectedValue, disabledValues)
        {
        }

        public CustomSelectList(IEnumerable items, string dataValueField, string dataTextField, string dataGroupField, object selectedValue, IEnumerable disabledValues, IEnumerable disabledGroups) : base(items, dataValueField, dataTextField, dataGroupField, selectedValue, disabledValues, disabledGroups)
        {
        }

        #endregion
    }
}
