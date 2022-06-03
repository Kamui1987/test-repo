using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();
            
            string userName = GetAppUserName();

            GreetingUser(userName);

            Random random = new Random();

            int correctNumber = random.Next(1,11);

            bool gameEnded = false;

            

            int punkty = 0; 


            while (!gameEnded)
            {
                Console.WriteLine("Zgadnij wylosowaną liczbę od 1 do 10");

                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);

                if (!isNumber)
                {
                    string error = "Nie podałeś liczby Geniuszu!";
                    PrintColorMessage(ConsoleColor.Red, error);
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Red, "Wprowadziłeś liczbę spoza zakresu");
                    continue;
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Spróbuj wyżej");
                }

                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Spróbuj niżej");
                }

                else
                {
                    PrintColorMessage(ConsoleColor.Green, "Jebany, trafiłeś!");
                    punkty += 1;
                    Console.Clear();
                    Console.WriteLine("Twoje punkty: " + punkty);

                    if (punkty >= 2)
                    {
                        Console.WriteLine("YOU WIN!");
                        gameEnded = true;
                        
                    }


                }
                

                
            }

            
        }

        static void GetAppInfo()
        {
            string appName = "Gra w zgadywanie liczby";
            int appVersion = 1;
            string appAuthor = "Dawid Żak";

            string info = $"[{appName}] wersja: 0.0.{appVersion} autor: {appAuthor}";

            PrintColorMessage(ConsoleColor.Magenta, info);
        }

        static string GetAppUserName()
        {
            Console.WriteLine("Podaj imię");

            string addUserName = Console.ReadLine();

            return addUserName;

            
        }

        static void GreetingUser(string userName)
        {           
            string greeting = $"Powodzenia podczas rozgrywki {userName}, wybierz liczbę:";
            PrintColorMessage(ConsoleColor.Blue, greeting);

        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

