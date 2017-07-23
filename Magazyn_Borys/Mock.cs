using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Magazyn_Borys
{
    class Mock
    {
        // zmienne dot. danych przedmiotów składowanych w magazynie, lista zawierająca wszystkie dane (stanowiąca bazę)
        public int ID                  { get; set; }
        public string Name             { get; set; }
        public string Type             { get; set; }
        public string Number           { get; set; }
        public string PaidPrice    { get; set; }
        public string Condition        { get; set; }
        public static List<Mock> ItemList = new List<Mock>();

        // wczytywanie danych z pliku tekstowego do listy stanowiącej bazę
        public static void ReadFromFile()
        {
            for (int i = 1, j = 0; j < File.ReadLines(Program.path[0]).Count(); i++, j += 6)
            {
                ItemList.Add(new Mock
                {
                    ID = i,
                    Name = File.ReadLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).Skip(j).First(),
                    Type = File.ReadLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).Skip(j + 1).First(),
                    Number = File.ReadLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).Skip(j + 2).First(),
                    PaidPrice = File.ReadLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).Skip(j + 3).First(),
                    Condition = File.ReadLines(Program.path[0], Encoding.GetEncoding("Windows-1250")).Skip(j + 4).First()
                });
            }
        }
    }
}