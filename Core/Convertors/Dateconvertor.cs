using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Convertors
{
    public static class Dateconvertor
    {
        public static string toshamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                pc.GetDayOfMonth(value).ToString("00");
        }


    }
}
