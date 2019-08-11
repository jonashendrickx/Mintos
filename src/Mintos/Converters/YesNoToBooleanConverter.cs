namespace Mintos.Converters
{
    public static class YesNoToBooleanConverter
    {
        public static bool Convert(string value)
        {
            return value.ToLower() == "yes";
        }
    }
}
