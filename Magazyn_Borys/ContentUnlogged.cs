using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_Borys
{
    // klasa akcji niezalogowanego gościa
    class ContentUnlogged : Actions
    {
        // odmowa dostępu do przeglądu magazynu
        public override void EnterContent()
        {
            Console.Clear();
            MainMenu.drawLogo();
            Console.Write("\n\n\n");
            MainMenu.textCentering("Nie masz uprawnień do przeglądania danych magazynu!");
            Console.ReadKey();
            Console.Clear();
            MainMenu.drawLogo();
            MainMenu.drawOptions();
            MainMenu.takeOrder();
        }

        // odmowa dostępu do przeglądu statystyk
        public override void ShowStatistics()
        {
            Console.Clear();
            MainMenu.drawLogo();
            Console.Write("\n\n\n");
            MainMenu.textCentering("Nie masz uprawnień do przeglądania statystyk magazynu!");
            Console.ReadKey();
            Console.Clear();
            MainMenu.drawLogo();
            MainMenu.drawOptions();
            MainMenu.takeOrder();
        }
    }
}