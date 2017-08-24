using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace FastFingers
{
    public partial class Form1 : Form
    {
        private int delay;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://10fastfingers.com/typing-test/english");
        }

        private void Fix()
        {
            string text = richTextBox1.Text;

            text = text.Replace("<div id=\"row1\" style=\"top: 1px;\"><span wordnr=\"0\" class=\"highlight\">", "");
            text = text.Replace("</span>", "");
            text = text.Replace(" class=\"\">", "");
            for (int i = 1; i < 10000; i++) //Hardcoding becase why not (?
            {
                text = text.Replace("<span wordnr=\"" + i + "\"", "");
            }
            text = text.Replace("</div>", "");
            richTextBox1.Text = text;
        }

        private void Start()
        {
            delay = Convert.ToInt32(numericUpDown1.Value);
            if (MessageBox.Show(@"Will start 2 seconds after this message is closed. Do you wish to continue?",
                    @"Continue?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) !=
                DialogResult.Yes)
            {
                return;
            }
            Thread.Sleep(2000);
            TypeText();
        }

        private void TypeText()
        {
            var text = richTextBox1.Text.ToCharArray();

            for (int i = 0; i <= text.Length - 1; i++)
            {
                SendKeys.Send(text[i].ToString());
                Thread.Sleep(delay);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fix();
            Start();
        }
    }
}
