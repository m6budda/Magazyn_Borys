using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Magazyn_Borys
{
    // klasa akcji zalogowanego użytkownika
    class ContentLogged : Actions
    {
        // zmienna pobierająca wybór jednego z dostępnych poleceń
        static char manageNumber;

        // ustawienie rozmiaru okna, wyświetlenie na ekranie wszystkich danych zawartych w Mock
        public override void EnterContent()
        {
            Console.Clear();
            Console.SetWindowSize(Math.Min(100, Console.LargestWindowWidth), Math.Min(55, Console.LargestWindowHeight));
            MainMenu.drawLogo();
            Console.Write("\n\n\n");
            if(File.ReadLines(Program.path[0]).Count() != 0)
            {
                foreach (Mock item in Mock.ItemList)
                {
                    string sumPaidFor1;
                    int number = Convert.ToInt32(item.Number);
                    if(number != 0)
                        sumPaidFor1 = Convert.ToString(Convert.ToDouble(item.PaidPrice) / number);
                    else
                        sumPaidFor1 = "Niezdefiniowano";
                    Console.WriteLine($"  ID:                  {item.ID}");
                    Console.WriteLine($"  Nazwa:               {item.Name}");
                    Console.WriteLine($"  Typ:                 {item.Type}");
                    Console.Write("  Sztuk:               ");
                    if (number <= 3)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (number <= 15)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{item.Number}");
                    Console.ForegroundColor = Program.defaultFontColor;
                    Console.WriteLine($"  W sumie zapłacono:   {Math.Round((Convert.ToDouble(item.PaidPrice) * 100)) / 100}zł");
                    if(number != 0)
                        Console.WriteLine($"  Cena za sztukę:      {Math.Round((Convert.ToDouble(sumPaidFor1) * 100)) / 100}zł");
                    else
                        Console.WriteLine($"  Cena za sztukę:      {sumPaidFor1}");
                    Console.Write("  Stan:                ");
                    if (item.Condition == "Sprawne")
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (item.Condition == "Niesprawne")
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{item.Condition}");
                    Console.ForegroundColor = Program.defaultFontColor;
                    Console.WriteLine("\n");
                }
            }
            else
                MainMenu.textCentering("Magazyn jest pusty!\n\n\n\n");
            MainMenu.textCentering("1 - Dodaj grupę przedmiotów\n\n");
            MainMenu.textCentering("2 - Usuń grupę przedmiotów  \n\n");
            MainMenu.textCentering("     3 - Dodaj/usuń przedmioty z grupy\n\n");
            MainMenu.textCentering("     4 - Zmień nazwę grupy przedmiotów\n\n");
            MainMenu.textCentering("    5 - Zmień stan grupy przedmiotów\n\n");
            MainMenu.textCentering("6 - Wróć do menu głównego    \n");
            MainMenu.textCentering("\n\n\n\n");
            MainMenu.textToRight("Zalogowany magazynier:\n");
            MainMenu.textToRight(Program.whoIsLogged);
            MainMenu.textCentering("\n");
            manageItems();
        }

        // pobiera wybór odpowiedniej opcji dot. manipulacji danymi, wybiera odpowiadającą jej akcję
        public static void manageItems()
        {
            Actions loggedAction = new ContentLogged();
            manageNumber = Console.ReadKey().KeyChar;

            // dodaje grupę przedmiotów
            if (manageNumber == '1')
            {
                Console.Clear();
                MainMenu.drawLogo();
                MainMenu.textCentering("\n\n\n");
                Console.WriteLine("        (n -> cofnij do przeglądu): ");
                Console.WriteLine();
                Console.Write("        Podaj nazwę nowej grupy przedmiotów:                     ");
                string newName = Console.ReadLine();
                if (newName == "n")
                {
                    loggedAction.EnterContent();
                }
                Console.WriteLine();
                Console.Write("        Podaj typ nowej grupy przedmiotów:                       ");
                string newType = Console.ReadLine();
                if (newType == "n")
                {
                    loggedAction.EnterContent();
                }
                Console.WriteLine();
                Console.Write("        Podaj liczbę przedmiotów w nowej grupie:                ");
                string newNumber = " ";
                for (int i = 0; i < 1; i++)
                {
                    Console.Clear();
                    MainMenu.drawLogo();
                    MainMenu.textCentering("\n\n\n");
                    Console.WriteLine("        (n -> cofnij do przeglądu): ");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj nazwę nowej grupy przedmiotów:                     {newName}");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj typ nowej grupy przedmiotów:                       {newType}");
                    Console.WriteLine();
                    Console.Write($"        Podaj liczbę przedmiotów w nowej grupie:                 ");
                    newNumber = Console.ReadLine();
                    if (newNumber == "n")
                    {
                        loggedAction.EnterContent();
                    }
                    if (int.TryParse(newNumber, out int parseResult) != true || parseResult <= 0)
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Błąd! Wpisz liczbę całkowitą dodatnią!");
                        Console.ReadKey();
                        i--;
                    }
                }
                Console.WriteLine();
                Console.Write("         Podaj cenę zakupu jednego przedmiotu z nowej grupy [zł]:             ");
                string newPaidPriceFor1 = " ";
                string newPaidPrice = "";
                for (int i = 0; i < 1; i++)
                {
                    Console.Clear();
                    MainMenu.drawLogo();
                    MainMenu.textCentering("\n\n\n");
                    Console.WriteLine("        (n -> cofnij do przeglądu): ");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj nazwę nowej grupy przedmiotów:                     {newName}");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj typ nowej grupy przedmiotów:                       {newType}");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj liczbę przedmiotów w nowej grupie:                 {newNumber}");
                    Console.WriteLine();
                    Console.Write($"        Podaj cenę zakupu jednego przedmiotu z nowej grupy [zł]: ");
                    newPaidPriceFor1 = Console.ReadLine();
                    if (newPaidPriceFor1 == "n")
                    {
                        loggedAction.EnterContent();
                    }
                    if (Double.TryParse(newPaidPriceFor1, out double parseResult) != true || parseResult < 0)
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Błąd! Wpisz liczbę zmiennoprzecinkową nieujemną!");
                        Console.ReadKey(); 
                        i--;
                    }
                    else
                    {
                        newPaidPrice = Convert.ToString(Convert.ToDouble(newPaidPriceFor1) * Convert.ToInt32(newNumber));
                        if (Convert.ToDouble(Program.cash) - Convert.ToDouble(newPaidPrice) < 0)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("Brak wystarczającej ilości środków, by zapłacić!");
                            Console.ReadKey();
                            i--;
                        }
                    }                   
                }
                string newCondition = " ";
                for (int i = 0; i < 1; i++)
                {
                    Console.Clear();
                    MainMenu.drawLogo();
                    MainMenu.textCentering("\n\n\n");
                    Console.WriteLine("        (n -> cofnij do przeglądu): ");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj nazwę nowej grupy przedmiotów:                     {newName}");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj typ nowej grupy przedmiotów:                       {newType}");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj liczbę przedmiotów w nowej grupie:                 {newNumber}");
                    Console.WriteLine();
                    Console.WriteLine($"        Podaj cenę zakupu jednego przedmiotu z nowej grupy [zł]: {newPaidPriceFor1}");
                    Console.WriteLine();
                    Console.Write($"        Podaj stan techniczny nowej grupy (sprawne/niesprawne):  ");
                    newCondition = Console.ReadLine();
                    if (newCondition == "n")
                    {
                        loggedAction.EnterContent();
                    }
                    if (newCondition != "sprawne" && newCondition != "niesprawne")
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Błąd! Wpisz słowo 'sprawne' lub 'niesprawne'!");
                        Console.ReadKey();
                        i--;
                    }
                    else if (newCondition == "sprawne")
                        newCondition = "Sprawne";
                    else if (newCondition == "niesprawne")
                        newCondition = "Niesprawne";
                }

                // dodanie utworzonej nowej grupy przedmiotów do pliku tekstowego danych przedmiotów
                List<string> newItemsData = new List<string>();
                if (File.ReadLines(Program.path[0]).Count() != 0)
                {
                    removeLastChar();
                    removeLastChar();
                    newItemsData.Add("");
                }
                newItemsData.Add(newName);
                newItemsData.Add(newType);
                newItemsData.Add(newNumber);
                newItemsData.Add(newPaidPrice);
                newItemsData.Add(newCondition);
                newItemsData.Add(" ");
                File.AppendAllLines(Program.path[0], newItemsData, Encoding.GetEncoding("Windows-1250"));
                removeLastChar();

                // operacje dot. salda konta i wydatków
                Program.cash -= Convert.ToDouble(newPaidPrice);
                File.Delete(Program.cashPath[0]);
                File.WriteAllText(Program.cashPath[0], Convert.ToString(Program.cash), Encoding.GetEncoding("Windows-1250"));
                Program.groupCostSum += Convert.ToDouble(newPaidPrice);
                File.Delete(Program.groupCostSumPath[0]);
                File.WriteAllText(Program.groupCostSumPath[0], Convert.ToString(Program.groupCostSum), Encoding.GetEncoding("Windows-1250"));

                MainMenu.textCentering($"\n");
                MainMenu.textCentering($"Dodanie nowej grupy przedmiotów zakończone powodzeniem!");
                Console.ReadKey();
                Mock.ItemList.Clear();
                Mock.ReadFromFile();
                loggedAction.EnterContent();
            }

            // usuwa grupę przedmiotów
            if (manageNumber == '2')
            {
                for (int i = 0; i < 1; i++)
                {
                    bool doesIDExist = false;
                    string typedID = "";
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Clear();
                        MainMenu.drawLogo();
                        MainMenu.textCentering("\n\n\n");
                        Console.WriteLine("                (n -> cofnij do przeglądu): ");
                        Console.WriteLine();
                        Console.Write("                Podaj ID grupy przedmiotów, którą chcesz usunąć/sprzedać:              ");
                        typedID = Console.ReadLine();
                        if (typedID == "n")
                        {
                            loggedAction.EnterContent();
                        }
                        if (int.TryParse(typedID, out int typedIDtoInt) != true)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                        else if(Convert.ToInt32(typedID) <= 0)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                    }                   
                    int selectedID = Convert.ToInt32(typedID);
                    if (Mock.ItemList.Exists(x => x.ID == selectedID))
                    {
                        doesIDExist = true;
                    }
                    if (doesIDExist == true)
                    {
                        string earnedCostPer1 = "";
                        for (int j = 0; j < 1; j++)
                        {
                            Console.Clear();
                            MainMenu.drawLogo();
                            MainMenu.textCentering("\n\n\n");
                            Console.WriteLine("                (n -> cofnij do przeglądu): ");
                            Console.WriteLine();
                            Console.Write($"                Podaj ID grupy przedmiotów, którą chcesz usunąć/sprzedać:              {typedID}\n");
                            Console.WriteLine();
                            Console.Write("                Wpisz zarobek jednostkowy (na 1 sztuce) po usunięciu grupy [zł]:       ");
                            earnedCostPer1 = Console.ReadLine();
                            if (earnedCostPer1 == "n")
                            {
                                loggedAction.EnterContent();
                            }
                            if (double.TryParse(earnedCostPer1, out double earnedCostPer1toDouble) != true)
                            {
                                MainMenu.textCentering("\n");
                                MainMenu.textCentering("Należy wpisać liczbę zmiennoprzecinkową nieujemną!");
                                Console.ReadKey();
                                j--;
                            }
                            else if (Convert.ToDouble(earnedCostPer1) < 0)
                            {
                                MainMenu.textCentering("\n");
                                MainMenu.textCentering("Należy wpisać liczbę zmiennoprzecinkową nieujemną!");
                                Console.ReadKey();
                                j--;
                            }
                        }

                        // usunięcie grupy przedmiotów z pliku tekstowego danych przedmiotów
                        List<string> fileLines = File.ReadAllLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).ToList();
                        for (int j = 0; j <= 5; j++)
                        {
                            fileLines.RemoveAt((selectedID - 1) * 6);
                        }
                        if (fileLines.Count != 0)
                        {
                            fileLines.RemoveAt(fileLines.Count() - 1);
                            fileLines.Add(" ");
                        }
                        File.Delete(Program.path[0]);
                        File.WriteAllLines(Program.path[0], fileLines, Encoding.GetEncoding("Windows-1250"));
                        if (fileLines.Count != 0)
                        {
                            removeLastChar();
                        }

                        // operacje dot. salda konta
                        Program.cash += Convert.ToDouble(earnedCostPer1) * Convert.ToDouble(Mock.ItemList[selectedID - 1].Number);
                        File.Delete(Program.cashPath[0]);
                        File.WriteAllText(Program.cashPath[0], Convert.ToString(Program.cash), Encoding.GetEncoding("Windows-1250"));

                        MainMenu.textCentering("\n");
                        MainMenu.textCentering($"Usunięto grupę przedmiotów o ID = {selectedID}!");
                        Console.ReadKey();
                        Mock.ItemList.Clear();
                        Mock.ReadFromFile();
                        loggedAction.EnterContent();
                    }
                    else
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Brak pozycji o podanym ID!");
                        Console.ReadKey();
                        i--;
                    }
                }
            }

            // dodaje/usuwa przedmioty z grupy
            if (manageNumber == '3')
            {
                for(int i = 0; i < 1; i++)
                {
                    string typedID = "";
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Clear();
                        MainMenu.drawLogo();
                        MainMenu.textCentering("\n\n\n");
                        Console.WriteLine("                (n -> cofnij do przeglądu): ");
                        Console.WriteLine();
                        Console.Write("                Podaj ID grupy przedmiotów, która uległa zmianie:             ");
                        typedID = Console.ReadLine();
                        if (typedID == "n")
                        {
                            loggedAction.EnterContent();
                        }
                        if (int.TryParse(typedID, out int typedIDtoInt) != true)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                        else if (Convert.ToInt32(typedID) <= 0)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                    }
                    bool doesIDExist = false;
                    int selectedID = Convert.ToInt32(typedID);
                    if (Mock.ItemList.Exists(x => x.ID == selectedID))
                    {
                        doesIDExist = true;
                    }
                    if (doesIDExist == true)
                    {
                        string typedIncrease = "";
                        for (int j = 0; j < 1; j++)
                        {
                            Console.Clear();
                            MainMenu.drawLogo();
                            MainMenu.textCentering("\n\n\n");
                            Console.WriteLine("                (n -> cofnij do przeglądu): ");
                            Console.WriteLine();
                            Console.Write($"                Podaj ID grupy przedmiotów, która uległa zmianie:             {selectedID}\n");
                            Console.WriteLine();
                            Console.WriteLine("                Podaj, ile przedmiotów dodano/usunięto.");
                            Console.Write("                Jeśli liczba się zmniejszyła, użyj znaku minus:               ");
                            typedIncrease = Console.ReadLine();
                            if (typedIncrease == "n")
                            {
                                loggedAction.EnterContent();
                            }
                            if (int.TryParse(typedIncrease, out int typedIncreasetoInt) != true)
                            {
                                MainMenu.textCentering("\n");
                                MainMenu.textCentering("Błąd! Wpisz liczbę całkowitą!");
                                Console.ReadKey();
                                j--;
                            }
                            else if (Convert.ToInt32(typedIncrease) + Convert.ToInt32(Mock.ItemList[selectedID - 1].Number) < 0)
                            {
                                MainMenu.textCentering("Błąd! Liczba przedmiotów w grupie musi być większa lub równa 0!");
                                Console.ReadKey();
                                j--;
                            }
                        }
                        string newElementCost1 = "";
                        double newElementCost = 0;
                        for (int j = 0; j < 1; j++)
                        {
                            Console.Clear();
                            MainMenu.drawLogo();
                            MainMenu.textCentering("\n\n\n");
                            Console.WriteLine("                (n -> cofnij do przeglądu): ");
                            Console.WriteLine();
                            Console.Write($"                Podaj ID grupy przedmiotów, która uległa zmianie:             {selectedID}\n");
                            Console.WriteLine();
                            Console.WriteLine("                Podaj, ile przedmiotów dodano/usunięto.");
                            Console.Write($"                Jeśli liczba się zmniejszyła, użyj znaku minus:               {typedIncrease}\n");
                            Console.WriteLine();
                            Console.Write("                Wpisz, ile kosztuje każda dodana/usunięta sztuka [zł]:        ");
                            newElementCost1 = Console.ReadLine();
                            if (newElementCost1 == "n")
                            {
                                loggedAction.EnterContent();
                            }
                            if (double.TryParse(newElementCost1, out double newElementCost1toDouble) != true)
                            {
                                MainMenu.textCentering("\n");
                                MainMenu.textCentering("Błąd! Wpisz liczbę zmiennoprzecinkową nieujemną!");
                                Console.ReadKey();
                                j--;
                            }
                            else if (Convert.ToDouble(newElementCost1) < 0)
                            {
                                MainMenu.textCentering("\n");
                                MainMenu.textCentering("Błąd! Wpisz liczbę zmiennoprzecinkową nieujemną!");
                                Console.ReadKey();
                                j--;
                            }
                            else
                            {
                                newElementCost = Convert.ToDouble(newElementCost1);
                                if (Program.cash - Convert.ToDouble(typedIncrease) * newElementCost < 0)
                                {
                                    MainMenu.textCentering("\n");
                                    MainMenu.textCentering("Brak wystarczającej ilości środków, by zapłacić!");
                                    Console.ReadKey();
                                    j--;
                                }
                            }                           
                        }

                        // modyfikacja pliku tekstowego danych przedmiotów, dot. zmiany liczby przedmiotów określonej grupy + zmiany kosztów całkowitych za grupę
                        List<string> allLines = File.ReadAllLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).ToList();
                        allLines.RemoveAt(selectedID * 6 - 4);
                        string additionResult = Convert.ToString(Convert.ToInt32(Mock.ItemList[selectedID - 1].Number) + Convert.ToInt32(typedIncrease));
                        allLines.Insert(selectedID * 6 - 4, additionResult);
                        allLines.RemoveAt(selectedID * 6 - 3);
                        string allGroupCost = Convert.ToString(Convert.ToDouble(Mock.ItemList[selectedID - 1].PaidPrice) + Convert.ToDouble(typedIncrease) * newElementCost);
                        allLines.Insert(selectedID * 6 - 3, allGroupCost);
                        File.Delete(Program.path[0]);
                        File.WriteAllLines(Program.path[0], allLines, Encoding.GetEncoding("Windows-1250"));
                        removeLastChar();

                        // operacje dot. salda konta i wydatków
                        double cashBefore = Program.cash;
                        Program.cash -= Convert.ToDouble(typedIncrease) * newElementCost;
                        File.Delete(Program.cashPath[0]);
                        File.WriteAllText(Program.cashPath[0], Convert.ToString(Program.cash), Encoding.GetEncoding("Windows-1250"));
                        if(Program.cash < cashBefore)
                        {
                            Program.groupCostSum += Convert.ToDouble(typedIncrease) * newElementCost;
                            File.Delete(Program.groupCostSumPath[0]);
                            File.WriteAllText(Program.groupCostSumPath[0], Convert.ToString(Program.groupCostSum), Encoding.GetEncoding("Windows-1250"));
                        }

                        MainMenu.textCentering("\n");
                        MainMenu.textCentering($"Zmieniono liczbę przedmiotów w grupie o ID = {selectedID}!");
                        Console.ReadKey();
                        Mock.ItemList.Clear();
                        Mock.ReadFromFile();
                        loggedAction.EnterContent();
                    }
                    else
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Brak pozycji o podanym ID!");
                        Console.ReadKey();
                        i--;
                    }
                }
            }

            // zmienia nazwę grupy przedmiotów
            if(manageNumber == '4')
            {
                for (int i = 0; i < 1; i++)
                {
                    string typedID = "";
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Clear();
                        MainMenu.drawLogo();
                        MainMenu.textCentering("\n\n\n");
                        Console.WriteLine("                (n -> cofnij do przeglądu): ");
                        Console.WriteLine();
                        Console.Write("                Podaj ID grupy przedmiotów, której nazwę chcesz zmienić:    ");
                        typedID = Console.ReadLine();
                        if (typedID == "n")
                        {
                            loggedAction.EnterContent();
                        }
                        if (int.TryParse(typedID, out int typedIDtoInt) != true)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                        else if (Convert.ToInt32(typedID) <= 0)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                    }                    
                    bool doesIDExist = false;
                    int selectedID = Convert.ToInt32(typedID);
                    if (Mock.ItemList.Exists(x => x.ID == selectedID))
                    {
                        doesIDExist = true;
                    }
                    if (doesIDExist == true)
                    {
                        Console.WriteLine();
                        Console.Write("                Podaj nową nazwę:                                           ");
                        string typedNewName = Console.ReadLine();
                        if (typedNewName == "n")
                        {
                            loggedAction.EnterContent();
                        }

                        // modyfikacja pliku tekstowego danych przedmiotów, dot. zmiany nazwy grupy przedmiotów
                        List<string> allLines = File.ReadAllLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).ToList();
                        allLines.RemoveAt(selectedID * 6 - 6);
                        allLines.Insert(selectedID * 6 - 6, typedNewName);
                        File.Delete(Program.path[0]);
                        File.WriteAllLines(Program.path[0], allLines, Encoding.GetEncoding("Windows-1250"));
                        removeLastChar();

                        MainMenu.textCentering("\n");
                        MainMenu.textCentering($"Zmieniono nazwę grupy przedmiotów o ID = {selectedID}!");
                        Console.ReadKey();
                        Mock.ItemList.Clear();
                        Mock.ReadFromFile();
                        loggedAction.EnterContent();
                    }
                    else
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Brak pozycji o podanym ID!");
                        Console.ReadKey();
                        i--;
                    }
                }
            }

            // zmienia stan grupy przedmiotów
            if (manageNumber == '5')
            {
                for (int i = 0; i < 1; i++)
                {
                    string typedID = "";
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Clear();
                        MainMenu.drawLogo();
                        MainMenu.textCentering("\n\n\n");
                        Console.WriteLine("                (n -> cofnij do przeglądu): ");
                        Console.WriteLine();
                        Console.Write("                Podaj ID grupy przedmiotów, której stan techniczny chcesz zmienić:         ");
                        typedID = Console.ReadLine();
                        if (typedID == "n")
                        {
                            loggedAction.EnterContent();
                        }
                        if (int.TryParse(typedID, out int typedIDtoInt) != true)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                        else if (Convert.ToInt32(typedID) <= 0)
                        {
                            MainMenu.textCentering("\n");
                            MainMenu.textCentering("ID jest liczbą naturalną!");
                            Console.ReadKey();
                            j--;
                        }
                    }
                    bool doesIDExist = false;
                    int selectedID = Convert.ToInt32(typedID);
                    if (Mock.ItemList.Exists(x => x.ID == selectedID))
                    {
                        doesIDExist = true;
                    }
                    if (doesIDExist == true)
                    {
                        string repairCostPer1 = "";
                        List<string> allLines = new List<string>();
                        if (Mock.ItemList[selectedID - 1].Condition == "Niesprawne")
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                Console.Clear();
                                MainMenu.drawLogo();
                                MainMenu.textCentering("\n\n\n");
                                Console.WriteLine("                (n -> cofnij do przeglądu): ");
                                Console.WriteLine();
                                Console.Write($"                Podaj ID grupy przedmiotów, której stan techniczny chcesz zmienić:         {selectedID}\n");
                                Console.WriteLine();
                                Console.Write("                Zmiana grupy na stan sprawny - ile to kosztuje dla 1 sztuki? [zł]:         ");
                                repairCostPer1 = Console.ReadLine();
                                if (repairCostPer1 == "n")
                                {
                                    loggedAction.EnterContent();
                                }
                                if (double.TryParse(repairCostPer1, out double repairCocsPer1toDouble) != true)
                                {
                                    MainMenu.textCentering("\n");
                                    MainMenu.textCentering("Błąd! Wpisz liczbę zmiennoprzecinkową nieujemną!");
                                    Console.ReadKey();
                                    j--;
                                }
                                else if (Convert.ToDouble(repairCostPer1) < 0)
                                {
                                    MainMenu.textCentering("\n");
                                    MainMenu.textCentering("Błąd! Wpisz liczbę zmiennoprzecinkową nieujemną!");
                                    Console.ReadKey();
                                    j--;
                                }
                                else
                                {
                                    if (Program.cash - Convert.ToDouble(repairCostPer1) * Convert.ToDouble(Mock.ItemList[selectedID - 1].Number) < 0)
                                    {
                                        MainMenu.textCentering("\n");
                                        MainMenu.textCentering("Brak wystarczającej ilości środków, by zapłacić!");
                                        Console.ReadKey();
                                        j--;
                                    }
                                }                          
                            }

                            // wstęp modyfikacji pliku tekstowego danych przedmiotów, dot. zmiany stanu grupy przedmiotów na 'Sprawne' + zmiany kosztów całkowitych za grupę
                            allLines = File.ReadAllLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).ToList();
                            allLines.RemoveAt(selectedID * 6 - 2);
                            allLines.Insert(selectedID * 6 - 2, "Sprawne");
                            allLines.RemoveAt(selectedID * 6 - 3);
                            allLines.Insert(selectedID * 6 - 3, Convert.ToString(Convert.ToDouble(Mock.ItemList[selectedID - 1].PaidPrice) + 
                            Convert.ToDouble(repairCostPer1) * Convert.ToDouble(Mock.ItemList[selectedID - 1].Number)));
                        }
                        else if (Mock.ItemList[selectedID -1].Condition == "Sprawne")
                        {
                            repairCostPer1 = "0";

                            // wstęp modyfikacji pliku tekstowego danych przedmiotów, dot. zmiany stanu grupy przedmiotów na 'Niesprawne'
                            allLines = File.ReadAllLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).ToList();
                            allLines.RemoveAt(selectedID * 6 - 2);
                            allLines.Insert(selectedID * 6 - 2, "Niesprawne");
                        }

                        // rzeczywista modyfikacja pliku tekstowego danych przedmiotów, dot. zmiany stanu grupy przedmiotów + ew. zmiany kosztów całkowitych za grupę
                        File.Delete(Program.path[0]);
                        File.WriteAllLines(Program.path[0], allLines, Encoding.GetEncoding("Windows-1250"));
                        removeLastChar();

                        // operacje dot. salda konta i wydatków
                        Program.cash -= Convert.ToDouble(repairCostPer1) * Convert.ToDouble(Mock.ItemList[selectedID - 1].Number);
                        File.Delete(Program.cashPath[0]);
                        File.WriteAllText(Program.cashPath[0], Convert.ToString(Program.cash), Encoding.GetEncoding("Windows-1250"));
                        Program.groupCostSum += Convert.ToDouble(repairCostPer1) * Convert.ToDouble(Mock.ItemList[selectedID - 1].Number);
                        File.Delete(Program.groupCostSumPath[0]);
                        File.WriteAllText(Program.groupCostSumPath[0], Convert.ToString(Program.groupCostSum), Encoding.GetEncoding("Windows-1250"));

                        MainMenu.textCentering("\n");
                        MainMenu.textCentering($"Zmieniono stan techniczny grupy przedmiotów o ID = {selectedID}!");
                        Console.ReadKey();
                        Mock.ItemList.Clear();
                        Mock.ReadFromFile();
                        loggedAction.EnterContent();
                    }
                    else
                    {
                        MainMenu.textCentering("\n");
                        MainMenu.textCentering("Brak pozycji o podanym ID!");
                        Console.ReadKey();
                        i--;
                    }
                }
            }

            // ustawia rozmiar okna, wraca do menu głównego programu
            if (manageNumber == '6')
            {
                Console.Clear();
                Console.SetWindowSize(Math.Min(100, Console.LargestWindowWidth), Math.Min(40, Console.LargestWindowHeight));
                MainMenu.drawLogo();
                MainMenu.drawOptions();
                MainMenu.takeOrder();
            }

            // użycie znaku nieodpowiadającego żadnej opcji nic nie zmienia w programie
            else
            {
                Console.Write("\b \b");
                manageItems();
            }
        }

        // ustawienie rozmiaru okna, wyświetlenie menu statystyk dot. całego magazynu
        public override void ShowStatistics()
        {
            Console.Clear();
            Console.SetWindowSize(Math.Min(100, Console.LargestWindowWidth), Math.Min(55, Console.LargestWindowHeight));
            MainMenu.drawLogo();
            Console.Write("\n\n\n");
            MainMenu.textCentering("Statystyki magazynu: \n\n");
            Console.WriteLine($"          Liczba grup przedmiotów:          {Mock.ItemList.Count()}\n");
            int allItemsSum = 0;
            List<int> allItemsInOneGroup = new List<int>();
            List<double> groupCostPer1 = new List<double>();
            List<double> groupCost = new List<double>();
            int allGoodItemsSum = 0;
            int allBadItemsSum = 0;
            for (int i = 0; i < Mock.ItemList.Count(); i++)
            {
                allItemsSum += Convert.ToInt32(Mock.ItemList[i].Number);
                allItemsInOneGroup.Add(Convert.ToInt32(Mock.ItemList[i].Number));
                groupCostPer1.Add(Convert.ToDouble(Convert.ToDouble(Mock.ItemList[i].PaidPrice) / Convert.ToDouble(Mock.ItemList[i].Number)));
                groupCost.Add(Convert.ToDouble(Mock.ItemList[i].PaidPrice));
                if (Mock.ItemList[i].Condition == "Sprawne")
                {
                    allGoodItemsSum += Convert.ToInt32(Mock.ItemList[i].Number);
                }
                else if (Mock.ItemList[i].Condition == "Niesprawne")
                {
                    allBadItemsSum += Convert.ToInt32(Mock.ItemList[i].Number);
                }
            }
            Console.WriteLine($"          Całkowita liczba przedmiotów:     {allItemsSum}\n");
            int indexOfMaxVal = allItemsInOneGroup.FindIndex(x => x == allItemsInOneGroup.Max());
            int indexOfMinVal = allItemsInOneGroup.FindIndex(x => x == allItemsInOneGroup.Min());
            if(Mock.ItemList.Exists(x => x.ID == 1))
            {
                Console.WriteLine($"          Największa grupa przedmiotów:     {Mock.ItemList[indexOfMaxVal].Name};  liczba:  {allItemsInOneGroup.Max()}\n");
                Console.WriteLine($"          Najmniejsza grupa przedmiotów:    {Mock.ItemList[indexOfMinVal].Name};  liczba:  {allItemsInOneGroup.Min()}\n");
            }
            else
            {
                Console.WriteLine($"          Największa grupa przedmiotów:     BRAK;  liczba:  BRAK\n");
                Console.WriteLine($"          Najmniejsza grupa przedmiotów:    BRAK;  liczba:  BRAK\n");
            }
            Console.WriteLine($"          Liczba sprawnych przedmiotów:     {allGoodItemsSum}\n");
            Console.WriteLine($"          Liczba niesprawnych przedmiotów:  {allBadItemsSum}\n");
            if (Mock.ItemList.Exists(x => x.ID == 1))
                Console.WriteLine($"          Procent sprawnych przedmiotów:    {Math.Round(((allGoodItemsSum / (double)(allItemsSum)) * 100) * 10) / 10}%\n");
            else
                Console.WriteLine($"          Procent sprawnych przedmiotów:    BRAK DANYCH\n");
            int indexOfMaxCostPer1 = groupCostPer1.FindIndex(x => x == groupCostPer1.Max());
            int indexOfMinCostPer1 = groupCostPer1.FindIndex(x => x == groupCostPer1.Min());
            int indexOfMaxCost = groupCost.FindIndex(x => x == groupCost.Max());
            int indexOfMinCost = groupCost.FindIndex(x => x == groupCost.Min());
            if (Mock.ItemList.Exists(x => x.ID == 1))
            {
                Console.WriteLine($"          Grupa najdroższa na sztuce:       {Mock.ItemList[indexOfMaxCostPer1].Name};  koszt:  {Math.Round((groupCostPer1.Max() * 100)) / 100}zł/szt.\n");
                Console.WriteLine($"          Grupa najtańsza na sztuce:        {Mock.ItemList[indexOfMinCostPer1].Name};  koszt:  {Math.Round((groupCostPer1.Min() * 100)) / 100}zł/szt.\n");
                Console.WriteLine($"          Grupa najdroższa w ogóle:         {Mock.ItemList[indexOfMaxCost].Name};  koszt:  {Math.Round((groupCost.Max() * 100)) / 100}zł\n");
                Console.WriteLine($"          Grupa najtańsza w ogóle:          {Mock.ItemList[indexOfMinCost].Name};  koszt:  {Math.Round((groupCost.Min() * 100)) / 100}zł\n");
            }
            else
            {
                Console.WriteLine($"          Grupa najdroższa na sztuce:       BRAK;  koszt:  BRAK\n");
                Console.WriteLine($"          Grupa najtańsza na sztuce:        BRAK;  koszt:  BRAK\n");
                Console.WriteLine($"          Grupa najdroższa w ogóle:         BRAK;  koszt:  BRAK\n");
                Console.WriteLine($"          Grupa najtańsza w ogóle:          BRAK;  koszt:  BRAK\n");
            }
            Console.WriteLine($"          Saldo konta:                      {Math.Round((Program.cash * 100)) / 100}zł\n");
            Console.WriteLine($"          Suma wydatków:                    {Math.Round((Convert.ToDouble(Program.groupCostSum) * 100)) / 100}zł\n");
            Console.WriteLine($"          Suma wpływów:                     {Math.Round(((Convert.ToDouble(Program.cash) + Convert.ToDouble(Program.groupCostSum)) * 100)) / 100}zł\n");
            MainMenu.textCentering("\n\n");
            MainMenu.textCentering("1 - Wróć do menu głównego\n");
            MainMenu.textCentering("\n\n\n\n");
            MainMenu.textToRight("Zalogowany magazynier:\n");
            MainMenu.textToRight(Program.whoIsLogged);
            MainMenu.textCentering("\n");
            manageStatistics();
        }

        // pobiera wybór odpowiedniej opcji w menu statystyk (jedynie możliwość powrotu do menu głównego), wybiera odpowiadającą jej akcję (zmiana rozmiaru okna, powrót do menu)
        public static void manageStatistics()
        {
            manageNumber = Console.ReadKey().KeyChar;
            if (manageNumber == '1')
            {
                Console.Clear();
                Console.SetWindowSize(Math.Min(100, Console.LargestWindowWidth), Math.Min(40, Console.LargestWindowHeight));
                MainMenu.drawLogo();
                MainMenu.drawOptions();
                MainMenu.takeOrder();
            }

            // użycie znaku nieodpowiadającego żadnej opcji nic nie zmienia w programie
            else
            {
                Console.Write("\b \b");
                manageStatistics();
            }
        }

        // usuwa ostatni znak z pliku tekstowego dot. danych przedmiotów
        public static void removeLastChar()
        {
            string allText = File.ReadAllText(Program.path[0], Encoding.GetEncoding("Windows-1250"));
            string removeLastChar = allText.Substring(0, allText.Length - 1);
            File.Delete(Program.path[0]);
            File.WriteAllText(Program.path[0], removeLastChar, Encoding.GetEncoding("Windows-1250"));
        }
    }
}