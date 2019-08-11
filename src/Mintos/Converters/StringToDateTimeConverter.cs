using System;
using System.Globalization;

namespace Mintos.Converters
{
    public static class StringToDateTimeConverter
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        public static DateTime? Convert(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
