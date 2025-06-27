using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoePart3Studentnumber10436849
{
    public partial class chatbot : Form
    {
        List<string> chatHistory = new List<string>();
        public chatbot()
        {
            InitializeComponent();
        }



        private void chatbot_Load(object sender, EventArgs e)
        {
            string user = PromptName();
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Please enter your name");
                return;
            }

            AppendChatMessage("Chatbot", $"{user}, welcome to THEEARICAN CYBERSECURITY!", Color.Red);
            ShowMenu();
        }

        private void ShowMenu()
        {
            string message =
                "PLEASE SEARCH BY NAME AS SEEN IN THE MENU\n\n" +
                "════════════════════════════════════════════════════════════\n" +
                "                       SECURITY MENU                        \n" +
                "════════════════════════════════════════════════════════════\n" +
                "  [1] PHISHING\n" +
                "  [2] Protect sensitive information (random phishing tips)\n" +
                "  [3] MALWARE\n" +
                "  [4] Protect from malicious software (random malware tips)\n" +
                "  [5] TROJAN HORSE\n" +
                "  [6] Avoid suspicious downloads (random trojan horse tips)\n" +
                "  [7] STRONG PASSWORDS\n" +
                "  [8] Valid signin (random strong password tips)\n" +
                "  [9] RANSOMWARE\n" +
                "  [10] Tips on dangerous threats (random ransomware tips)\n" +
                "  [11] EXIT - PRESS THE X ON TOP RIGHT CORNER\n" +
                "  [12] Sentiment detection (used: worried, furious, curious, happy, sad)\n" +
                "════════════════════════════════════════════════════════════\n";

            AppendChatMessage("Chatbot", message, Color.Red);
        }

        private void AppendChatMessage(string speaker, string message, Color color)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionColor = color;
            richTextBox1.AppendText($"\n{speaker}: ");
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.AppendText($"{message}\n\n");
            richTextBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a valid input.");
                return;
            }

            AppendChatMessage("User", name, Color.Green);

            DisplayConversationFlawstring(name);
            Search(name);

            chatHistory.Add(name);
        }

        public bool Search(string name)
        {
            string search = textBox1.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter a search term.");
                return false;
            }

            bool found = false;

            Dictionary<string, string> list = new Dictionary<string, string>
        {
            { "phishing", @"
A cyberattack where scammers trick people into revealing sensitive information (passwords, banking details, etc.)
by pretending to be a trusted entity (e.g., a bank, company, or government). if you want more about phishing type more about phishing 
"},
  {"sensitive information", @"
Ways to Prevent Phishing:

    - Verify Emails & Links – Check sender details and hover over links before clicking.
    - Use Strong, Unique Passwords – Avoid using the same password across different sites.
    - Enable Multi-Factor Authentication (MFA) – Adds an extra layer of security.
    - Avoid Downloading Unknown Attachments – Could contain malware.
    - Stay Updated – Keep software and antivirus programs up to date.
    - Be Skeptical of Urgent Requests – Scammers use urgency to trick victims.
    - Educate Yourself & Others – Awareness is key to avoiding phishing scams.
" },
            { "malware", @"
(Malicious software) is a program designed to harm, exploit, or disrupt devices, networks, or data.
It includes viruses, worms, ransomware, spyware, and trojans.if you want more about malware type more about malware
" },
 { "protect from malicious software" ,@"
Ways to Prevent Malware:

    - Install Antivirus & Keep It Updated – Detects and removes threats.
    - Avoid Suspicious Links & Attachments – Malware often spreads through emails or fake websites.
    - Use Strong & Unique Passwords – Prevents unauthorized access.
    - Enable Automatic Updates – Keeps software secure from vulnerabilities.
    - Download Only from Trusted Sources – Avoid third-party or pirated software.
    - Use a Firewall – Blocks unauthorized network access.
    - Back Up Data Regularly – Protects against data loss from ransomware.
" },
            { "trojan horse", @"
A Trojan Horse virus is a type of malware that disguises itself as a legitimate file or program to trick users
into downloading and running it. Once activated, it can steal data, damage files, or allow hackers to control
your system." },

 {"Avoid Suspicious download", @"
Ways to Prevent Trojan Horse Viruses:

    - Avoid Suspicious Downloads – Only download software from trusted sources.
    - Use Antivirus Software – Keep it updated and run regular scans.
    - Enable Firewall – It helps block unauthorized access.
    - Be Cautious with Email Attachments – Avoid opening unknown or unexpected attachments.
    - Keep Software Updated – Ensure your OS and apps have the latest security patches.
    - Disable Auto-Run for External Devices – Prevents malware from running automatically.
    - Use Strong Passwords – Helps protect your accounts from unauthorized access.
" },
            { "strong passwords", @"
A secure and hard-to-crack password that protects accounts from hacking attempts.
"},

 {"Valid signin",@"
Ways to Create a Strong Password:

    - Use 12–16+ Characters – Longer passwords are harder to crack.
    - Mix Uppercase, Lowercase, Numbers & Symbols – (e.g., T@ke5eCur!ty)
    - Avoid Common Words & Personal Info – No “password123” or birthdates.
    - Use a Passphrase – A random mix of words (e.g., ""Giraffe#Cloud9&Moon!"").
    - Make It Unique for Each Account – Don’t reuse passwords.
    - Use a Password Manager – Stores and generates strong passwords.
    - Enable Multi-Factor Authentication (MFA) – Adds extra security.
" },
                    { "ransomware", @"
Malware that encrypts files and demands payment for decryption.
" },
  {"Tips on dangerous threats", @"
**Prevention Tips:**
✔ Maintain offline/cloud backups of critical data.  
✔ Avoid clicking suspicious links in emails.  
✔ Patch systems regularly to fix vulnerabilities.  
✔ Restrict user permissions (least privilege principle).  
✔ Use endpoint detection tools (e.g., CrowdStrike).  
" },


};

            foreach (var item in list)
            {
                if (search.Contains(item.Key.ToLower()))
                {
                    found = true;
                    AppendChatMessage("Chatbot", $"You asked about: {item.Key.ToUpper()}\n{item.Value}", Color.Red);
                    break;
                }
            }

            if (!found)
            {
                AppendChatMessage("Chatbot", "SEARCH INVALID - Please choose from the menu.", Color.Red);
            }

            TrackingEmotion(search);
            return found;
        }

        public void DisplayConversationFlawstring(string name)
        {
            Random random = new Random();
            string[] responses = {
                $"Hey {name}, you can always ask more questions about phishing, malware, strong passwords, and more.",
                $"{name}, thank you for your question! Are you learning something new?",
                $"{name}, the more you ask, the more you learn!",
                $"Think before you share, {name}, but feel free to ask anything else!",
                $"{name}, I hope this is informative for you!"
            };

            int index = random.Next(responses.Length);
            AppendChatMessage("Chatbot", responses[index], Color.Red);
        }

        public void TrackingEmotion(string search)
        {
            Dictionary<string, string> emotionResponses = new Dictionary<string, string>
            {
                {"curious", "It's wonderful that you're curious!" },
                {"furious", "It's understandable to feel angry sometimes." },
                {"worried", "Don't worry, I'm here to help you understand cybersecurity better." },
                {"happy", "That's great to hear!" },
                {"sad", "I'm sorry you're feeling sad. Hope this helps cheer you up!" }
            };

            foreach (var emotion in emotionResponses)
            {
                if (search.Contains(emotion.Key.ToLower()))
                {
                    AppendChatMessage("Chatbot", emotion.Value, Color.Red);
                }
            }
        }

        public string Activitylogs()
        {
            StringBuilder activityLog = new StringBuilder();
            foreach (var history in chatHistory)
            {
                activityLog.AppendLine(history);
            }
            MessageBox.Show(activityLog.ToString());
            return activityLog.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder activityLog = new StringBuilder();
            foreach (var history in chatHistory)
            {
                activityLog.AppendLine(history);
            }
            MessageBox.Show(activityLog.ToString());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }

        private string PromptName()
        {
            Form inputForm = new Form
            {
                Width = 300,
                Height = 150,
                Text = "Enter Your Name",
                StartPosition = FormStartPosition.CenterParent
            };

            Label label = new Label() { Left = 10, Top = 20, Text = "What's your name?", AutoSize = true };
            TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 260 };
            Button okButton = new Button() { Text = "OK", Left = 200, Width = 70, Top = 80, DialogResult = DialogResult.OK };

            inputForm.Controls.Add(label);
            inputForm.Controls.Add(inputBox);
            inputForm.Controls.Add(okButton);
            inputForm.AcceptButton = okButton;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                return inputBox.Text.Trim();
            }

            return string.Empty;
        }
    }
}
