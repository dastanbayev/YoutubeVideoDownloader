
using VideoLibrary;

namespace YouTubeDl.ConsoleApp.Commons.Concrete
{
    public class Youtube
    {
        public static async Task<Boolean> DownloadVideo(String videoLink, String path)
        {
            try
            {
                YouTube youTube = YouTube.Default;

                YouTubeVideo video = await youTube.GetVideoAsync(videoLink);

                //  The  \ / * : | ? " < > characters must be removed from the video name,
                //  because it doesn't conform to Windows file naming conventions.

                Char[] chars = { '\\', '|', '/', '*', ':', '\"', '?', '<', '>' };
                String videoTitle = video.Title;

                foreach (Char c in chars)
                    videoTitle = videoTitle.Replace(c, '_');

                // If the given directory contains the name of the video link, the video will not be downloaded!
                String[] videoNames = Directory.GetFiles(path);

                if (Array.Exists(videoNames, v => v.Contains(videoTitle)))
                    return false;

                Byte[] bytes = await video.GetBytesAsync();

                String filePath = Path.Combine(path, $"{videoTitle}{video.FileExtension}");

                FileStream stream = File.Create(filePath);

                stream.Write(bytes);

                // Clears buffers for this stream
                await stream.FlushAsync();
                stream.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
