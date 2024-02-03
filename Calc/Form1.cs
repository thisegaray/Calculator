using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Screen : Form
    {

        // Variables necesarias
        public double Num1, Num2, Result;
        public bool Is1, Is2, Es_op;
        int Operation;
        const double PI = Math.PI;
        const double EULER = Math.E;


        // Botones de los números
        private void Button0_Click(object sender, EventArgs e)
        {
            UpdateTextBox("0");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UpdateTextBox("1");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UpdateTextBox("2");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            UpdateTextBox("3");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            UpdateTextBox("4");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            UpdateTextBox("5");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            UpdateTextBox("6");
        }


        private void Button7_Click(object sender, EventArgs e)
        {
            UpdateTextBox("7");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            UpdateTextBox("8");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            UpdateTextBox("9");
        }

        private void ButtonPoint_Click(object sender, EventArgs e)
        {
            UpdateTextBox(".");
        }

        private void ButtonPi_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            UpdateTextBox(PI.ToString());
        }

        private void ButtonEuler_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            UpdateTextBox(EULER.ToString());
        }


        // Botones de borrado
        private void ButtonClearEverything_Click(object sender, EventArgs e)
        {
            Num1 = Num2 = Result = 0;
            ClearTextBox();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }


        // Botones de los operadores
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if(!Is1)
            {
                Num1 = GetValue();
                Is1 = true;
                Operation = 0;
            }
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Is1 = true;
                Operation = 1;
            }
        }

        private void ButtonTimes_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Is1 = true;
                Operation = 2;
            }
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Is1 = true;
                Operation = 3;
            }
        }

        // Botones de operadoes TRIG
        private void ButtonSen_Click(object sender, EventArgs e)
        {
            if(!Is1)
            {
                Num1 = GetValue();
                Num1 = Math.Sin(Num1);
                Is1 = true;
                UpdateTextBox(Num1.ToString());
            }
            Is1 = false;
        }
        private void ButtonCos_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Num1 = Math.Cos(Num1);
                Is1 = true;
                UpdateTextBox(Num1.ToString());
            }
            Is1 = false;
        }

        private void ButtonTan_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                try
                {
                    Num1 = GetValue();
                    Num1 = Math.Tan(Num1);
                    Is1 = true;
                    UpdateTextBox(Num1.ToString());
                }
                catch
                {
                    MessageBox.Show("Indefinido");
                }
            }
            Is1 = false;
        }

        // Botones de operadores logarítmicos y potencias
        private void ButtonLog_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Num1 = Math.Log10(Num1);
                Is1 = true;
                UpdateTextBox(Num1.ToString());
            }
            Is1 = false;
        }

        private void ButtonLn_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Num1 = Math.Log(Num1);
                Is1 = true;
                UpdateTextBox(Num1.ToString());
            }
            Is1 = false;
        }

        private void ButtonPower_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                Num1 = GetValue();
                Is1 = true;
                Operation = 4;
            }
        }

        // Botón de igual
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            try {
                if(Operation == 0)
                {
                    if(Is1)
                    {
                        Num2 = GetValue();
                        UpdateTextBox(ToOperate(Num1, Num2, "+").ToString());
                        Is1 = false;
                    }
                }
                else if(Operation == 1)
                {
                    if (Is1)
                    {
                        Num2 = GetValue();
                        UpdateTextBox(ToOperate(Num1, Num2, "-").ToString());
                        Is1 = false;
                    }
                }
                else if(Operation == 2)
                {
                    if (Is1)
                    {
                        Num2 = GetValue();
                        UpdateTextBox(ToOperate(Num1, Num2, "*").ToString());
                        Is1 = false;
                    }
                }
                else if (Operation == 3)
                {
                    if(Is1)
                    {
                        Num2 = GetValue();
                        UpdateTextBox(ToOperate(Num1, Num2, "/").ToString());
                        Is1 = false;
                    }
                }
                else if (Operation == 4)
                {
                    if(Is1)
                    {
                        Num2 = GetValue();
                        UpdateTextBox(ToOperate(Num1, Num2, "^").ToString());
                        Is1 = false;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una operación para realizar");
                }
            }
            catch
            {
                MessageBox.Show("Esta operacion requiere dos operandos");
            }
        }


        // Funcionalidades
        public void ClearTextBox()
        {
            TextBoxCalc.Text = "";
        }

        public double GetValue()
        {
            double value = Convert.ToDouble(TextBoxCalc.Text);
            ClearTextBox();
            return value;
        }

        // Lógica de la calculadora
        public double ToOperate(double operator1, double operator2, String signo)
        {
            double Result = 0.0;
            switch (signo)
            {
                case "+":
                    Result = operator1 + operator2;
                    break;
                case "-":
                    Result = operator1 - operator2;
                    break;
                case "*":
                    Result = operator1 * operator2;
                    break;
                case "/":
                    if(Num2 != 0)
                    {
                        Result = operator1 / operator2;
                        break;
                    }
                    MessageBox.Show("No se puede dividir entre cero");
                    break;
                case "^":
                    Result = Math.Pow(operator1, operator2);
                    break;
                default:
                    break;
            }
            return Result;
        }

        public void UpdateTextBox(string text)
        {
            TextBoxCalc.Text = TextBoxCalc.Text + text;
        }

        public Screen()
        {
            Is1 = Is2 = false;
            InitializeComponent();
        }
    }
}
