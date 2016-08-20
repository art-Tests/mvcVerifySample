using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSample.Filter
{
    public sealed class BanwordAttribute : ValidationAttribute ,IClientValidatable
    {
        private string Input;

        public BanwordAttribute(string inVal)
        {
            Input = inVal;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                //ValidationType 的值一定要是小寫！
                ValidationType = "banword",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            //ValidationParameters 一定要是小寫！
            rule.ValidationParameters["input"] = Input;
            yield return rule;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if(value is string)
            {
                var words = Input.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Any(a => value.ToString().Contains(a)))
                    return false;
            }
            return true;
        }
    }
}