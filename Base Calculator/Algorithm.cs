using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Base_Calculator
{
    public abstract class Algorithm
    {
        public static string ConvertMantissa(double value, int newBase)
        {
            string output = "";
            Stack<Int64> remainderStack = new Stack<Int64>();
            double v = value;

            while(v > 0.0 && remainderStack.Count < 20)
            {
                Console.WriteLine("v "+v);
                remainderStack.Push((int)(v * (double)newBase));
                Console.WriteLine("peek " + Convert.ToInt64(v * newBase));
                v = Math.Abs( (double)((int)(v*newBase) - (v*newBase)));
            }

            while(remainderStack.Count > 0)
            {
                if(remainderStack.Peek() > 9)
                {
                    char numToChar = IntToChar((int)remainderStack.Pop());
                    output += numToChar;
                }
                else
                {
                    output += remainderStack.Pop();
                }
               
            }
            return Reverse(output);
        }
        
        public static string ConvertCharacteristic(int value, int newBase)
        {
            string output = "";
            Stack<Int64> remainderStack = new Stack<Int64>();
            int v = value;

            while(v >= newBase)
            {
                remainderStack.Push(v % newBase);
                v /= newBase;
            }
            remainderStack.Push(v);

            while(remainderStack.Count > 0)
            {
                if(remainderStack.Peek() > 9)
                {
                    char numToChar = IntToChar((int)remainderStack.Pop());
                    output += numToChar;
                }
                else
                {
                    output += remainderStack.Pop();
                }
            }

            return output;
        }
        public static string ConvertToBase10(string value, int oldBase)
        {
            string characteristic = value.Split('.')[0].ToUpper();
            string mantissa = value.Split('.')[1].ToUpper();
            long base10whole = 0;
            double base10frac = 0.0;
            List<char> wholeNum = new List<char>();
            List<char> fracNum = new List<char>();

            foreach (char c in characteristic)
            {
                if(IsDigit(c))
                {
                    base10whole = (oldBase * base10whole) 
                        + Int64.Parse(c.ToString());
                }
                else
                {
                    base10whole = (oldBase * base10whole)
                        + Int64.Parse(CharToInt(c).ToString());
                }
            }

            for (int i = 0; i < mantissa.Length; i++)
            {
                if (IsDigit(mantissa[i]))
                {
                    base10frac +=
                        Double.Parse(mantissa[i].ToString()) *
                        Math.Pow(oldBase, -Math.Abs(i + 1));
                }
                else
                {
                    base10frac +=
                        Double.Parse(CharToInt(mantissa[i]).ToString()) *
                        Math.Pow(oldBase, -Math.Abs(i + 1));
                }
            }
            return ValidateInput( Convert.ToString(Convert.ToDouble(base10whole) + base10frac));
        }
        public static void Calculate(string value, int oldBase, int newBase, ref TextBox outputbox)
        {
            string output = "";
            string[] newVal = 
                ConvertToBase10(ValidateInput(value.ToUpper()), oldBase)
                .Split('.');
            int characteristic = (int)UInt64.Parse(newVal[0]);
            double mantissa = Double.Parse("0."+newVal[1]);
            output = ValidateInput ($"{ConvertCharacteristic(characteristic, newBase)}.{ConvertMantissa(mantissa, newBase)}");
            
            MainWindow.UpdateOutput(output, ref outputbox);
        }

         public static bool IsDigit(char c)
        {
            if (c < 91 && c > 64) return false;
            else return true;
        }

        public static int CharToInt(char c)
        {
            return (char)(c - 55);
        }
        public static char IntToChar(int i)
        {
            return (char)(i + 55);
        }
        public static String ValidateInput(string value)
        {
            if (value.Contains('.'))
            {
                if (value.Split('.')[1].Length > 0)
                    return value;
                else return value + "0";
            }
            
                return value + ".0";
           
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}