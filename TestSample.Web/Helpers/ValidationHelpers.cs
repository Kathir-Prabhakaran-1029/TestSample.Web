using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TestSample.Core.Settings;
using TestSample.Domain.Entities;
using TestSample.Persistance.Interface;
using TestSample.Web.Helpers;

namespace TestSample.Web.Helpers
{
    public static class ValidationHelper
    {

        static readonly Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public static bool IsGUIDNullOrEmpty(Guid? GUID)
        {
            return GUID == null || GUID == Guid.Empty;
        }
        public static bool IsValidToSave(this Insurer I, ModelStateDictionary MSD)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(I.Name))
            {
                MSD.AddModelError(nameof(I.Name), "Please enter name");
                isValid = false;
            }

            if (string.IsNullOrEmpty(I.Desc))
            {
                MSD.AddModelError(nameof(I.Desc), "Please enter desc");
                isValid = false;
            }

            if (string.IsNullOrEmpty(I.InternalCode))
            {
                MSD.AddModelError(nameof(I.InternalCode), "Please enter internal code");
                isValid = false;
            }

            return isValid;
        }
    }
}