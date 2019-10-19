namespace MainOffice
{
    public static class StringExtension
    {
        public static bool Contains(this string str, params string[] values)
        {
            foreach (var value in values)
            {
                if (str.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}