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

        public static void Start(User user, WorkPC workPC)
        {

            ConsoleKeyInfo SymbolKey;

            //do
            //{
            while (true) {

                //ReadKey();
                //Clear();
                WriteLine("\n Меню:");

                WriteLine(" 1 - Посмотреть список носителей");
                WriteLine(" 2 - Добавить носитель");
                WriteLine(" 3 - Общее количество памяти всех носителей");
                WriteLine(" 4 - Копирование информации на носители");
                WriteLine(" 5 - Время необходимое для копирования");
                WriteLine(" 6 - Необходимое количество носителей");
                WriteLine(" 0 - Выход");

                Write(" Ваш выбор: ");
                SymbolKey = ReadKey();
                WriteLine();
                Design.Line();

                switch (SymbolKey.Key)
                {
                    case ConsoleKey.D1:
                        PrintStorage(user.GetDevices());
                        break;
                    case ConsoleKey.D2:
                        AddUserStorage(user);
                        break;
                    case ConsoleKey.D3:
                        Calculations.TotalDeviceMemory(user.GetDevices());
                        break;
                    case ConsoleKey.D4:
                        Calculations.CopyingInfo(workPC, user.GetDevices());
                        break;
                    case ConsoleKey.D5:
                        Calculations.CopyTime(workPC, user.GetDevices());
                        break;
                    case ConsoleKey.D6:
                        Calculations.NumberOfStorage(workPC, user.GetDevices());
                        break;
                    default:
                        break;
                }

                // Пауза
                //WriteLine("\n\n Нажмите любую клавишу для продолжения ...");
                //ReadKey();
                //Clear();

                if (SymbolKey.Key == ConsoleKey.D0 || SymbolKey.Key == ConsoleKey.Escape)
                {
                    return;
                }

                WriteLine("\n\n Нажмите любую клавишу для продолжения ...");
                ReadKey();
                Clear();

                //} while (true);
            }

        }


        public static void PrintStorage(Storage[] storage)
        {
            WriteLine("\n Список всех носителей:\n");

            if (storage.Length == 0)
            {
                WriteLine("\n --> Носителей нет.");
            }

            foreach (Storage item in storage)
            {
                item.GettingFullInformationAboutTheDevice();
                WriteLine();
            }
        }


        public static void AddUserStorage(User user)
        {
            ConsoleKeyInfo SymbolKey;

            WriteLine(" Выберите тип носителя:");

            WriteLine(" 1 - Flash");
            WriteLine(" 2 - DVD");
            WriteLine(" 3 - HDD");

            Write("\n Ваш выбор: ");
            SymbolKey = ReadKey();
            WriteLine();
            Design.Line();

            switch (SymbolKey.Key)
            {
                case ConsoleKey.D1 :
                    user.AddStorage(new Flash().Add());
                    break;
                case ConsoleKey.D2 :
                    user.AddStorage(new Flash().Add());
                    break;
                    // TODO  DVD and HDD
                default:
                    break;
            }

            
        }

    }
}
