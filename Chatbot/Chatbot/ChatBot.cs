using System;

namespace CybersecurityAwarenessBot
{
    internal class ChatBot
    {
        private string _userName;
        private readonly ResponseHandler _responseHandler;

        public ChatBot()
        {
            _responseHandler = new ResponseHandler();
        }

        public void Start()
        {
            AudioPlayer.PlayGreeting();
            ConsoleUI.DisplayHeader();
            _userName = ConsoleUI.GetUserName();

            // This displays the welcome message WITHOUT any hello response
            ConsoleUI.DisplayWelcomeMessage(_userName);

            // Then go straight to chat loop - NO extra hello message
            RunChatLoop();
        }

        private void RunChatLoop()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleUI.DisplayPrompt(_userName);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleUI.DisplayError("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                input = input.Trim().ToLower();

                if (input == "exit" || input == "quit" || input == "bye")
                {
                    ConsoleUI.DisplayGoodbye(_userName);
                    isRunning = false;
                }
                else
                {
                    string response = _responseHandler.GetResponse(input);
                    ConsoleUI.DisplayBotResponse(response);
                }
            }
        }
    }
}