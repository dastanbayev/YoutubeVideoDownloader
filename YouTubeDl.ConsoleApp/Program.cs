
using YouTubeDl.ConsoleApp.Commons.Extensions;
using YouTubeDl.ConsoleApp.Commons.Concrete;

#pragma warning disable

Console.Write("Link: ");
String videoLink = Console.ReadLine().Trim();
Console.Write("Path: ");
String path = Console.ReadLine().Trim();

if (videoLink.IsCorrectYouTubeLink())
{
    Console.WriteLine("\nIn progress...");

    Console.WriteLine(await Youtube.DownloadVideo(videoLink, @$"{path}") ? "\nSuccesfully downloaded!!!\n" 
                                : "\nThis video already downloaded!\n");
}

else
    Console.WriteLine("Incorrect link!!!");
