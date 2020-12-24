using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class ConversionHelper
    {
        public decimal ConvertAccentDecimalStringToDecimal(string accentDecimalString)
        {
            var pn = accentDecimalString[0];
            var decimalNumber = accentDecimalString.Substring(accentDecimalString.Length - 2);
            accentDecimalString = accentDecimalString.Remove(0, 1);
            accentDecimalString = accentDecimalString.Remove(accentDecimalString.Length - 2, 2);
            accentDecimalString = accentDecimalString.TrimStart('0');

            if (string.IsNullOrEmpty(accentDecimalString))
                return 0.00m;

            return decimal.Parse(pn + accentDecimalString + '.' + decimalNumber);
        }

        public DateTime ConvertAccentDateToDateTime(string accentDateString)
        {
            var data = accentDateString.Split(' ');
            var dateParts = data[0].Split('-');
            var hourParts = data[1].Split(':');
            int.TryParse("20" + dateParts[2], out var year);
            int.TryParse(dateParts[1], out var month);
            int.TryParse(dateParts[0], out var day);
            int.TryParse(hourParts[0], out var hour);
            int.TryParse(hourParts[1], out var minutes);
            int.TryParse(hourParts[2], out var seconds);

            return new DateTime(year, month, day, hour, minutes, seconds);
        }
    }
}
