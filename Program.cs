﻿using System.Net;
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
        public static string color;
        static void Main()
        {
            Console.Title = "Webhook Sender By Brian";
            Console.Write("Whats your webhook: ");
            webhook = Console.ReadLine();
            Console.Write("What username: ");
            username = Console.ReadLine();
            Console.Write("What description: ");
            description = Console.ReadLine();
            Console.Write("What title: ");
            title = Console.ReadLine();
            //Color must be hex numbers with the #!
            Console.Write("What Color: ");
            color = Console.ReadLine();
            send_webhook(webhook);
        }
        public static void send_webhook(string url)
        {
            var dc = WebRequest.Create(url);
            dc.ContentType = "application/json";
            dc.Method = "POST";
            string postdata = "{\"username\": \"" + username + "\",\"embeds\":[    {\"description\":\"" + description + "\", \"title\":\"" + title + "\", \"color\":" + color + "}]  }";
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
