using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TestSample.Core.Settings;

namespace TestSample.Web.Helpers
{
    public static class ViewHelper
    {
        public static string ApplicationPath
        {
            get { return Convert.ToString(HttpContext.Current.ApplicationInstance.Application["ApplicationPath"]); }
        }

        public static int PageSize
        {
            get { return AppSettings.PageListLength; }
        }

        public static string GetColorClass(decimal value)
        {
            string colorClass = null;
            if (value > 0)
            {
                colorClass = "positive";
            }
            else if (value < 0)
            {
                colorClass = "negative";
            }
            else
            {
                colorClass = "zero";
            }
            return colorClass;
        }

        public static string DateTimeFormat
        {
            get { return "{0:dd/MM/yyyy}"; }
        }

        public static string TimeFormat
        {
            get { return "{0:hh\\:mm}"; }
        }

        public static int GetSNoStart(int PageNo, int PageListLen)
        {
            return (1 + ((PageNo * PageListLen) - PageListLen));
        }

        public static int GetSNoEnd(int PageNo, int PageListLen, int PageCount)
        {
            return ((PageNo * PageListLen) - PageListLen) + PageCount;
        }

        public static string ShowNonEmptyValue(this string value)
        {
            return string.IsNullOrEmpty(value) ? "NA" : value;
        }

        public static string ShowNonEmptyValue(this int value)
        {
            return value == 0 ? "" : value.ToString("0");
        }

        public static string ShowNonEmptyValue(this int? value)
        {
            return value == 0 || value == null ? "" : Convert.ToInt32(value).ToString("0");
        }

        public static string ShowNonEmptyValue(this DateTime value, string AdditionalFormatString = null)
        {
            return value != DateTime.MinValue ? value.ToString("dd/MM/yyyy" + AdditionalFormatString, CultureInfo.InvariantCulture) : "";
        }

        public static string ShowNonEmptyValue(this TimeSpan value)
        {
            return value != TimeSpan.MinValue ? value.ToString(@"hh\:mm") : "";
        }

        public static string ShowNonEmptyValue(this TimeSpan? value)
        {
            return value != null && value != TimeSpan.MinValue ? (TimeSpan.TryParse(value.ToString(), out TimeSpan timeSpan) ? timeSpan.ToString(@"hh\:mm") : "") : "";
        }

        public static string ShowNonEmptyValue(this DateTime? value, string AdditionalFormatString = null)
        {
            return value != null && value != DateTime.MinValue ? Convert.ToDateTime(value).ToString("dd/MM/yyyy" + AdditionalFormatString, CultureInfo.InvariantCulture) : "";
        }

        public static string ShowOnlyIfDecimalExists(this decimal value)
        {
            return value != 0 ? value.ToString("0.##") : "0";
        }


        public static string ShowNonEmptyValue(this decimal value)
        {
            return value != 0 ? value.ToString("0.00") : null;
        }

        public static string ShowNonEmptyValue(this decimal? value)
        {
            return value != 0 && value != null ? Convert.ToDecimal(value).ToString("0.00") : "NA";
        }

        public static string ShowNonKMEmptyValue(this decimal value)
        {
            return value != 0 ? value.ToString("0.00") + " KM" : "";
        }

        public static string ShowNonKMEmptyValue(this decimal? value)
        {
            return value != 0 && value != null ? Convert.ToDecimal(value).ToString("0.00") + " KM" : "0 KM";
        }

        public static string ShowFormatThousandSeperator(this decimal value, bool isNullable = false)
        {
            string format = (isNullable ? "" : "$ ") + "{0:n}";
            return value != 0 ? String.Format(format, value) : (isNullable ? null : "$ 0.00"); //value.ToString("0.00");
        }

        public static string ShowFormatThousandSeperator(this decimal? value)
        {
            return value != 0 ? String.Format("{0:n}", value) : "0.00"; //value.ToString("0.00");
        }

        public static string ShowEmptyValue(this decimal value)
        {
            return value != 0 ? value.ToString("0.00") : "NA";
        }

        public static string ShowEmptyValue(this decimal? value)
        {
            return value != 0 && value != null ? Convert.ToDecimal(value).ToString("0.00") : "NA";
        }

        public static string RoleName
        {
            get
            {
                return null;// WebSessionHelper.Role;
            }
        }

        public static string RenderViewToString<T>(ControllerBase controller, string viewName, T model)
        {
            using (var writer = new System.IO.StringWriter())
            {
                ViewEngineResult result = ViewEngines
                          .Engines
                          .FindView(controller.ControllerContext,
                                    viewName, null);

                var viewPath = ((RazorView)result.View);
                var view = new RazorView(controller.ControllerContext, viewPath.ViewPath, null, false, null);
                var vdd = new ViewDataDictionary<T>(model);
                var viewCxt = new ViewContext(
                                    controller.ControllerContext,
                                    view,
                                    vdd,
                                    new TempDataDictionary(), writer);
                viewCxt.View.Render(viewCxt, writer);
                return writer.ToString();
            }
        }
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()?
                            .GetMember(enumValue.ToString())?
                            .First()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name;
        }

    }
}