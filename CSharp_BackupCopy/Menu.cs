using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    static class Menu
    {
        //static Menu()
        //{

        //}

        public static void Start(User user)
        {

            ConsoleKeyInfo SymbolKey;

            do
            {
            //while (ReadKey().Key != ConsoleKey.Escape) {
                Clear();
                WriteLine(" Меню:");



                WriteLine(" 1 - Посмотреть список носителей");
                WriteLine(" 2 - Добавить носитель");
                WriteLine(" 3 - Добавить носитель");

                Write(" Ваш выбор: ");
                SymbolKey = ReadKey();
                WriteLine();

                switch (SymbolKey.Key)
                //switch (Convert.ToInt32(ReadLine()))
                {
                    case ConsoleKey.P:
                        PrintStorage(user.GetDevices());
                        break;
                    case ConsoleKey.A:
                        AddUserStorage(user);
                        break;
                    //case ConsoleKey.Escape:
                    //    return;
                    default:
                        break;
                }

                if (SymbolKey.Key != ConsoleKey.Escape)
                {
                    // Пауза
                    ReadKey();
                    Clear();
                }
                //if (SymbolKey.Key == ConsoleKey.Escape)
                //{
                //    break;
                //}

            } while (SymbolKey.Key != ConsoleKey.Escape);
                //} while (ReadKey().Key != ConsoleKey.Escape);
                //} while (ReadKey().Key != ConsoleKey.Escape);
            //}

        }

        public static void PrintStorage(Storage[] storage)
        {
            WriteLine("\n\n >>> work print storage");
        }

        public static void AddUserStorage(User user)
        {

            WriteLine(" Выберите тип носителя:");

            WriteLine(" 1 - Flash");
            WriteLine(" 2 - DVD");
            WriteLine(" 3 - HDD");

            switch(Convert.ToInt32(ReadLine()))
            {
                case 1:
                    //user.AddStorage(Flash.Add());
                    user.AddStorage(new Flash().Add());
                    break;
                case 2:
                    user.AddStorage(new Flash().Add());
                    break;
                default:
                    break;
            }

            
        }

    }
}
