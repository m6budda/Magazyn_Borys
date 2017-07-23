using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Magazyn_Borys
{
    class Options
    {
        // zmienna pobierająca wybór jednego z dostępnych poleceń (kolorów tła konsoli)
        static char optionSelect;

        // wyświetla menu opcji programu
        public static void showOptions()
        {
            showOptionsMenu();
            manageOptions();
        }

        // menu opcji programu
        public static void showOptionsMenu()
        {
            Console.Clear();
            MainMenu.drawLogo();
            Console.Write("\n\n\n");
            MainMenu.textCentering("Wybierz kolor tła programu: \n");
            MainMenu.textCentering("\n");
            MainMenu.textCentering("1 - czerwony, 2 - niebieski, 3 - zielony \n");
        }

        // pobiera wybór odpowiedniej opcji dot. koloru tła konsoli, wybiera odpowiadającą jej akcję
        public static void manageOptions()
        {
            optionSelect = Console.ReadKey().KeyChar;
            if (optionSelect == '1')
            {
                Program.defaultBCGColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = Program.defaultBCGColor;
                Program.optionsColor = "1";
                File.Delete(Program.optionsColorPath[0]);
                File.WriteAllText(Program.optionsColorPath[0], Convert.ToString(Program.optionsColor), Encoding.GetEncoding("Windows-1250"));
                Console.Clear();
                showOptionsMenu();
                MainMenu.textCentering("\n");
                MainMenu.textCentering("Wybrano kolor.\n");
                Console.ReadKey();
                Console.Clear();
                MainMenu.drawLogo();
                MainMenu.drawOptions();
                MainMenu.takeOrder();
            }
            if (optionSelect == '2')
            {
                Program.defaultBCGColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = Program.defaultBCGColor;
                Program.optionsColor = "2";
                File.Delete(Program.optionsColorPath[0]);
                File.WriteAllText(Program.optionsColorPath[0], Convert.ToString(Program.optionsColor), Encoding.GetEncoding("Windows-1250"));
                Console.Clear();
                showOptionsMenu();
                MainMenu.textCentering("\n");
                MainMenu.textCentering("Wybrano kolor.\n");
                Console.ReadKey();
                Console.Clear();
                MainMenu.drawLogo();
                MainMenu.drawOptions();
                MainMenu.takeOrder();
            }
            if (optionSelect == '3')
            {
                Program.defaultBCGColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = Program.defaultBCGColor;
                Program.optionsColor = "3";
                File.Delete(Program.optionsColorPath[0]);
                File.WriteAllText(Program.optionsColorPath[0], Convert.ToString(Program.optionsColor), Encoding.GetEncoding("Windows-1250"));
                Console.Clear();
                showOptionsMenu();
                MainMenu.textCentering("\n");
                MainMenu.textCentering("Wybrano kolor.\n");
                Console.ReadKey();
                Console.Clear();
                MainMenu.drawLogo();
                MainMenu.drawOptions();
                MainMenu.takeOrder();
            }

            // użycie znaku nieodpowiadającego żadnej opcji nic nie zmienia w programie
            else
            {
                Console.Write("\b \b");
                manageOptions();
            }
        }
    }
}