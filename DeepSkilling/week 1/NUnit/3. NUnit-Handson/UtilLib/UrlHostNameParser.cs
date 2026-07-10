namespace UtilLib
{
    public class UrlHostNameParser
    {
        public string ParseHostName(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            if (!url.StartsWith("http://") &&
                !url.StartsWith("https://"))
                return string.Empty;

            System.Uri uri = new System.Uri(url);

            return uri.Host;
        }
    }
}