# Cybersecurity Awareness Bot

A fully interactive, console-based cybersecurity education chatbot built in C#.
It teaches users about password safety, phishing, malware, 2FA, privacy, social engineering,
and more — through a polished, colour-coded interface with voice greeting, ASCII art,
typing animations, and personalised responses.

---

## Features

- ASCII art header with Unicode box-drawing characters
- Voice greeting via WAV audio playback (graceful fallback if file is missing)
- Personalised responses using the user's name throughout the session
- Typing animation with natural random delays for a human feel
- Colour-coded console UI (Cyan, Yellow, Green, Red)
- Keyword-based response matching with Contains logic (not exact match)
- "Did You Know?" random cybersecurity tips injected every 4 questions
- Topics covered: passwords, phishing, safe browsing, 2FA, malware, ransomware,
  VPN, public Wi-Fi, privacy, social engineering, backups, identity theft,
  software updates, IoT security, social media safety, and the dark web
- Graceful exit with personalised goodbye screen

---

## Project Structure

```
CybersecurityAwarenessBot/
├── .github/
│   └── workflows/
│       └── dotnet.yml          # GitHub Actions CI — builds on every push
├── CybersecurityAwarenessBot/
│   ├── Program.cs              # Entry point — sets encoding, launches bot
│   ├── ChatBot.cs              # Orchestrates conversation flow
│   ├── ConsoleUI.cs            # All display logic — colours, typing, borders
│   ├── ResponseHandler.cs      # Keyword-to-response dictionary and matching
│   ├── AudioPlayer.cs          # WAV greeting playback with graceful fallback
│   └── CybersecurityAwarenessBot.csproj
├── assets/
│   └── greeting.wav            # Voice greeting (see setup below)
├── .gitignore
└── README.md
```

---

## Requirements

- Windows 10 or later
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (recommended) or VS Code with C# extension

---

## Setup & Installation

### 1. Clone the repository

```bash
git clone https://github.com/YOUR-USERNAME/CybersecurityAwarenessBot.git
cd CybersecurityAwarenessBot
```

### 2. Open in Visual Studio

- Open `CybersecurityAwarenessBot.sln`
- Wait for NuGet packages to restore (none required — uses only .NET built-ins)

### 3. Add the voice greeting (optional but recommended)

1. Create or download a `greeting.wav` file  
   — Record one in [Audacity](https://www.audacityteam.org/) (free)  
   — Or generate one at [ttsmaker.com](https://ttsmaker.com) (free text-to-speech)  
   — Suggested text: *"Welcome to the Cybersecurity Awareness Bot. Stay safe online!"*

2. In Visual Studio, right-click the project → **Add → Existing Item** → select `greeting.wav`

3. Click `greeting.wav` in Solution Explorer. In the **Properties** panel:  
   Set **Copy to Output Directory** → **Copy Always**

4. The bot will now play the greeting on every startup.  
   If the file is missing, the bot continues in text-only mode — no crash.

### 4. Build and run

```bash
dotnet build
dotnet run --project CybersecurityAwarenessBot
```

Or press **F5** in Visual Studio.

---

## Usage

Once launched, the bot will:

1. Play the voice greeting (if `greeting.wav` is present)
2. Display the ASCII art header
3. Ask for your name
4. Greet you personally and list available topics
5. Begin the interactive chat session

**Example inputs:**

| You type         | Bot responds about             |
|------------------|-------------------------------|
| `password`       | Password safety best practices |
| `phishing`       | How to spot phishing emails    |
| `2fa`            | Two-factor authentication      |
| `malware`        | Malware types and prevention   |
| `vpn`            | VPN benefits and recommendations |
| `ransomware`     | Ransomware prevention          |
| `backup`         | The 3-2-1 backup rule          |
| `identity theft` | Recognising and preventing ID theft |
| `iot`            | Smart home / IoT security      |
| `dark web`       | Dark web monitoring            |
| `help`           | Full topic list                |
| `exit`           | Ends the session               |

---

## How It Works — Code Architecture

The project follows the **Single Responsibility Principle** — each class has one job:

| Class              | Responsibility                                          |
|--------------------|---------------------------------------------------------|
| `Program`          | Entry point only — sets UTF-8 encoding, starts the bot  |
| `ChatBot`          | Controls conversation flow and session state            |
| `ConsoleUI`        | All visual output — colours, borders, typing animation  |
| `ResponseHandler`  | Stores all responses and matches keywords to answers    |
| `AudioPlayer`      | Plays WAV greeting; gracefully handles missing file     |

---

## GitHub Actions

Every push to `main` or `master` automatically:
- Restores dependencies
- Builds the project in Release configuration
- Verifies the output executable exists

See `.github/workflows/dotnet.yml` for the full workflow configuration.

---

## Recommended Commit Message Format

This project uses the following commit message conventions:

```
feat: add ransomware prevention responses to ResponseHandler
fix: correct UTF-8 encoding for Unicode box characters in ConsoleUI
docs: add setup instructions and folder structure to README
ci: add GitHub Actions workflow for .NET build validation
style: improve colour consistency across bot response borders
refactor: extract TypeText delay logic into separate helper method
```

---

## License

MIT License — free to use, modify, and distribute with attribution.
