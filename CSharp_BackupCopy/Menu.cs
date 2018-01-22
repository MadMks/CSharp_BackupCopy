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

            // Просим ввести данные о файлах на ПК.
            Write("\n Введите размер одного файла (на ПК): ");
            workPC.FileSize = Convert.ToInt32(ReadLine());
            Write(" Введите кол-во файлов (на ПК): ");
            workPC.TotalSizeOfFiles = workPC.FileSize * Convert.ToInt32(ReadLine());

            // Запуск меню.
            while (true) {

                WriteLine("\n Меню:");

                WriteLine(" 1 - Посмотреть данные о файлах на ПК");
                WriteLine(" 2 - Посмотреть список носителей");
                WriteLine(" 3 - Добавить носитель");
                WriteLine(" 4 - Общее количество памяти всех носителей");
                WriteLine(" 5 - Копирование информации на носители");
                WriteLine(" 6 - Время необходимое для копирования");
                WriteLine(" 7 - Необходимое количество носителей");
                WriteLine(" 0 - Выход");

                Write(" Ваш выбор: ");
                SymbolKey = ReadKey();
                WriteLine();
                Design.Line();

                switch (SymbolKey.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        WriteLine(workPC);
                        break;
                    case ConsoleKey.D2 :
                    case ConsoleKey.NumPad2:
                        PrintStorage(user.GetDevices());
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        AddUserStorage(user);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Calculations.TotalDeviceMemory(user.GetDevices());
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Calculations.CopyingInfo(workPC, user.GetDevices());
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Calculations.CopyTime(workPC, user.GetDevices());
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Calculations.NumberOfStorage(workPC, user.GetDevices());
                        break;
                    default:
                        break;
                }

                if (SymbolKey.Key == ConsoleKey.D0 ||
                    SymbolKey.Key == ConsoleKey.Escape ||
                    SymbolKey.Key == ConsoleKey.NumPad0)
                {
                    return;
                }

                WriteLine("\n\n Нажмите любую клавишу для продолжения ...");
                ReadKey();
                Clear();

            }

        }



        public static void PrintStorage(Storage[] storage)
        {
            WriteLine("\n Список всех носителей:\n");

            if (storage.Length == 0)
            {
                Design.Blue();
                WriteLine("\n --> Носителей нет.");
                Design.Default();
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
                case ConsoleKey.NumPad1 :
                    user.AddStorage(new Flash().Add());
                    break;
                case ConsoleKey.D2 :
                case ConsoleKey.NumPad2 :
                    user.AddStorage(new DVD().Add());
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    user.AddStorage(new HDD().Add());
                    break;
                default:
                    Design.Red();
                    WriteLine("\n [err] Недопустимый тип носителя.");
                    Design.Default();
                    break;
            }  
        }



    }
}