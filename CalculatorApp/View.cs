using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        private void click_Button(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (inputLable.Text[0] == '0'&&inputLable.Text.Length>=1)
            {
                inputLable.Text = inputLable.Text.Substring(1);
            }
            inputLable.Text = inputLable.Text + button.Text;
        }
        private void change_Text(object sender, EventArgs e)
        {
            int value;
            if (!string.IsNullOrEmpty(inputLable.Text))
            {
                try
                {
                    value = Int32.Parse(inputLable.Text);
                    int input = comboBox1.SelectedIndex;
                    int output = comboBox2.SelectedIndex;
                    double outputCoeff = Math.Pow(60,output-input);
                    double outputValue = Double.Parse(inputLable.Text);
                    outputLable.Text = (outputValue / outputCoeff).ToString();
                }
                catch (InvalidCastException es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            inputLable.Text = "0";
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            string input = inputLable.Text;
            if (input.Length > 1)
            {
                inputLable.Text = input.Substring(0, input.Length - 1);
            }
            else
            {
                inputLable.Text = "0";
            }
        }
    }
}
