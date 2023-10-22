using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        List<string> symbols = new List<string>();
        string action, result = "";

        public void Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string classId = button.ClassId;


            if (result != "") // проверяем, есть ли результат, если нет, то считаем все по новой
            {
                // результат есть, проверяем, что ввел пользователь

                if (!"plusminusdividemultiplypowequal".Contains(classId))
                //  Работает хорошо
                {
                    // ввел число, значит пользователь
                    // пытается ввести новый пример,

                    // либо уже ввел операцию и
                    // пытается ввести второе чило
                    // проверим это:

                    if (!(symbols.Contains("/") || symbols.Contains("*") || symbols.Contains("+") || symbols.Contains("-"))) // ???
                    //  Работает хорошо
                    {

                        // операция не была введена, а значит
                        // пользователь вводит новый пример, для которого
                        // результат предыдущей операции не нужен

                        symbols.Remove(result);
                        result = "";        // стираем результат работы предыдущей операции
                        Result.Text = "";   // очищаем поле вывода, новое число
                                            // будет выведено ниже в switch-case
                    }

                }
                else
                {
                    // ввел операцию, значит пользователь
                    // пытается что-то сделать со старым результатом

                    //if("+-*/".Contains(symbols.Last()))
                      //  symbols.Remove(symbols.Last());
                    if (!"equal".Contains(classId))
                        Result.Text = result; // выведем старый результат на экран
                    //if (!"/*+-^/".Contains(symbols[1]))

                    //else
                    //{

                    //}

                }
            }

            switch (classId)
            {
                case "zero":
                    Result.Text += 0;
                    symbols.Add("0");
                    break;
                case "one":
                    Result.Text += 1;
                    symbols.Add("1");
                    break;
                case "two":
                    Result.Text += 2;
                    symbols.Add("2");
                    break;
                case "three":
                    Result.Text += 3;
                    symbols.Add("3");
                    break;
                case "four":
                    Result.Text += 4;
                    symbols.Add("4");
                    break;
                case "five":
                    Result.Text += 5;
                    symbols.Add("5");
                    break;
                case "six":
                    Result.Text += 6;
                    symbols.Add("6");
                    break;
                case "seven":
                    Result.Text += 7;
                    symbols.Add("7");
                    break;
                case "eight":
                    Result.Text += 8;
                    symbols.Add("8");
                    break;
                case "nine":
                    Result.Text += 9;
                    symbols.Add("9");
                    break;
                case "plus":
                    Result.Text += " + ";
                    action = "+";
                    symbols.Add("+");
                    break;
                case "minus":
                    Result.Text += " - ";
                    action = "-";
                    symbols.Add("-");
                    break;
                case "divide":
                    Result.Text += " / ";
                    action = "/";
                    symbols.Add("/");
                    break;
                case "multiply":
                    Result.Text += " * ";
                    action = "*";
                    symbols.Add("*");
                    break;
                case "pow":
                    Result.Text += " ^ ";
                    action = "^";
                    symbols.Add("^");
                    break;
                case "equal":
                    symbols.Add(" = ");
                    result = Count();
                    Result.Text += " = " + result;
                    symbols = new List<string>() { result };
                    action = "";
                    break;
                case "clean":
                    Result.Text = "";
                    symbols = new List<string>();
                    action = "";
                    break;
                default:
                    Result.Text = "";
                    break;
            }
        }

        private string Count()
        {
            List<double> digitsOnly = new List<double>();

            string perem = "";
            foreach (string symbol in symbols) // двузначное число, где правое число не больше левого на 1 - не проходят
            {
                try
                {
                    Convert.ToInt32(symbol);
                    perem += symbol;
                }
                catch (Exception)
                {
                    digitsOnly.Add(Convert.ToInt32(perem));
                    perem = "";
                }

            }

            switch (action)
            {
                case "+":
                    return (digitsOnly[0] + digitsOnly[1]).ToString();
                case "-":
                    return (digitsOnly[0] - digitsOnly[1]).ToString();
                case "/":
                    if (digitsOnly[1] == 0)
                        return "Невозможно!";
                    return (digitsOnly[0] / digitsOnly[1]).ToString();
                case "*":
                    return (digitsOnly[0] * digitsOnly[1]).ToString();
                case "^":
                    return Math.Pow(digitsOnly[0], digitsOnly[1]).ToString();
                default:
                    return "";
            }
        }
    }
}
