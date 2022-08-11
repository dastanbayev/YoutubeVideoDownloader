

namespace YouTubeDl.ConsoleApp.Commons.Extensions
{
    public static class StringExtensions
    {
        internal static bool IsCorrectYouTubeLink(this String link)
        {
            try
            {
                Uri uri = new Uri(link);

                return uri.Host == "www.youtube.com" || uri.Host == "youtube.com" ||
                        uri.Host == "www.youtu.be" || uri.Host == "youtu.be";

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
 }
