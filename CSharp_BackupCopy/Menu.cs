﻿using System;
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


            while (true) {

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
                    case ConsoleKey.D1 :
                    case ConsoleKey.NumPad1:
                        PrintStorage(user.GetDevices());
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddUserStorage(user);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Calculations.TotalDeviceMemory(user.GetDevices());
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Calculations.CopyingInfo(workPC, user.GetDevices());
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Calculations.CopyTime(workPC, user.GetDevices());
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
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