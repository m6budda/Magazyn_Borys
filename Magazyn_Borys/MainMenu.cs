using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_Borys
{
    public class MainMenu
    {
        // zmienna pobierająca wybór jednego z dostępnych poleceń
        static char cmdNumber;

        //rysuje logo programu
        public static void drawLogo()
        {
            textCentering("\n\n\n");
            textCentering("███╗   ███╗ █████╗  ██████╗  █████╗ ███████╗██╗   ██╗███╗   ██╗\n");
            textCentering("████╗ ████║██╔══██╗██╔════╝ ██╔══██╗╚══███╔╝╚██╗ ██╔╝████╗  ██║\n");
            textCentering("██╔████╔██║███████║██║  ███╗███████║  ███╔╝  ╚████╔╝ ██╔██╗ ██║\n");
            textCentering("██║╚██╔╝██║██╔══██║██║   ██║██╔══██║ ███╔╝    ╚██╔╝  ██║╚██╗██║\n");
            textCentering("██║ ╚═╝ ██║██║  ██║╚██████╔╝██║  ██║███████╗   ██║   ██║ ╚████║\n");
            textCentering("╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═══╝\n");
            textCentering("\n");
            textCentering("██████╗  ██████╗ ██████╗ ██╗   ██╗███████╗\n");
            textCentering("██╔══██╗██╔═══██╗██╔══██╗╚██╗ ██╔╝██╔════╝\n");
            textCentering("██████╔╝██║   ██║██████╔╝ ╚████╔╝ ███████╗\n");
            textCentering("██╔══██╗██║   ██║██╔══██╗  ╚██╔╝  ╚════██║\n");
            textCentering("██████╔╝╚██████╔╝██║  ██║   ██║   ███████║\n");
            textCentering("╚═════╝  ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝\n");
        }

        //rysuje opcje dostępne w menu głównym programu, + kto jest zalogowany
        public static void drawOptions()
        {
            textCentering("\n\n\n");
            if (Program.isLogged == false)
                textCentering("1 - Zaloguj   \n");
            else
                textCentering("1 - Wyloguj   \n");
            textCentering("\n\n");
            textCentering("2 - Przeglądaj\n");
            textCentering("\n\n");
            textCentering("3 - Statystyki\n");
            textCentering("\n\n");
            textCentering("4 - Opcje     \n");
            textCentering("\n\n");
            textCentering("5 - Wyjście   \n");
            textCentering("\n\n\n\n");
            textToRight("Zalogowany magazynier:\n");
            if(Program.whoIsLogged == null)
                textToRight("Niezalogowano");
            else
                textToRight(Program.whoIsLogged);
            textCentering("\n");
        }

        // pobiera wybór odpowiedniej opcji, wybiera odpowiadającą jej akcję
        public static void takeOrder()
        {
            cmdNumber = Console.ReadKey().KeyChar;
            if (cmdNumber == '1' && Program.isLogged == false)
            {
                LoggingMenu.loggingIn();
            }
            else if (cmdNumber == '1' && Program.isLogged == true)
            {
                LoggingMenu.loggingOut();
            }
            else if (cmdNumber == '2' && Program.isLogged == true)
            {
                Actions loggedAction = new ContentLogged();
                loggedAction.EnterContent();
            }
            else if (cmdNumber == '2' && Program.isLogged == false)
            {
                Actions unLoggedAction = new ContentUnlogged();
                unLoggedAction.EnterContent();
            }
            else if (cmdNumber == '3' && Program.isLogged == true)
            {
                Actions loggedAction = new ContentLogged();
                loggedAction.ShowStatistics();
            }
            else if (cmdNumber == '3' && Program.isLogged == false)
            {
                Actions unLoggedAction = new ContentUnlogged();
                unLoggedAction.ShowStatistics();
            }
            else if (cmdNumber == '4')
            {
                Options.showOptions();
            }
            else if (cmdNumber == '5')
            {
                Environment.Exit(0);
            }

            // użycie znaku nieodpowiadającego żadnej opcji nic nie zmienia w programie
            else
            {
                Console.Write("\b \b");
                takeOrder();
            }          
        }
        
        // centruje tekst w konsoli
        public static void textCentering(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.Write(text);
        }

        // wyrównuje tekst w konsoli do prawej strony okna
        public static void textToRight(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) - 2));
            Console.Write(text);
        }
    }
}