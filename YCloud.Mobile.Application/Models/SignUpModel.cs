using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Models
{
    public class SignUpModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public SignUpModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }

        public bool IsValid()
        {
            return Email.Length > 0 && Password.Length > 0 && ConfirmPassword.Equals(Password, StringComparison.Ordinal);
        }
    }
}
