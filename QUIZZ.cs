using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoePart3Studentnumber10436849
{
    public partial class QUIZZ : Form
    {
        private int score = 0;
        private List<int> scores = new List<int>();
        private int questionsAdd = 0;
        private int currentQuestionIndex = 0;
        private string[] questions = {
    "What is the purpose of a VPN (Virtual Private Network)?",
    "Which of the following is a secure way to store passwords?",
    "What does a security patch do?",
    "What is social engineering in cybersecurity?",
    "What does 'brute force attack' refer to?",
    "What does 'multi-factor authentication' (MFA) enhance?",
    "What is the main risk of clicking unknown email attachments?",
    "Which is a best practice for keeping software secure?",
    "What is the main function of antivirus software?",
    "Why should you regularly back up your data?"
};

        private string[,] answers = {
    { "To create a secure connection over the internet", "To increase download speed", "To enable incognito browsing", "To remove ads from websites" },
    { "Using a password manager", "Writing them on paper", "Storing in a text file", "Memorizing all of them" },
    { "Fixes known security vulnerabilities", "Improves graphics performance", "Adds new user features", "Uninstalls unused applications" },
    { "Manipulating people to reveal confidential information", "Coding viruses", "Stealing laptops", "Cracking encryption" },
    { "Trying all possible passwords until one works", "Attacking physical servers", "Spamming someone repeatedly", "Using AI to hack software" },
    { "Your account security", "Your display resolution", "Your internet speed", "Your software update frequency" },
    { "It may contain malware", "It boosts computer speed", "It opens useful websites", "It updates drivers" },
    { "Install updates regularly", "Ignore software prompts", "Use outdated systems", "Share software openly" },
    { "To detect and remove malicious software", "To create backups", "To clean junk files", "To manage files" },
    { "To recover data after a cyberattack", "To clean old files", "To delete viruses", "To free up disk space" }
};

        public QUIZZ()
        {
            InitializeComponent();
        }



        // Method to shuffle the question 
        // Method to shuffle the answers for the current question
        public void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Length)
            {
                // Display the question
                label2.Text = questions[currentQuestionIndex];

                // Get the answers for the current question
                string[] currentAnswers = new string[4];
                currentAnswers[0] = answers[currentQuestionIndex, 0]; // Correct answer
                currentAnswers[1] = answers[currentQuestionIndex, 1];
                currentAnswers[2] = answers[currentQuestionIndex, 2];
                currentAnswers[3] = answers[currentQuestionIndex, 3];

                // Shuffle the answers
                Random rand = new Random();
                currentAnswers = currentAnswers.OrderBy(x => rand.Next()).ToArray();

                // Assign shuffled answers to radio buttons
                radioButton1.Text = currentAnswers[0];
                radioButton2.Text = currentAnswers[1];
                radioButton3.Text = currentAnswers[2];
                radioButton4.Text = currentAnswers[3];
            }
            else
            {
                // Quiz complete, show score
                MessageBox.Show($"Quiz Complete! YOUR SCORE IS {score}/10 \n greate job");
                scores.Add(score);
                button2.Enabled = false; // Disable next button after last question
            }
        }
     

        private void QUIZZ_Load(object sender, EventArgs e)
        {
            // Display the first question when the form loads
            DisplayQuestion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            if (radioButton1.Checked && radioButton1.Text == answers[currentQuestionIndex, 0])
            {
                score++;

            }
            else if (radioButton2.Checked && radioButton2.Text == answers[currentQuestionIndex, 0])
            {
                score++;


            }
            else if (radioButton3.Checked && radioButton3.Text == answers[currentQuestionIndex, 0])
            {
                score++;
              

            }
        
            else if (radioButton4.Checked && radioButton4.Text == answers[currentQuestionIndex, 0])
            {
                score++;

             
            }
            else
            {
               
               
               MessageBox.Show($"CORRECT ANSWER IS {answers[currentQuestionIndex, 0].ToString()}");
                

            }


            // Move to the next question
            currentQuestionIndex++;
            DisplayQuestion();
        }
        public string Activitylogs()
        {
            string finalScore = Convert.ToString(score);
            string finalMessage = $"You tried the quiz and got {finalScore}/10";
            MessageBox.Show($"{finalMessage}");
            return finalMessage;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 form = new Form1();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            foreach (var History in scores)
            {
                string finalMessage = $"\n" + "these are all your scores \n" +
                    $"You tried the quiz and got {History}/10";

                MessageBox.Show($"{finalMessage}");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
           
            currentQuestionIndex = 0;
            score = 0;
            button2.Enabled = true;
            button6.Enabled=false;
            DisplayQuestion();

        }
    }
}