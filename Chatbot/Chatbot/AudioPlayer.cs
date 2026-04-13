using System;
using System.IO;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    /// Handles audio playback for the chatbot's voice greeting.
    /// Gracefully falls back if audio file is missing or corrupted
    internal static class AudioPlayer
    {
        private const string AUDIO_FILENAME = "greeting.wav";

        /// Plays the greeting.wav file from the application directory.
        /// File must be set to 'Copy to Output Directory = Copy Always' in Visual Studio.
        
        public static void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    AUDIO_FILENAME
                );

                if (File.Exists(audioPath))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n  [AUDIO] Playing voice greeting...");
                    Console.ResetColor();

                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync(); // Synchronous playback - waits for completion
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("  [OK] Voice greeting complete.");
                    Console.ResetColor();
                    Thread.Sleep(500);
                }
                else
                {
                    // Graceful fallback with clear instructions
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n  [INFO] Voice greeting not found.");
                    Console.WriteLine($"  [INFO] To enable voice: Add '{AUDIO_FILENAME}' to the project output folder");
                    Console.WriteLine("  [INFO] Set file properties: Copy to Output Directory = Copy Always");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n  [WARNING] Audio unavailable: {ex.Message}");
                Console.WriteLine("  [INFO] Continuing with text-only mode.");
                Console.ResetColor();
                Thread.Sleep(1000);
            }
        }
    }
}