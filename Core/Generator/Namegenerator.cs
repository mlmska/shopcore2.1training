using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Generator
{
    public class Namegenerator
    {
        public static string GenerateUniqcode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }   

    }
}
