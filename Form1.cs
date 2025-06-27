using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoePart3Studentnumber10436849
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QUIZZ qUIZZ = new QUIZZ();
            qUIZZ.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            try
            {
              
                if (File.Exists("sound.wav"))
                {
                    SoundPlayer player = new SoundPlayer("sound.wav");
                    player.Play();
                }
                else
                {
                    MessageBox.Show("Sound file not found: " + "sound.wav");
                }

                chatbot chatbots = new chatbot();
                chatbots.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create instances of QUIZZ and chatbot
            chatbot chatbots = new chatbot();
            QUIZZ qUIZZ = new QUIZZ();

            // Make sure the chatbot has some chat history (ensure this is updated from the UI)
            // If chatHistory is updated from previous interactions, we can call Activitylogs now
            string chatLogs = chatbots.Activitylogs();  // This will fetch the updated chat history

            // Ensure QUIZZ score is updated and activity logs are printed
            string quizLogs = qUIZZ.Activitylogs();  // This fetches the updated quiz score

            // Display both logs in the message box
            MessageBox.Show($"Chatbot Activity Logs:\n{chatLogs}\n\nQUIZZ Activity Logs:\n{quizLogs}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.Show();
        }
    }
}
