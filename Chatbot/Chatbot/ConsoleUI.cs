using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    
    /// Handles all console user interface elements including:
    /// - ASCII art header display
    /// - Coloured text formatting
    /// - Typing effects
    /// - User input prompts
    /// - Error and goodbye messages
    internal static class ConsoleUI
    {
        private const int BORDER_WIDTH = 68;
        private static readonly string ThickBorder = new string('═', BORDER_WIDTH);
        private static readonly string ThinBorder = new string('─', BORDER_WIDTH);

        // Random delay generator for more natural typing effect
        private static readonly Random _random = new Random();

        /// <summary>
        /// Displays the cybersecurity awareness chatbot ASCII art logo.
        /// </summary>
        public static void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine();
            Console.WriteLine($"  ╔{ThickBorder}╗");
            Console.WriteLine($"  ║{Pad("", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("   ██████╗██╗   ██╗██████╗ ███████╗██████╗  ██████╗ ████████╗", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("  ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔═══██╗╚══██╔══╝", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("  ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝██║   ██║   ██║   ", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("  ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██║   ██║   ██║   ", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("  ╚██████╗   ██║   ██████╔╝███████╗██████╔╝╚██████╔╝   ██║   ", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("   ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═════╝  ╚═════╝    ╚═╝   ", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Pad("", BORDER_WIDTH)}║");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ║{Center("CYBERSECURITY AWARENESS BOT", BORDER_WIDTH)}║");
            Console.WriteLine($"  ║{Center("Keeping You Safe in the Digital World", BORDER_WIDTH)}║");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ║{Center("*** THINK BEFORE YOU CLICK ***", BORDER_WIDTH)}║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  ║{Pad("", BORDER_WIDTH)}║");
            Console.WriteLine($"  ╚{ThickBorder}╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Prompts user for their name with validation.
        /// </summary>
        /// <returns>Validated user name (non-empty, trimmed)</returns>
        public static string GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("  BOT >> Hello! Welcome to the Cybersecurity Awareness Bot.");
            TypeText("  BOT >> I'm here to help you stay safe online.");
            Console.WriteLine();
            TypeText("  BOT >> Before we begin, may I know your name?");
            Console.ResetColor();
            Console.WriteLine();

            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  YOU >> ");
                Console.ResetColor();
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  WARNING BOT >> Please enter a valid name to continue.");
                    Console.ResetColor();
                }
            }

            return name;
        }

        /// <summary>
        /// Displays personalised welcome message with available topics.
        /// </summary>
        /// <param name="name">User's name</param>
        public static void DisplayWelcomeMessage(string name)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {ThinBorder}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText($"  BOT >> Wonderful to meet you, {name}!");
            TypeText("  BOT >> Here's what you can ask me about:");
            Console.ForegroundColor = ConsoleColor.White;
            TypeText("         Password Safety");
            TypeText("         Phishing & Scam Awareness");
            TypeText("         Safe Browsing Habits");
            TypeText("         Malware & Viruses");
            TypeText("         Two-Factor Authentication (2FA)");
            TypeText("         Data Privacy");
            TypeText("         Social Engineering");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("  BOT >> Type 'help' for a full topic list, or 'exit' to quit.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {ThinBorder}");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the user input prompt.
        /// </summary>
        /// <param name="name">User's name</param>
        public static void DisplayPrompt(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"  {name} >> ");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the bot's response with typing effect.
        /// </summary>
        /// <param name="response">Response text to display</param>
        public static void DisplayBotResponse(string response)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {ThinBorder}");
            Console.ForegroundColor = ConsoleColor.Yellow;

            string[] lines = response.Split('\n');
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    TypeText("  BOT >> " + line.Trim());
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {ThinBorder}");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays an error or warning message.
        /// </summary>
        /// <param name="message">Error message to display</param>
        public static void DisplayError(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  WARNING BOT >> {message}");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the goodbye screen when user exits.
        /// </summary>
        /// <param name="name">User's name</param>
        public static void DisplayGoodbye(string name)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  ╔{ThickBorder}╗");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText($"  BOT >> Goodbye, {name}! Stay vigilant and safe online.");
            TypeText("  BOT >> Remember: Think before you click!");
            TypeText("  BOT >> ~ Cybersecurity Awareness Bot ~");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  ╚{ThickBorder}╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// Displays text with a natural typing animation effect.
        /// <param name="text">Text to type out</param>
        /// <param name="baseDelayMs">Base delay between characters in milliseconds</param>
        private static void TypeText(string text, int baseDelayMs = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                // Add slight random variation for more natural feel
                int variation = _random.Next(-5, 8);
                int delay = Math.Max(5, baseDelayMs + variation);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        /// Pads a string to a specified width.
        
        private static string Pad(string text, int width)
        {
            if (text.Length >= width) return text.Substring(0, width);
            return text.PadRight(width);
        }

        /// Centers a string within a specified width.        
        private static string Center(string text, int width)
        {
            if (text.Length >= width) return text.Substring(0, width);
            int totalPadding = width - text.Length;
            int leftPad = totalPadding / 2;
            return text.PadLeft(text.Length + leftPad).PadRight(width);

        }
    }
}