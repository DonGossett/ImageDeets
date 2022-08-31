namespace ImageDeets.Core.Extensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Writes out Yes or No instead of True or False.
        /// </summary>
        /// <param name="yes">The value to humanize.</param>
        /// <returns>"Yes" if true, "No" if false.</returns>
        public static string ToYesNo(this bool yes)
        {
            string ValueAsString = "No";

            if (yes)
            {
                ValueAsString = "Yes";
            }

            return ValueAsString;
        }
    }
}
