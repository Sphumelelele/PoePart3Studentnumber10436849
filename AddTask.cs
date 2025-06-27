using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoePart3Studentnumber10436849
{
    public partial class AddTask : Form
    {
        private string[] keywords = { "task", "quiz", "reminder", "password", "phishing" };
        private List<string> taskList = new List<string>();
        
        public AddTask()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            // Ask user if they want to set a reminder
            DialogResult result = MessageBox.Show("Would you like to set a reminder with a due date?",
                                                  "Set Reminder",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            DateTime? dueDate = null;

            if (result == DialogResult.Yes)
            {
                // Show date picker
                Form dateForm = new Form()
                {
                    Width = 250,
                    Height = 120,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Select Due Date",
                    StartPosition = FormStartPosition.CenterParent
                };

                DateTimePicker picker = new DateTimePicker()
                {
                    MinDate = DateTime.Today,
                    Location = new Point(10, 10),
                    Width = 200
                };

                Button okButton = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(70, 40)
                };

                dateForm.Controls.Add(picker);
                dateForm.Controls.Add(okButton);
                dateForm.AcceptButton = okButton;

                if (dateForm.ShowDialog() == DialogResult.OK)
                {
                    dueDate = picker.Value;
                }
            }

            taskList.Add(input);
            panel1.Visible = false;

            AppendColoredText("User: ", Color.Red, true);
            AppendColoredText($"\"{input}\"\n", Color.Black, false);

            string response;
            if (dueDate.HasValue)
            {
                int daysLeft = (dueDate.Value.Date - DateTime.Today).Days;
                response = $"Reminder set for \"{dueDate.Value.ToShortDateString()}\". You are left with {daysLeft} day(s) until your task.";

                // Add keyword if detected
                string keyword = DetectKeyword(input);
                if (keyword != null)
                {
                    response += $" ('{keyword}:{input}')";
                }
            }
            else
            {
                response = GenerateChatbotResponse(input);
            }

            AppendColoredText("Chatbot: ", Color.Green, true);
            AppendColoredText($"\"{response}\"\n\n", Color.Black, false);

            textBox1.Clear();
        }

        private string GenerateChatbotResponse(string input)
        {
            input = input.ToLower();

            string keyword = DetectKeyword(input);
            string keywordNote = keyword != null ? $" (Keyword detected: '{keyword}')" : "";

            if (input.Contains("remind") || input.Contains("reminder"))
            {
                string reminderText = input.Replace("remind me to", "").Trim();
                return $"{keywordNote}:Reminder set for '{reminderText}' on tomorrow's date.";
            }
            else if (input.Contains("task"))
            {
                string taskText = input.Replace("add a task to", "").Trim();
                return $"{keywordNote}:Task added: '{taskText}'. Would you like to set a reminder for this task?";
            }
            else if (input.Contains("what have you done"))
            {
                string summary = "Here’s a summary of recent actions:\n";
                for (int i = 0; i < taskList.Count; i++)
                {
                    summary += $"{i + 1}. {taskList[i]}\n";
                }
                return summary.TrimEnd();
            }
            else if (keyword != null)
            {
                return $"Task added with keyword: '{keyword}'.";
            }
            else
            {
                return $"Task added: '{input}'.";
            }
        }

        private string DetectKeyword(string input)
        {
            foreach (var k in keywords)
            {
                if (input.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                    return k;
            }
            return null;
        }

        private void AppendColoredText(string text, Color color, bool bold)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = color;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, bold ? FontStyle.Bold : FontStyle.Regular);
            richTextBox1.AppendText(text);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            richTextBox1.AppendText("Search results:\n");

            bool found = false;
            foreach (string task in taskList)
            {
                if (task.ToLower().Contains(searchTerm))
                {
                    richTextBox1.AppendText($"- {task}\n");
                    found = true;
                }
            }

            if (!found)
            {
                richTextBox1.AppendText("No matching tasks found.\n");
            }

            richTextBox1.AppendText("\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            richTextBox1.AppendText("Search results:\n");

            foreach (string task in taskList)
            {
                if (task.ToLower().Contains(searchTerm))
                {
                    MessageBox.Show($"YOU HAVE SEARCHED {task}\n");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Reserved for future use
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Visible = true;

            if (taskList.Count == 0)
            {
                MessageBox.Show("No tasks available.");
                panel1.Visible = false;
                return;
            }

            int y = 10;

            foreach (string task in taskList)
            {
                CheckBox cb = new CheckBox();
                cb.Text = task;
                cb.AutoSize = true;
                cb.ForeColor = Color.Black;
                cb.Location = new Point(10, y);
                y += 30;

                cb.CheckedChanged += (s, ev) =>
                {
                    CheckBox clicked = s as CheckBox;
                    if (clicked.Checked)
                    {
                        MessageBox.Show("Task complete");
                        clicked.ForeColor = Color.Green;
                    }
                    else
                    {
                        clicked.ForeColor = Color.Black;
                    }
                };

                panel1.Controls.Add(cb);
            }
        }

        private void AddTask_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    
}
    }


