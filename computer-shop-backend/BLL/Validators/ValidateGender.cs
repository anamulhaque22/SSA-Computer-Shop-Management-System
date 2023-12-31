using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace computerShop.Validators
{
    [AttributeUsage(AttributeTargets.Property |
   AttributeTargets.Field, AllowMultiple = false)]
    sealed public class ValidateGender : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            if ((value != null) && ((value.ToString() == "male") || (value.ToString() == "female")))
            {
                result = true;
            }
            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}