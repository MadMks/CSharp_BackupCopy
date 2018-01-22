﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    static class Calculations
    {



        // Расчет общего количества памяти всех устройств.
        public static void TotalDeviceMemory(Storage[] storage)
        {
            double totalMemory = 0;

            foreach (Storage item in storage)
            {
                totalMemory += item.GettingTheAmountOfMemory();
            }

            Write(" Общее кол-во памяти всех устройств: ");
            WriteLine(totalMemory + " Gb\n");
        }



        // Копирование информации на устройства.
        public static void CopyingInfo(WorkPC workPC, Storage[] storage)
        {
            WriteLine(" До копирования:\n" + workPC);
            Design.Line();

            if (storage.Length > 0)
            {
                Design.Green();
                WriteLine(" >> Копирование.");
                Design.Default();
            }
            else
            {
                Design.Blue();
                WriteLine(" --> Нет носителей на которые можно скопировать информацию.");
                Design.Default();
                return;
            }
            

            while (workPC.TotalSizeOfFiles != 0)
            {
                foreach (Storage item in storage)
                {
                    item.CopyingDataToTheDevice(workPC);
                }
            }

            // P.S.
            // Файлов на пк больше нет - значит размер файла можно приравнять к 0.
            // Соответственно на носителе в переменной можно хранить размер одного файла.
            
            WriteLine("\n После копирования:\n" + workPC);
            Design.Line();
        }



        // Расчет времени необходимого для копирования.
        public static void CopyTime(WorkPC workPC, Storage[] storage)
        {
            int recordingTime = 0;
            int readingTime = 0;
            int files;
            int totalSizeOfFiles = workPC.TotalSizeOfFiles;

            if (storage.Length == 0) {
                Design.Blue();
                WriteLine(" --> Время рассчитать невозможно.");
                WriteLine(" --> Нет носителей на которые можно скопировать информацию.");
                Design.Default();
                return;
            }

            while (totalSizeOfFiles != 0)
            {
                foreach (Storage item in storage)
                {
                    files = item.PlacedFiles(workPC.FileSize);
                    // Если кол-во файлов = 0,
                    // то переходим к следующему носителю.
                    if (files == 0)
                    {
                        continue;
                    }
                    recordingTime += ((workPC.FileSize * files) * 1024) / item.RecordingTime();
                    readingTime += ((workPC.FileSize * files) * 1024) / item.ReadingTime();
                    // Отнимаем от общего размера, размер вмещающихся файлов.
                    totalSizeOfFiles =
                        totalSizeOfFiles - (workPC.FileSize * files);
                }

                // Если ни один файл не скопирован (после проверки каждого носителя).
                if (workPC.TotalSizeOfFiles == totalSizeOfFiles)
                {
                    Design.Blue();
                    WriteLine(" --> Файлы не вмещаються на данные носители.");
                    Design.Default();
                    return;
                }
            }

            WriteLine($" Время копирования на носители: {recordingTime} мин");
            WriteLine($" Время чтения с носителей: {readingTime} мин");
            WriteLine(" Общее время копирования на другой пк: "
                + $"{recordingTime + readingTime} мин");

        }



        // Расчет необходимого количества носителей информации
        // представленных типов для переноса информации.
        public static void NumberOfStorage(WorkPC workPC, Storage[] storage)
        {
            int totalSizeOfFiles = workPC.TotalSizeOfFiles;
            int files;
            int[] arr = new int[storage.Length];

            if (storage.Length == 0)
            {
                Design.Blue();
                WriteLine(" --> Необходимое количество рассчитать невозможно.");
                WriteLine(" --> Нет носителей на которые можно скопировать информацию.");
                Design.Default();
                return;
            }

            while (totalSizeOfFiles != 0) {
                for (int i = 0; i < storage.Length; i++)
                {

                    // Узнаем кол-во файлов вмещающихся на носитель.
                    files = storage[i].PlacedFiles(workPC.FileSize);
                    // Если кол-во файлов = 0, то при вычислении
                    // размер вмещающихся файлов тоже = 0.
                    // Отнимаем от общего размера, размер вмещающихся файлов.
                    totalSizeOfFiles =
                        totalSizeOfFiles - (workPC.FileSize * files);

                    // Если вмещается больше чем 0 файлов.
                    if (files > 0)
                    {
                        arr[i]++;
                    }
                }
            }


            for (int i = 0; i < storage.Length; i++)
            {
                WriteLine($" Количество {storage[i].Name}: {arr[i]}");
            }

        }



    }
}