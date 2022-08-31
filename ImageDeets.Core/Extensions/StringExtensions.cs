namespace ImageDeets.Core.Extensions
{
    public static class StringExtentions
    {
        /// <summary>
        /// Fixes nulls by returning them as empty strings.
        /// </summary>
        /// <param name="stringValue">The string to fix;</param>
        /// <returns>If null returns blank, otherwise returns string.</returns>
        public static string EmptyIfNull(this string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return string.Empty;
            }
            else
            {
                return stringValue;
            }
        }
    }
}
