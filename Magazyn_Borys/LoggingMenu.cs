using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_Borys
{
    class LoggingMenu
    {
        private static string login;

        // logowanie na odpowiednie konto użytkownika
        public static void loggingIn()
        {
            Console.Clear();
            MainMenu.drawLogo();
            MainMenu.textCentering("\n\n\n");
            int loginTryCount = 3;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("                                        Wpisz login: ");
                login = Console.ReadLine();
                foreach (User user in User.UserList)
                {
                    if (login == user.Login)
                    {
                        int pswTryCount = 3;
                        for (int j = 0; j < 3; j++)
                        {
                            string password = "";
                            ConsoleKeyInfo key;
                            Console.Write("                                        Wpisz hasło: ");
                            do
                            {
                                key = Console.ReadKey(true);
                                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                                {
                                    password += key.KeyChar;
                                    Console.Write("*");
                                }
                                else
                                {
                                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                                    {
                                        password = password.Substring(0, (password.Length - 1));
                                        Console.Write("\b \b");
                                    }
                                }
                            }
                            while (key.Key != ConsoleKey.Enter);
                            if (password == user.Password)
                            {
                                Program.isLogged = true;
                                Program.whoIsLogged = user.Login;
                                break;
                            }
                            else
                            {
                                pswTryCount--;
                                Console.Write("\n\n");
                                Console.Write($"                              Hasło nieprawidłowe. Pozostało prób: {pswTryCount}\n");
                                Console.ReadKey();
                                Console.Clear();
                                MainMenu.drawLogo();
                                MainMenu.textCentering("\n\n\n");
                                Console.Write($"                                        Wpisz login: ");
                                Console.Write($"{login}\n");
                                if (pswTryCount == 0)
                                {
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                    else
                    {
                        if(user.ID == User.UserList.Count)
                        {
                            loginTryCount--;
                            Console.Write("\n");
                            Console.Write($"                              Login nieprawidłowy. Pozostało prób: {loginTryCount}\n");
                            Console.ReadKey();
                            Console.Clear();
                            MainMenu.drawLogo();
                            MainMenu.textCentering("\n\n\n");
                            if (loginTryCount == 0)
                            {
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (Program.isLogged == true)
                        break;
                }
                if (Program.isLogged == true)
                    break;
            }
            if (Program.isLogged == true)
            {
                Console.WriteLine();
                Console.Write("\n");
                Console.Write("                                        Zalogowano pomyślnie!\n");
                Console.ReadKey();
                Console.Clear();
                MainMenu.drawLogo();
                MainMenu.drawOptions();
                MainMenu.takeOrder();
            }
        }

        // wylogowywanie z konta użytkownika
        public static void loggingOut()
        {
            for(int i = 0; i < 1; i++)
            {
                Console.Clear();
                MainMenu.drawLogo();
                MainMenu.textCentering("\n\n\n");
                MainMenu.textCentering("Czy na pewno chcesz się wylogować? (y/n)");
                char logOutAns = Console.ReadKey().KeyChar;
                Console.Write("\b");
                if (logOutAns == 'y')
                {
                    Program.isLogged = false;
                    Program.whoIsLogged = "Niezalogowano";
                    MainMenu.textCentering("\n");
                    MainMenu.textCentering("Wylogowano pomyślnie!\n");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu.drawLogo();
                    MainMenu.drawOptions();
                    MainMenu.takeOrder();
                }
                else if (logOutAns == 'n')
                {
                    Console.Clear();
                    MainMenu.drawLogo();
                    MainMenu.drawOptions();
                    MainMenu.takeOrder();
                }
                else
                {                   
                    Console.WriteLine("\n");                    
                    MainMenu.textCentering("Niedozwolona odpowiedź!\n");
                    Console.ReadKey();
                    i--;
                }
            }
        }
    }
}