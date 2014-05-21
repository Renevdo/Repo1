using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETTU_Gadgets_Web.Models.Validation
{
    public class MaxItemsAttribute : ValidationAttribute
    {
        private readonly int _maxElements;
        public MaxItemsAttribute(int minElements)
        {
            _maxElements = minElements;
        }

        public override bool IsValid(object value)
        {
            var list = value as IEnumerable<object>;
            if (list != null)
            {
                return list.Count() <= _maxElements;
            }
            return true;
        }
    }
}