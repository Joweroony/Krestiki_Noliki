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
using System.IO;
using System.Security;

namespace Krestiki_Noliki_ver0._1
{
    public partial class Form1 : Form
    {
        private int x = 0, y = 0; 
        private Button[,] buttons = new Button[3, 3]; 
        private int player, symbol;
        private string t1 = "x", t2="o";

        public Form1()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 900;
            player = 1;
            symbol = 0;
            label1.Text = "Текущий ход: " + textBox1.Text;
            label2.Text = (x+":"+y);
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = t1;
            label7.Text = t2;
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++) 
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);
                }
            }
            setButtons();

        }
        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 206 * j, 12 + 206 * i); 
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 138);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            button4.Enabled = false;
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, t1);
                    player = 0;
                    label1.Text = "Текущий ход: "+textBox2.Text;
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, t2);
                    player = 1;
                    label1.Text = "Текущий ход: " + textBox1.Text;
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false); 
            checkWin();
        }

        private void button10_Click(object sender, EventArgs e) 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                    button4.Enabled = true;
                    player = 1;
                    label1.Text = "Текущий ход: " + textBox1.Text;
                }
            }
        }

        private void whoWin()
        {
            switch (player)
            {
                case 0: 
                    MessageBox.Show(textBox1.Text + " победил(a)!"); 
                    x++; 
                    label2.Text = (x + ":" + y);
                    break;
                case 1: 
                    MessageBox.Show(textBox2.Text + " победил(a)!"); 
                    y++; 
                    label2.Text = (x + ":" + y); 
                    break;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                    button4.Enabled = true;
                    player = 1;
                    label1.Text = "Текущий ход: " + textBox1.Text;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            label2.Text = (x + ":" + y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label3.Text == "")
                label3.Text = (textBox1.Text + " " + x + " : " + y + " " + textBox2.Text);
            else if (label3.Text != "" && label4.Text == "") label4.Text = (textBox1.Text + " " + x + " : " + y + " " + textBox2.Text);
            else if (label3.Text != "" && label4.Text != "" && label5.Text == "") label5.Text = (textBox1.Text + " " + x + " : " + y + " " + textBox2.Text);
            else if (label3.Text != "" && label4.Text != "" && label5.Text != "") MessageBox.Show("Нет свободных ячеек!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch(symbol)
            {
                case 0:
                    t1 = "o";
                    t2 = "x";
                    symbol = 1;
                    label6.Text = t1;
                    label7.Text = t2;
                    break;
                case 1:
                    t1 = "x";
                    t2 = "o";
                    symbol = 0;
                    label6.Text = t1;
                    label7.Text = t2;
                    break;
            }
        }

        private void checkWin()  

        {

            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text)
            {

                if (buttons[0, 0].Text != "")
                {
                    whoWin();
                }
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text != "")
                    whoWin();
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                    whoWin();
            }
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text != "")
                    whoWin();
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text != "")
                    whoWin();
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text != "")
                    whoWin();
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text != "")
                    whoWin();
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                    whoWin();
            }
        }

    }
}
