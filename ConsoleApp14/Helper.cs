using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public class Helper
    {
        public static bool Check<T>(T obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            if (!Validator.TryValidateObject(obj, context, results, true))
            {
                foreach (var error in results) 
                { 
                    Helper.WriteErrorMessage(error.ErrorMessage);
                }
                return false;
            }
            return true;
        }

        private const string _subMessage = "Enter";

        public static int GetInt(string value)
        {
            int result = 0;
            Console.WriteLine(_subMessage+" "+value+":");
            while(!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(_subMessage + " " + value + ":");
            }
            return result;
        }

        public static string GetString(string value) 
        {
            string result = String.Empty;
            Console.WriteLine(_subMessage + " " + value + ":");
            while (String.IsNullOrWhiteSpace(result = Console.ReadLine()))
            {
                Console.WriteLine(_subMessage + " " + value + ":");

            }
            return result;
        }

        public static void WriteSuccessfulMessage(string message)
        {
            var color=Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(  message);
            Console.ForegroundColor = color;
        }

        public static void WriteErrorMessage(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error! "+message);
            Console.ForegroundColor = color;
        }
    }
}
