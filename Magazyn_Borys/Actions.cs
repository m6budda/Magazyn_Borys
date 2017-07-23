using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_Borys
{
    // klasa astrakcyjna, po której dziedziczą 2 klasy: klasa akcji zalogowanego użytkownika oraz klasa akcji niezalogowanego gościa
    abstract class Actions
    {
        public abstract void EnterContent();
        public abstract void ShowStatistics();
    }
}