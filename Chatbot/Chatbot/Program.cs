using System;
using System.Text;

namespace CybersecurityAwarenessBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Cybersecurity Awareness Bot";

            ChatBot bot = new ChatBot();
            bot.Start();
        }
    }
}