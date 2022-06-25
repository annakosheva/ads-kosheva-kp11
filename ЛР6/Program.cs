using System;

namespace Lab6Var10
{
    class Program
    {
        private static string DefaultHTML = "<html><head><title>Hello</title></head><body><p>This appears in the <i>browser</i>.</p></body></html>";
        
        static void Main(string[] args)
        {
            HTMLValidator validator = new HTMLValidator();
            int userChoice = 0;
            do
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("1 - Input from keyboard");
                Console.WriteLine("2 - Default HTML");
                Console.WriteLine("Any other key - Quit");
                string userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out userChoice))
                {
                    if (userChoice != 1 && userChoice != 2)
                        return;

                    string htmlCode = "";
                    if (userChoice == 1)
                    {
                        htmlCode = InputFromKeyboard(validator);
                    }
                    else if (userChoice == 2)
                    {
                        htmlCode = DefaultHTML;
                    }
                    try
                    {
                        validator.ParseString(htmlCode);
                        Console.WriteLine("HTML code is valid");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        validator.ClearStack();
                    }
                }
            }
            while (userChoice == 1 || userChoice == 2);
        }

        private static string InputFromKeyboard(HTMLValidator validator)
        {
            Console.WriteLine("Input HTML code:");
            string htmlCode = Console.ReadLine();
            return htmlCode;
        }
    }
}
