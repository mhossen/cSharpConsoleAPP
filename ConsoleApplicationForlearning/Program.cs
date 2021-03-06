﻿using ConsoleApplicationForlearning.Controller;
using ConsoleApplicationForlearning.Data;
using ConsoleApplicationForlearning.Utility;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleApplicationForlearning
{
    public class Program
    {

        static string operators = "+ - * /";
        public static void Main(string[] args)
        {
            EmployeeController empController = new EmployeeController();

            // Employee empolyeeData = SaveEmployeeData();

            //  employee.CreateNewEmployee(empolyeeData.FirstName, empolyeeData.LastName, empolyeeData.Email, empolyeeData.Gender, empolyeeData.Age);

            Console.WriteLine("Enter employee Id....");
            int id = Convert.ToInt32(Console.ReadLine());


            //var getData = employee.GetEmployeeById(id);
            var getData = empController.GetEmployees();

            Employee employee = getData.Where(e => e.Id.Equals(id)).FirstOrDefault();
            Console.WriteLine($"FirstName: {employee.FirstName}, LastName: {employee.LastName}, Email: {employee.Email}, Age: {employee.Age}");



            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }

        public static Employee SaveEmployeeData()
        {
            Employee employee = new Employee();
            do
            {
                Console.WriteLine("Enter First Name...");
                employee.FirstName = Console.ReadLine();

                if (employee.FirstName.Length < 3)
                    Console.WriteLine("First name must be atleast 3 charecters long...");
            } while (employee.FirstName.Length < 3);

            do
            {

                Console.WriteLine("Enter Last Name...");
                employee.LastName = Console.ReadLine();

                if (employee.LastName.Length < 3)
                    Console.WriteLine("Last name must be atleast 3 charecters long...");
            } while (employee.LastName.Length < 3);

            do
            {
                Console.WriteLine("Enter Email...");
                employee.Email = Console.ReadLine();

                if (!IsValidEmail(employee.Email))
                    Console.WriteLine("Please enter valid email format");

            } while (!IsValidEmail(employee.Email));

            do
            {
                Console.WriteLine("Enter Gender for [Male] or [Female]...");
                employee.Gender = Console.ReadLine();

                if (!(employee.Gender.Equals("Male") || employee.Gender.Equals("Female")))
                    Console.WriteLine("Please enter only Male or Female");
            } while (!(employee.Gender.Equals("Male") || employee.Gender.Equals("Female")));

            Console.WriteLine("Enter Age...");
            employee.Age = Convert.ToInt32(Console.ReadLine());
            return employee;
        }


        private static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public static void SelectCorrectValue()
        {
            string firstNumber = string.Empty;
            string secondNumber = string.Empty;
            string respone = string.Empty;
            do
            {

                Calculate calc = new Calculate();

                do
                {
                    Console.WriteLine("Enter First Number...");
                    firstNumber = Console.ReadLine();

                } while (int.TryParse(firstNumber, out int value) == false);

                do
                {

                    Console.WriteLine("Enter Second Number...");
                    secondNumber = Console.ReadLine();
                } while (int.TryParse(secondNumber, out int value) == false);



                Console.WriteLine($"Select an Operator: {operators}");
                string operations = Console.ReadLine();

                GetOperator(operations, calc, Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
                Console.WriteLine("Would you like to exit? Type [Yes] to exit!!");
                respone = Console.ReadLine();
            } while (!respone.ToLower().Equals("yes"));

            Console.WriteLine("Press any key to exit...");
        }



        private static void GetOperator(string operand, Calculate calc, int firtNum, int secondNum)
        {
            switch (operand)
            {
                case "+":
                    Console.WriteLine($"Sum of two number is: {calc.Add(firtNum, secondNum)}");
                    break;
                case "-":
                    Console.WriteLine($"Difference of two number is: {calc.Sub(firtNum, secondNum)}");
                    break;
                case "*":
                    Console.WriteLine($"Multiplied of two number is: {calc.Multi(firtNum, secondNum)}");
                    break;
                case "/":
                    Console.WriteLine($"Division of two number is: {calc.Devide(firtNum, secondNum)}");
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        }

    }
}
