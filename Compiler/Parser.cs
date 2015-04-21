using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Compiler
{

    public class Parser
    {

        //Regex op = new Regex(@"^\(");
        Regex operators = new Regex(@"^\+|\-|\*|\/|sin|cos|tg|\(|\)|\^");
        Regex digit = new Regex(@"^\d+((\.[0-9]+)?)?");
        

        //List<string> operators = new List<string>(new string[] { "+", "-", "*", "/", "^", "(", ")" }); // operators
        List<string> stack = new List<string>(); // stack for operators
        List<string> rpn = new List<string>(); // reverse polish notation

        double number;
        List<double> numbers = new List<double>();

        /// <summary>
        /// parse input string
        /// </summary>
        public List<string> Parse(string expression)
        {
            int topStackPriority; //
            int operatorPriority; //

            string input = expression;

            while (input.Length > 0)
            {
                if (digit.Match(input).Success || operators.Match(input).Success)
                {
                    if (digit.Match(input).Success)
                    {
                        string number = digit.Match(input).Value;
                        number = number.Replace(".", ",");
                        rpn.Add(number);
                        input = input.Substring(number.Length, input.Length - number.Length);
                    }

                    if (operators.Match(input).Success)
                    {
                        string operation = operators.Match(input).Value;

                        if (stack.Count == 0 || operation == "(") // if token is open bracket add it to the stack
                            stack.Add(operation);
                        else
                        {
                            if (operation == ")") // if token is close bracket
                            {
                                // move operators from the stack to the reverse polish notation until we meet open bracket
                                while (stack[stack.Count - 1] != "(")
                                {
                                    rpn.Add(stack[stack.Count - 1]);
                                    stack.RemoveAt(stack.Count - 1);
                                }

                                stack.RemoveAt(stack.Count - 1);
                            }

                            // if current operator is not open or close bracket:


                            else /*(stack.Count > 0)*/
                            {
                                // get priorities of current operator and operator at the top of the stack

                                topStackPriority = getPriority(stack[stack.Count - 1]);
                                operatorPriority = getPriority(operation);

                                // move operator from the stack to RPN until priority of current token more than priority of operator at the top of the stack
                                while (stack.Count > 0 && topStackPriority >= operatorPriority)
                                {
                                    rpn.Add(stack[stack.Count - 1]);
                                    stack.RemoveAt(stack.Count - 1);

                                    if (stack.Count == 0)
                                        break;

                                    topStackPriority = getPriority(stack[stack.Count - 1]);
                                    operatorPriority = getPriority(operation);
                                }

                                // add current operator to the stack
                                stack.Add(operation);
                            }
                        }

                        input = input.Substring(operation.Length, input.Length - operation.Length);

                    }
                }

                else
                    throw new Exception("Недопустимый символ");
            }
            // we parse string but the stack can contain operators, so we move them to the RPN
            while (stack.Count > 0)
            {
                rpn.Add(stack[stack.Count - 1]);
                stack.RemoveAt(stack.Count - 1);
            }

                return rpn; // return reverse polish notation
            
        }

        public double Calculate(List<string> rpn)
        {
            foreach (string token in rpn )
            {
                if (digit.Match(token).Success)
                    numbers.Add(Convert.ToDouble(token));
                else
                {
                    if (getPriority(token) == 3 && token != "^")
                    {
                        switch (token)
                        {
                            case "sin":
                                double num = numbers[numbers.Count - 1];
                                number = Math.Sin(numbers[numbers.Count - 1]);
                                break;
                            case "cos":
                                number = Math.Cos(numbers[numbers.Count - 1]);
                                break;
                            case "tg":
                                number = Math.Tan(numbers[numbers.Count - 1]);
                                break;
                        }
                    }
                    else
                    {
                        switch (token)
                        {
                            case "+":
                                number = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
                                numbers.RemoveAt(numbers.Count - 1);
                                break;
                            case "-":
                                number = numbers[numbers.Count - 2] - numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                break;
                            case "*":
                                number = numbers[numbers.Count - 1] * numbers[numbers.Count - 2];
                                numbers.RemoveAt(numbers.Count - 1);
                                break;
                            case "/":
                                number = numbers[numbers.Count - 2] / numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                break;
                            case "^":
                                number = Math.Pow(numbers[numbers.Count - 2], numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                                break;

                        }
                    }

                    numbers[numbers.Count - 1] = number;
                }
            }

            return number;
        }

        private int getPriority(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                case "sin":
                case "cos":
                case "tg":
                    return 3;
            }

            return 0;
        }
    
    
    }
}
