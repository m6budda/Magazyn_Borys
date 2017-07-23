using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Magazyn_Borys
{
    class Program
    {
        // deklaracje ścieżek względnych do używanych w programie plików tekstowych, danych dot. logowania, pieniędzy, koloru tła konsoli
        public static string[] path = System.IO.Directory.GetFiles("../../Items_Borys/");
        public static string[] cashPath = System.IO.Directory.GetFiles("../../Cash_Borys/");
        public static string[] groupCostSumPath = System.IO.Directory.GetFiles("../../Expenses_Borys/");
        public static string[] optionsColorPath = System.IO.Directory.GetFiles("../../Options_Borys/");
        public static bool isLogged = false;
        public static string whoIsLogged;
        public static double cash = Convert.ToDouble(File.ReadLines(cashPath[0], Encoding.GetEncoding("Windows-1250")).First());
        public static double groupCostSum = Convert.ToDouble(File.ReadLines(groupCostSumPath[0], Encoding.GetEncoding("Windows-1250")).First());
        public static string optionsColor = File.ReadLines(optionsColorPath[0], Encoding.GetEncoding("Windows-1250")).First();
        public static ConsoleColor defaultBCGColor = ConsoleColor.DarkRed;
        public static ConsoleColor defaultFontColor = ConsoleColor.Gray;
        
        static void Main(string[] args)
        {
            //ustawienie rozmiaru okna, ostatnio wybranego koloru tła konsoli, załadowanie danych z Mock (które są tam ładowane z pliku tekstowego), narysowanie menu głównego
            Console.SetWindowSize(Math.Min(100, Console.LargestWindowWidth), Math.Min(40, Console.LargestWindowHeight));
            if (optionsColor == "1")
                defaultBCGColor = ConsoleColor.DarkRed;
            else if(optionsColor == "2")
                defaultBCGColor = ConsoleColor.DarkBlue;
            else if (optionsColor == "3")
                defaultBCGColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = defaultBCGColor;
            Console.ForegroundColor = defaultFontColor;
            Console.Clear();
            Mock.ReadFromFile();
            MainMenu.drawLogo();
            MainMenu.drawOptions();
            MainMenu.takeOrder();
            Console.ReadKey();
        }
    }
}