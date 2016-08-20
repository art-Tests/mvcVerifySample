using LoginSample.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginSample.Models.ViewModel
{
    [MetadataType(typeof(LoginMetadata))]
    public partial class Login
    {
        private class LoginMetadata 
        {
            [Display(Name ="帳號")]
            [RegularExpression(@"\w+[@]\w+.\w+",ErrorMessage ="{0}必須為EMAIL格式。")]
            [Banword("skilltree,demo,twMVC",ErrorMessage ="{0}不可以包含skilltree、demo、twMVC字樣")]
            public string username { get; set; }


            [Display(Name ="密碼")]
            [UIHint("password")]
            [StringLength(20,MinimumLength =4,ErrorMessage ="{0}長度須為{2}-{1}之間。")]
            public string password { get; set; }

        }
    }
}