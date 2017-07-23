using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn_Borys
{
    class User
    {
        // zmienne dot. danych logowania
        public int ID          { get; set; }
        public string Login    { get; set; }
        public string Password { get; set; }

        // stała, niezmienna lista 3 użytkowników, którzy mogą użytkować program
        public static List<User> UserList = new List<User>()
        {
            new User{ID = 1, Login = "PMazep", Password = "admin1" },
            new User{ID = 2, Login = "Konfucjusz", Password = "admin2" },
            new User{ID = 3, Login = "Bonifacy", Password = "admin3" }
        };
    }
}