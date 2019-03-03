using System;

namespace ConsoleApplicationForlearning
{
    public class Program
    {

        static string operators = "+ - * /";
        public static void Main(string[] args)
        {
            Calculate calc = new Calculate();
            Console.WriteLine("Enter First Number...");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number...");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Select an Operator: {operators}");
            string operations = Console.ReadLine();

            switch (operations)
            {
                case "+":
                    Console.WriteLine($"Sum of two number is: {calc.Add(firstNumber, secondNumber)}");
                    break;
                case "-":
                    Console.WriteLine($"Difference of two number is: {calc.Sub(firstNumber, secondNumber)}");
                    break;
                case "*":
                    Console.WriteLine($"Multiplied of two number is: {calc.Multi(firstNumber, secondNumber)}");
                    break;
                case "/":
                    Console.WriteLine($"Division of two number is: {calc.Devide(firstNumber, secondNumber)}");
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }


            Console.ReadKey();
        }

    }
}
