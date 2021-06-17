﻿using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StoreManagement.Validations
{
    public class ExistValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }
        public string ErrorMessageNull { get; set; }
        public string ElementName { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            if (value == null)
            {
                return new ValidationResult(true, null);
            }
            if (value.ToString() == "")
            {
                return new ValidationResult(false, this.ErrorMessageNull);
            }
            switch (ElementName)
            {
                case "UserName":
                    if (isExistUserName(value.ToString()))
                    {
                        result = new ValidationResult(false, this.ErrorMessage);
                    }
                    break;
                //case "FieldName":
                //    if (FootballFieldDAL.Instance.isExistFieldName(value.ToString()))
                //    {
                //        result = new ValidationResult(false, this.ErrorMessage);
                //    }
                //    break;
                //case "GoodsName":
                //    if (GoodsDAL.Instance.IsExistGoodsName(value.ToString()))
                //    {
                //        result = new ValidationResult(false, this.ErrorMessage);
                //    }
                //    break;
                default:
                    break;
            }
            return result;
        }

        bool isExistUserName(string username)
        {
            var isExistUserName = DataProvider.Instance.DB.Accounts.Where(p => p.Username == username).Count();

            return isExistUserName > 0;
        }
    }
}
