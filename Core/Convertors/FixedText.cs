using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Convertors
{
    public class FixedText
    {
        public static string Fixemail(string email)
        {
            return email.Trim().ToLower();
        }


    }
}
