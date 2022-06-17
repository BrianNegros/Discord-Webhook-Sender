using System.Net;
using System;
using System.IO;
using System.Threading;

namespace discord_webhook_sender
{
    class Program
    {
        public static string webhook;
        public static string username;
        public static string description;
        public static string title;
        static void Main()
        {
            Console.Title = "Webhook Sender By RssMario#9999";
            Console.Write("Whats your webhook: ");
            webhook = Console.ReadLine();
            Console.Write("What username: ");
            username = Console.ReadLine();
            Console.Write("What description: ");
            description = Console.ReadLine();
            Console.Write("What title: ");
            title = Console.ReadLine();
            send_webhook(webhook);
        }
        public static void send_webhook(string url)
        {
            var dc = WebRequest.Create(url);
            dc.ContentType = "application/json";
            dc.Method = "POST";
            string postdata = "{\"username\": \"" + username + "\",\"embeds\":[    {\"description\":\"" + description + "\", \"title\":\"" + title + "\", \"color\":1018364}]  }";
            using (var sw = new StreamWriter(dc.GetRequestStream()))
            sw.Write(postdata);
            dc.GetResponse();
            Console.WriteLine("Done webhook sended");
            Thread.Sleep(2000);
            Console.Clear();
            Main();
            Console.ReadKey();
        }
    }
}
