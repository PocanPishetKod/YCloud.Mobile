using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Models
{
    public class SignInModel : ModelBase
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public SignInModel()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public bool IsValid()
        {
            return Email.Length > 0 && Password.Length > 0;
        }
    }
}
