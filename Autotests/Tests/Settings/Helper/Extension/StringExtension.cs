namespace Tests.Settings.Helper
{
    public static class StringExtension
    {
        public static string AsDxHtmlInput(this string name)
        {
            return $"{name}_I";
        }
    }
}
