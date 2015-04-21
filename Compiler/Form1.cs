using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void parse_Click(object sender, EventArgs e)
        {
            string expression_to_parse = expression.Text;

            try
            {
                BracketBalance(expression_to_parse);



                List<string> rpn_list = new List<string>();

                Parser parser = new Parser();

                rpn_list = new List<string>(parser.Parse(expression_to_parse));


                string rpn_string = "";

                for (int i = 0; i < rpn_list.Count; i++)
                {
                    rpn_string += rpn_list[i];
                    rpn_string += " ";
                }

                rpn.Text = rpn_string;



                result.Text = Convert.ToString(parser.Calculate(rpn_list));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BracketBalance(string expr)
        {
            int openBracketCount = PosCount("(", expr);
            int closeBracketCount = PosCount(")", expr);

            if (openBracketCount != closeBracketCount)
            {
                throw new Exception("Баланс скобок нарушен");
            }
        }

        public int PosCount(string substr, string str)
        {
            return str.Split(new string[] { substr }, StringSplitOptions.None).Length - 1;
        }
    }
}
