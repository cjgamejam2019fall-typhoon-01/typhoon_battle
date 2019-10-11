public static class StringExtensions
{
    public static string RemoveFirst(this string self, string value)
    {
        return self.Remove(self.IndexOf(value), value.Length);
    }

    public static string RemoveLast(this string self, string value)
    {
        return self.Remove(self.LastIndexOf(value), value.Length);
    }
}
