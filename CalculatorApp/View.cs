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
            if (button.Text.Equals(".") && inputLable.Text.Contains("."))
            {
                return;
            }
            if (inputLable.Text[0] == '0'&&inputLable.Text.Length>=1)
            {
                inputLable.Text = inputLable.Text.Substring(1);
            }
            inputLable.Text = inputLable.Text + button.Text;
        }
        private void change_Text(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(inputLable.Text))
            {
                try
                {
                    int input = comboBox1.SelectedIndex;
                    int output = comboBox2.SelectedIndex;
                    if (input < 5 && output < 5) 
                    { 
                        double outputCoeff = Math.Pow(60, output - input);
                        double outputValue = Double.Parse(inputLable.Text);
                        outputLable.Text = (outputValue / outputCoeff).ToString();
                    }
                    else
                    {
                        double outputCoeff = 1, outputValue;
                        if(input < output) 
                        {
                            for(int i = output; i > input; i--)
                            {
                                switch (i)
                                {
                                    case 5: outputCoeff *= 24;
                                        break;
                                    case 6: outputCoeff *= 7;
                                        break;
                                    case 7:
                                        outputCoeff *= 48;
                                        break;
                                    default:outputCoeff *= 60;
                                        break;
                                }
                            }
                            outputValue = Double.Parse(inputLable.Text);
                            string outputStr = (outputValue / outputCoeff).ToString();
                            if (outputStr.Length > 6)
                            {
                                outputStr = outputStr.Substring(0,6);
                            }
                            outputLable.Text = outputStr;
                        }
                        else
                        {
                            for (int i = input; i > output; i--)
                            {
                                switch (i)
                                {
                                    case 5:
                                        outputCoeff *= 24;
                                        break;
                                    case 6:
                                        outputCoeff *= 7;
                                        break;
                                    case 7:
                                        outputCoeff *= 48;
                                        break;
                                    default:
                                        outputCoeff *= 60;
                                        break;
                                }
                            }
                            outputValue = Double.Parse(inputLable.Text);
                            string outputStr = (outputValue / (1 / outputCoeff)).ToString();
                            if (outputStr.Length > 6)
                            {
                                outputStr = outputStr.Substring(0, 6);
                            }
                            outputLable.Text = outputStr;
                        }
                        

                    }
                    
                }
                catch (FormatException es)
                {
                   
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
