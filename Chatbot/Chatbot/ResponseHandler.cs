using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    internal class ResponseHandler
    {
        private readonly Dictionary<string, string> _responses;

        public ResponseHandler()
        {
            _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            InitialiseResponses();
        }

        private void InitialiseResponses()
        {
            // ── General Conversation ──────────────────
            _responses["how are you"] = "I'm running at full capacity and ready to help keep you safe online!";

            _responses["what's your purpose"] = "My purpose is to educate you on cybersecurity best practices.\n" +
                "I cover topics like password safety, phishing, safe browsing, and more.";

            _responses["what can i ask"] = "You can ask me about:\n" +
                "* Password Safety\n* Phishing and Scams\n* Safe Browsing\n" +
                "* Two-Factor Authentication (2FA)\n* Malware and Viruses\n* Data Privacy\n* Social Engineering";

            _responses["who are you"] = "I'm the Cybersecurity Awareness Bot - your digital safety guide!";

            _responses["hello"] = "Hello! Great to chat with you. How can I help you stay safe online today?";

            _responses["help"] = "TOPICS I CAN HELP WITH:\n" +
                "--------------------------------------------------\n" +
                "* Type 'password'      - Password safety tips\n" +
                "* Type 'phishing'      - Identify phishing attacks\n" +
                "* Type 'safe browsing' - Browse securely\n" +
                "* Type 'malware'       - Understand malware\n" +
                "* Type '2fa'           - Two-factor authentication\n" +
                "* Type 'privacy'       - Protect your personal data\n" +
                "* Type 'social'        - Social engineering tactics\n" +
                "* Type 'exit'          - Exit the chatbot";

            // ── Password Safety ─────
            _responses["password safety"] = "STRONG PASSWORD TIPS\n" +
                "--------------------------------------------------\n" +
                "* Use at least 12 characters (longer is better)\n" +
                "* Mix UPPERCASE, lowercase, numbers, and symbols (!@#$)\n" +
                "* Avoid personal info: birthdays, pet names\n" +
                "* Never reuse the same password across multiple sites\n" +
                "* Use a password manager (Bitwarden, 1Password)\n" +
                "* Enable Two-Factor Authentication wherever possible";

            _responses["password"] = "Good password habits are essential!\n" +
                "* At least 12 characters long\n" +
                "* Use a passphrase: e.g., 'BlueSky#Rain42!'\n" +
                "* Never share your password with anyone\n" +
                "* Change passwords immediately if you suspect a breach";

            _responses["password manager"] = "Password managers like Bitwarden, LastPass, or 1Password\n" +
                "securely store and generate strong passwords.\n" +
                "You only need to remember one master password.\n" +
                "This is one of the best security steps you can take!";

            // ── Phishing ──
            _responses["phishing"] = "PHISHING AWARENESS\n" +
                "--------------------------------------------------\n" +
                "Phishing is when attackers impersonate trusted entities to steal your info.\n\n" +
                "WARNING SIGNS:\n" +
                "* Urgent or threatening language ('Your account will be closed!')\n" +
                "* Suspicious sender email addresses\n" +
                "* Unexpected links or attachments\n" +
                "* Requests for passwords or financial info\n" +
                "* Poor spelling and grammar\n\n" +
                "WHAT TO DO:\n" +
                "* Do NOT click any links\n" +
                "* Do NOT open attachments\n" +
                "* Check the sender's actual email address carefully\n" +
                "* Report it to your IT department or email provider\n" +
                "* Delete the email immediately";

            // Add SAME response for "phishing email" and "scam"
            _responses["phishing email"] = _responses["phishing"];
            _responses["scam"] = _responses["phishing"];
            _responses["email scam"] = _responses["phishing"];

            // ── Safe Browsing ──────────────
            _responses["safe browsing"] = "SAFE BROWSING HABITS\n" +
                "--------------------------------------------------\n" +
                "* Check for HTTPS (padlock icon) in the address bar\n" +
                "* Avoid public Wi-Fi for sensitive transactions\n" +
                "* Keep your browser and OS fully updated\n" +
                "* Install a reputable antivirus/anti-malware tool\n" +
                "* Only download software from official sources\n" +
                "* Use an ad blocker to reduce malicious ads";

            // Allow short forms: 'safe' and 'browsing'
            _responses["safe"] = _responses["safe browsing"];
            _responses["browsing"] = _responses["safe browsing"];

            _responses["https"] = "HTTPS means the website encrypts your data in transit.\n" +
                "Always look for the padlock icon before entering:\n" +
                "* Passwords\n* Banking details\n* Personal information\n" +
                "If a site uses only HTTP - leave immediately!";

            _responses["public wifi"] = "PUBLIC WI-FI SECURITY\n" +
                "--------------------------------------------------\n" +
                "Public Wi-Fi is a major security risk!\n" +
                "* Hackers can intercept unencrypted data on open networks\n" +
                "* Avoid logging into banking, email, or work accounts\n" +
                "* Use a VPN if you must connect to public Wi-Fi\n" +
                "* Disable auto-connect to open/public networks";

            _responses["vpn"] = "A VPN (Virtual Private Network) encrypts your internet traffic.\n" +
                "Benefits:\n* Hides your IP address and location\n" +
                "* Secures data on public Wi-Fi\n* Bypasses geographic restrictions\n" +
                "Recommended options: ProtonVPN, Mullvad, NordVPN";

            // ── Two-Factor Authentication ─────────────
            _responses["two-factor"] = "TWO-FACTOR AUTHENTICATION (2FA)\n" +
                "--------------------------------------------------\n" +
                "2FA adds a second security layer.\n" +
                "Even if someone steals your password, they still need:\n" +
                "* A one-time code from your phone\n" +
                "* A fingerprint or face scan\n" +
                "* A physical security key\n\n" +
                "Enable 2FA on ALL important accounts - especially email and banking!";

            _responses["2fa"] = "2FA (Two-Factor Authentication) is one of the best ways to secure accounts.\n" +
                "Use an authenticator app like:\n" +
                "* Google Authenticator\n* Microsoft Authenticator\n* Authy\n" +
                "These are more secure than receiving codes via SMS.";

            // ── Malware ───────────────────────────────
            _responses["malware"] = "MALWARE PROTECTION\n" +
                "--------------------------------------------------\n" +
                "Malware is malicious software designed to harm your device or steal data.\n" +
                "Types include: viruses, ransomware, spyware, trojans, and adware.\n\n" +
                "PROTECT YOURSELF:\n" +
                "* Install reputable antivirus software (Windows Defender, Malwarebytes)\n" +
                "* Keep your OS and apps fully updated\n" +
                "* Do not download software from unknown sources\n" +
                "* Avoid pirated/cracked software - it often contains malware";

            _responses["virus"] = "Computer viruses spread through infected files, email attachments,\n" +
                "and malicious downloads.\n" +
                "* Always scan downloaded files with antivirus software\n" +
                "* Never open email attachments from unknown senders\n" +
                "* Keep all software and OS patches up to date";

            _responses["ransomware"] = "RANSOMWARE PREVENTION\n" +
                "--------------------------------------------------\n" +
                "Ransomware encrypts your files and demands payment to restore them.\n\n" +
                "PREVENTION TIPS:\n" +
                "* Back up data regularly (follow the 3-2-1 rule)\n" +
                "* Do not open suspicious email attachments\n" +
                "* Keep software and OS fully updated\n" +
                "* Never pay the ransom - it does not guarantee recovery\n\n" +
                "3-2-1 Rule: 3 copies, 2 different media types, 1 off-site backup";

            // ── Data Privacy ──────────────────────────
            _responses["privacy"] = "DIGITAL PRIVACY TIPS\n" +
                "--------------------------------------------------\n" +
                "* Review app permissions and revoke unnecessary ones\n" +
                "* Use privacy-focused browsers: Firefox, Brave\n" +
                "* Limit personal info shared on social media\n" +
                "* Read privacy policies before registering on new sites\n" +
                "* Use end-to-end encrypted messaging: Signal, WhatsApp";

            _responses["data"] = "Your personal data is extremely valuable.\n" +
                "* Be selective about what personal info you share online\n" +
                "* Regularly audit which apps have access to your data\n" +
                "* Use disposable/alias emails for sign-ups when possible\n" +
                "* Monitor for data breaches at: haveibeenpwned.com";

            // ── Social Engineering ────────────────────
            _responses["social engineering"] = "SOCIAL ENGINEERING AWARENESS\n" +
                "--------------------------------------------------\n" +
                "Social engineering manipulates people psychologically rather than hacking systems.\n\n" +
                "COMMON TACTICS:\n" +
                "* Pretexting (creating a false but believable scenario)\n" +
                "* Baiting (offering something enticing, like a free USB)\n" +
                "* Phishing / Spear-phishing (targeted email attacks)\n" +
                "* Vishing (voice/phone call scams)\n" +
                "* Tailgating (following someone into a restricted area)\n\n" +
                "Always verify identities before sharing sensitive information!";

            _responses["social"] = _responses["social engineering"];
        }

        // Keyword matching
        public string GetResponse(string input)
        {
            string lowerInput = input.ToLower().Trim();

            // Check each keyword for a match
            foreach (KeyValuePair<string, string> entry in _responses)
            {
                if (lowerInput.Contains(entry.Key.ToLower()))
                {
                    return entry.Value;
                }
            }

            // Default fallback
            return "I didn't quite understand that. Could you rephrase?\n" +
                   "Try asking about: passwords, phishing, safe browsing,\n" +
                   "malware, 2fa, privacy, or type 'help' for all topics.";
        }
    }
}