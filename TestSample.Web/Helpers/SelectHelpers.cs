using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSample.Domain.Enums;

namespace TestSample.Web.Helpers
{
    public class SelectHelper
    {
        public List<SelectListItem> GetStatus(Status? S)
        {
            var selectListItems = new List<SelectListItem>();

            foreach (Status status in Enum.GetValues(typeof(Status)))
            {
                string statusStr = status.ToString().Replace("_", " ");
                selectListItems.Add(new SelectListItem
                {
                    Value = statusStr,
                    Text = statusStr,
                    Selected = (S == status)
                });
            }

            return selectListItems;
        }

    }
}